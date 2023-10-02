using Application.Contracts;
using Application.Features.Commands.CreateProduct;
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
            return Results.Created("", productId);
        }
    }
}
