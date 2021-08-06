using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes_Website.Application.Products.AddNewProduct;
using System.Net;
using Shoes_Website_Project.Configuration.Exceptions;
using System.IO;
using Shoes_Website.Application.Products.Common;
using Shoes_Website.Application.Products.GetAllProducts;
using System.Collections.Generic;
using Shoes_Website.Application.Products.AddProductOptionsByProduct;

namespace Shoes_Website_Project.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

            if (!Directory.Exists(ProductConstant.folderPath))
            {
                Directory.CreateDirectory(ProductConstant.folderPath);
            }
        }

        [HttpGet("get-all-products")]
        [ProducesResponseType(typeof(List<ProductResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost("add-new-product")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddNewProduct([FromForm] AddProductCommand command)
        {
            await _mediator.Send(command);

            return Created("", null);
        }

        [HttpPost("add-options/{productId}")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddOptionsForProduct([FromRoute] int productId)
        {
            var command = new AddOptionsForProductCommand(productId);

            var result = await _mediator.Send(command);

            return Created("", result);
        }
    }
}
