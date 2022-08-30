using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogPage.API.Filters
{
    public class ValidateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
