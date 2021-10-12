using MediatR;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shoes_Website.Application.Authentications.Registers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkUser _unitOfWorkUser;
        private readonly ILogger<RegisterRequestHandler> _logger;

        public RegisterRequestHandler(IUserRepository userRepository,
            ILogger<RegisterRequestHandler> logger,
            IUnitOfWorkUser unitOfWorkUser)
        {
            _logger = logger;
            _unitOfWorkUser = unitOfWorkUser;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin register process");

            RequestValidator(request);

            _logger.LogInformation("Encript password");
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var account = new Account
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = 2
            };
            _logger.LogInformation("Save account to database");
            await _userRepository.AddAsync(account);
            await _unitOfWorkUser.CommitAsync();

            return Unit.Value;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private void RequestValidator(RegisterRequest request)
        {
            if(request.Username.Length < 3 && request.Username.Length > 20)
            {
                string message = "The length of username must be at least 3 and at most 20 character";
                _logger.LogError(message);
                throw new RegisterRequestException(message);
            }

            if (request.Password != request.ConfirmPassword)
            {
                string message = "Password is not match";
                _logger.LogError(message);
                throw new RegisterRequestException(message);
            }
            if (!IsValidEmail(request.Email))
            {
                string message = "Email is not correct format";
                _logger.LogError(message);
                throw new RegisterRequestException(message);
            }
            var validatePasswordMessage = ValidatePassword(request.Password);
            if (validatePasswordMessage != string.Empty)
            {
                _logger.LogError(validatePasswordMessage);
                throw new RegisterRequestException(validatePasswordMessage);
            }
            if (IsExistedEmail(request.Email))
            {
                string message = $"This Email: {request.Email} is existed in system";
                _logger.LogError(message);
                throw new RegisterRequestException(message);
            }
            if (IsExistedUsername(request.Username))
            {
                string message = $"This Username: {request.Username} is existed in system";
                _logger.LogError(message);
                throw new RegisterRequestException(message);
            }
        }

        private bool IsExistedEmail(string email)
        {
            var filer = new GetAccountByEmailSpecification(email);
            return _userRepository.AnyAsync(filer).Result;
        }

        private bool IsExistedUsername(string username)
        {
            var filter = new GetAccountByUsernameSpecification(username);
            return _userRepository.AnyAsync(filter).Result;
        }

        private bool IsValidEmail(string email)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private string ValidatePassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if(password.Length <= 6)
            {
                return "Password must more than 6 characters";
            }
            else if (!hasNumber.IsMatch(password))
            {
                return "Password should contain At least one numeric value";
            }
            else if(!hasUpperChar.IsMatch(password))
            {
                return "Password should contain At least one upper case letter";
            }
            else if (!hasLowerChar.IsMatch(password))
            {
                return "Password should contain At least one lower case letter";
            }
            else if (!hasSymbols.IsMatch(password))
            {
                return "Password should contain At least one special case characters";
            }

            return string.Empty;
        }
    }
}
