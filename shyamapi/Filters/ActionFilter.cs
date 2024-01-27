using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class ActionFilter :Attribute, IActionFilter
    {//Attribute for controller/action level filter
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
