using System;
using MediatR;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Domain.Models.ShoesWebsite;
using Shoes_Website.Application.Products.Common;
using Microsoft.Extensions.Hosting;

namespace Shoes_Website.Application.Products.AddNewProduct
{
    public class AddNewProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddNewProductHandler(IRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var extension = Path.GetExtension(request.ImageFile.FileName);

            if (!ValidExtensionFile(extension))
            {
                throw new AddProductException("Error image file. Please choose again!!!");
            }

            var binaryImage = await ConvertImageToBinary(request.ImageFile);
            var createdAt = DateTime.Now;

            // Save file to local for back-up purpose
            var folderServerName = Path.Combine("Resources", ProductConstant.FOLDER_NAME);
            var localFileName = string.Concat(request.Name, createdAt.Ticks, extension);
            await File.WriteAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(), folderServerName, localFileName), binaryImage);

            var product = new Product
            {
                Name = request.Name,
                CreatedAt = createdAt,
                ImagePath = localFileName,
                Original = request.Original,
                IsMenShoes = request.IsMenShoes,
                Description = request.Description,
                DefaultPrice = request.DefaultPrice,
            };

            await _repository.AddAsync(product);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<byte[]> ConvertImageToBinary(IFormFile image)
        {
            using(var dataStream = new MemoryStream())
            {
                await image.CopyToAsync(dataStream);
                return dataStream.ToArray();
            }
        }

        private bool ValidExtensionFile(string extension)
        {
            var lstExtension = new string[] { ".jpeg", ".png", ".jpg", ".svg"};

            return lstExtension.Contains(extension);
        }
    }
}
