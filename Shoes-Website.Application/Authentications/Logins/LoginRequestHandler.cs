using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginRequestHandler> _logger;
        private readonly JwtSettings _jwtSettings;

        public LoginRequestHandler(IUserRepository userRepository,
            ILogger<LoginRequestHandler> logger,
            IOptions<JwtSettings> options)
        {
            _userRepository = userRepository;
            _logger = logger;
            _jwtSettings = options.Value;
        }

        public async Task<LoginResponseModel> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin login process");

            var filterAccount = new GetAccountByUsernameOrEmailSpecification(request.Username);
            var account = await _userRepository.FirstOrDefaultAsync(filterAccount);

            if(account == null)
            {
                var message = $"The account with username or email: {request.Username} does not existed";
                _logger.LogError(message);
                throw new LoginRequestException(message);
            }

            if(!VerifyPassword(request.Password, account.PasswordHash, account.PasswordSalt))
            {
                var message = $"The account with password: {request.Password} is not correct";
                _logger.LogError(message);
                throw new LoginRequestException(message);
            }

            var responseModel = CreateToken(account.RoleId, request.Username);

            return responseModel;
        }

        private LoginResponseModel CreateToken(int roleId, string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expiredTime = DateTime.Now.AddMinutes(30);

            var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Issuer,
                    claims: ListClaimOfUser(roleId),
                    expires: expiredTime,
                    signingCredentials: signingCredentials
                );
            var responseModel = new LoginResponseModel
            {
                AccessToken = $"Bearer {new JwtSecurityTokenHandler().WriteToken(tokenOptions)}",
                ExpiredTime = expiredTime,
                Username = username
            };

            return responseModel;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private List<Claim> ListClaimOfUser(int roleId)
        {
            var filter = new GetRoleByIdSpecification(roleId);
            var role = _userRepository.FirstOrDefaultAsync(filter).Result;

            var claimType = role.Name switch
            {
                "Admin" => "Admin",
                _ => ClaimTypes.Name
            };

            return new List<Claim>()
            {
                new Claim(claimType, role.Name)
            };
        }
    }
}
