using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SocialMedia.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}