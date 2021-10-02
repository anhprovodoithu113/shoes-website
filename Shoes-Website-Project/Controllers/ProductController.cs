using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes_Website.Application.Products.AddNewProduct;
using System.Net;
using Shoes_Website_Project.Configuration.Exceptions;
using Shoes_Website.Application.Products.Common;
using Shoes_Website.Application.Products.GetAllProducts;
using System.Collections.Generic;
using Shoes_Website.Application.Products.AddProductColor;
using Shoes_Website.Application.Products.AddProductStatus;
using Shoes_Website.Application.Products.GetColorsByProduct;
using Shoes_Website.Application.Products.GetProductStatusesByColor;
using Shoes_Website.Application.Products.GetProductDetailsById;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("get-colors-by-product/{productId}")]
        [ProducesResponseType(typeof(List<ProductColorResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetColorsByProduct([FromRoute] int productId)
        {
            var query = new GetColorsByProductQuery { ProductId = productId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("get-product-statuses-by-color/{productColorId}")]
        [ProducesResponseType(typeof(List<ProductStatusResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductStatusesByColor([FromRoute] int productColorId)
        {
            var query = new GetProductStatusesByColorQuery { ProductColorId = productColorId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("product-details/{productId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductDetailsById([FromRoute] int productId)
        {
            var query = new GetProductDetailsByIdQuery() { ProductId = productId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Policy = "UserRole")]
        [HttpPost("add-new-product"), DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddNewProduct([FromForm] AddProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Created("", result);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost("add-product-color")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddColorForProduct([FromBody] AddProductColorCommand command)
        {
            var result = await _mediator.Send(command);

            return Created("", result);
        }

        [HttpPost("add-product-statuses")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddStatusesForProduct([FromBody] AddProductStatusCommand command)
        {
            var result = await _mediator.Send(command);

            return Created("", result);
        }
    }
}
