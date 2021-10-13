using MediatR;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Domain.Models.ShoesWebsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shoes_Website.Application.Products.CheckoutProducts
{
    public class CheckoutProductHandler : IRequestHandler<CheckoutProductsRequest>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger<CheckoutProductHandler> _logger;

        public CheckoutProductHandler(IRepository repository,
            IUnitOfWork unitOfWork,
            ILogger<CheckoutProductHandler> logger,
            ICurrentUserService currentUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _logger = logger;
        }

        public async Task<Unit> Handle(CheckoutProductsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin checking out products for productStatusId: {request.ProductStatusId}");

            var newInvoice = new Invoice
            {
                InvoiceCode = Guid.NewGuid().ToString(),
                DeliveryDate = DateTime.Now.AddDays(10),
                OrderedDate = DateTime.Now,
                OrderedAmount = request.OrderedAmount,
                ProductStatusId = request.ProductStatusId,
                CustomerEmail = _currentUser.Email,
                Price = request.TotalPrice
            };

            await _repository.AddAsync(newInvoice);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
