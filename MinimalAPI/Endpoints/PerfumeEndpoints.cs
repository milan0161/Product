using Application.Contracts;
using Application.Features.Commands.CreateProduct;
using Application.Features.Commands.DeleteProduct;
using Application.Features.Commands.UpdateProduct;
using Application.Features.Query.GetProduct;
using Application.Features.Query.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Endpoints
{
    public static class PerfumeEndpoints
    {

        public static async Task<IResult> CreateProduct(
            [FromServices] IMediator mediator, 
            [FromBody] CreateProductDto createProductDto)
        {
            var createProductCommand = new CreateProductCommand(createProductDto);
            var productId = await mediator.Send(createProductCommand);
            return Results.Created("https://localhost:7050/", productId);
        }

        public static async Task<IResult> GetProductAsync(
            IMediator mediator,
            [FromRoute] int id )
        {
            var getProductQuery = new GetProductQuery(id);
            var productDto = await mediator.Send(getProductQuery);
            return Results.Ok(productDto);
        }

        public static async Task<IResult> GetProductsAsync(
            IMediator mediator,
            [FromQuery] int pageSize,
            [FromQuery] int pageNumber)
        {
            var getProductsQuery = new GetProductsQuery(pageSize, pageNumber);
            var productsDto = await mediator.Send(getProductsQuery);
            return Results.Ok(productsDto);
        }

        public static async Task<IResult> DeleteProductAsync(
            IMediator mediator,
            [FromRoute] int id)
        {
            var deleteProductCommand = new DeleteProductCommand(id);
            await mediator.Send(deleteProductCommand);
            return Results.Ok();
        }

        public static async Task<IResult> UpdateProductAsync(
            IMediator mediator,
            [FromBody] UpdateProductDto updateProductDto
            )
        {
            var updateProductCommand = new UpdateProductCommand(updateProductDto);
            await mediator.Send(updateProductCommand);
            return Results.Ok();
        }
    }
}
