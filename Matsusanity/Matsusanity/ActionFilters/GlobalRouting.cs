using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Matsusanity.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if(controller.Equals("Home"))
            {
                if(_claimsPrincipal.IsInRole("Administrator"))
                {
                    context.Result = new RedirectToActionResult("Home", "Administrators", null);
                }
                if (_claimsPrincipal.IsInRole("Personal Trainer"))
                {
                    context.Result = new RedirectToActionResult("Index", "PersonalTrainers", null);
                }
                if (_claimsPrincipal.IsInRole("Client"))
                {
                    context.Result = new RedirectToActionResult("Index", "Clients", null);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
