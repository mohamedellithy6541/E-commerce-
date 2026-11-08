using catalog.Application.Commands;
using catalog.Application.Quaries;
using catalog.Application.Responses;
using catalog.Core.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpGet("GetProductByName/{name}")]
        [ProducesResponseType(typeof(IList<ProductResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponseDto>>> GetProductByName(string name)
        {
            var result = await _mediator.Send(new GetProductByNameQuery(name));
            return Ok(result);
        }

        [HttpGet]
        [Route("", Name = "GetAllProducts")]
        public async Task<ActionResult<ProductResponseDto>> GetAllProducts([FromQuery] CatalogSpecParms catalogSpecParms)
        {
            var products = new GetAllProductsQuery(catalogSpecParms);
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

        [HttpGet]
        [Route("GetAllbBrands", Name = "GetAllbBrands")]
        public async Task<ActionResult<BrandResponseDto>> GetAllBrands()
        {
            GetAllBrandsQuery brands = new GetAllBrandsQuery();
            var result = await _mediator.Send(brands);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllTypes", Name = "GetAllTypes")]
        public async Task<ActionResult<ProductTypeResponseDto>> GetAllTypes()
        {
            GetAllProductTypesQuery types = new GetAllProductTypesQuery();
            var result = await _mediator.Send(types);
            return Ok(result);
        }

        #endregion
    }
}
