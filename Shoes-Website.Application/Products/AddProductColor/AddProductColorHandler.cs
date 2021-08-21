using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.AddProductColor
{
    public class AddProductColorHandler : IRequestHandler<AddProductColorCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddProductColorHandler> _logger;

        public AddProductColorHandler(IRepository repository,
            IUnitOfWork unitOfWork,
            ILogger<AddProductColorHandler> logger)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductColorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin add color for productId: {request.ProductId}");

            var filter = new GetProductColorByProductIdAndColorSpecification(request.ProductId, request.Color);
            var prodColorFromDb = await _repository.FirstOrDefaultAsync(filter);

            if(prodColorFromDb != null)
            {
                var message = $"Duplicated Color for productId: {request.ProductId}";
                _logger.LogError(message);
                throw new AddProductColorException(message);
            }

            _logger.LogInformation($"Create new instance of productColor for productId: {request.ProductId}");

            var prodColor = new ProductColor
            {
                ProductId = request.ProductId,
                Color = request.Color
            };

            await _repository.AddAsync(prodColor);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Finish process for adding product color");

            return Unit.Value;
        }
    }
}
