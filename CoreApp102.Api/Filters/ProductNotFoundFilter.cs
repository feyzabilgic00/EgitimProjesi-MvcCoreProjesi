using System.Linq;
using System.Threading.Tasks;
using CoreApp102.Api.DTOs;
using CoreApp102.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreApp102.Api.Filters
{
    public class ProductNotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault()!;
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto=new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id si {id} olan urun veritabaninda bulunamadi.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
