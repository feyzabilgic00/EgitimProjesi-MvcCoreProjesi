using System.Linq;
using System.Threading.Tasks;
using CoreApp102.Core.Services;
using CoreApp102.Mvc.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreApp102.Mvc.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault()!;
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto=new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id si {id} olan category veritabaninda bulunamadi.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
