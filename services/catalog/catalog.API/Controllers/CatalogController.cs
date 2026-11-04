using catalog.Application.Commands;
using catalog.Application.Quaries;
using catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catalog.API.Controllers
{
    public class CatalogController : BaseApiController
    {
        #region Prop
        private readonly IMediator _mediator;

        #endregion

        #region Ctor
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("[action]/{id}", Name = "Products")]
        public async Task<ActionResult<ProductResponseDto>> GetProduct(string id)
        {
            GetProductByIdQuery product = new GetProductByIdQuery(id);
            var result = await _mediator.Send(product);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{name}", Name = "ProductesBynames")]
        public async Task<ActionResult<IList<ProductResponseDto>>> GetProductByName(string name)
        {
            var productByName = new GetProductByNameQuery(name);
            var result = await _mediator.Send(productByName);
            return Ok(result);
        }

        [HttpGet]
        [Route("", Name = "GetAllProducts")]
        public async Task<ActionResult<ProductResponseDto>> GetAllProducts()
        {
            var products = new GetAllProductsQuery();
            var result = await _mediator.Send(products);
            return Ok(result);
        }

        [HttpPost]
        [Route("", Name = "CreateProduct")]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send<ProductResponseDto>(createProductCommand);
            return Ok(result);
        }
        
        [HttpPut]
        [Route("", Name = "UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await _mediator.Send<bool>(updateProductCommand);
            return Ok(result);
        }
        
        [HttpDelete]
        [Route("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult<bool>> DeleteProduct(string id)
        {
            var deleteProductCommand = new DeleteProductCommand(id);
            var result = await _mediator.Send<bool>(deleteProductCommand);
            return Ok(result);
        } 

        #endregion
    }
}
