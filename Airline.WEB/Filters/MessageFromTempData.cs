using System.Web.Mvc;

namespace Airline.WEB.Filters
{
    public class MessageFromTempData : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var message = context.Controller.TempData["Message"];
            context.Controller.ViewBag.Message = message;
        }
    }
}