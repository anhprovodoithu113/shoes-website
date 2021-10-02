using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.AddProductStatus
{
    public class AddProductStatusHandler : IRequestHandler<AddProductStatusCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddProductStatusHandler> _logger;

        public AddProductStatusHandler(IRepository repository,
            IUnitOfWork unitOfWork,
            ILogger<AddProductStatusHandler> logger)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductStatusCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin process for Adding product status of productColorId: {request.ProductColorId}");

            var filter = new GetProductStatusBySizeAndProductColorIdSpecification(request.ProductColorId, request.Size);
            var prodStatusFromDb = await _repository.FirstOrDefaultAsync(filter);

            if (prodStatusFromDb != null)
            {
                _logger.LogInformation($"Begin process for Updating product status of productColorId: {request.ProductColorId}");

                UpdateProductStatus(prodStatusFromDb, request.Amount);
            }

            else
            {
                _logger.LogInformation($"Create new instance for Product Status of ProductColorId: {request.ProductColorId}");

                var prodStatus = new ProductStatus
                {
                    ProductColorId = request.ProductColorId,
                    Size = request.Size,
                    Amount = request.Amount
                };

                await _repository.AddAsync(prodStatus);
            }

            await _unitOfWork.CommitAsync();

            _logger.LogInformation($"Finish process for Product Status of productColorId: {request.ProductColorId}");

            return Unit.Value;
        }

        private void UpdateProductStatus(ProductStatus productStatus, int amount)
        {
            productStatus.Amount += amount;

            _repository.Update(productStatus);
        }
    }
}
