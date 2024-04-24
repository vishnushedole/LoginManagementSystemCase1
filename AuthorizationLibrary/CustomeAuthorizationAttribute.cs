using Microsoft.AspNetCore.Mvc.Filters;
using LoginManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProductsService.Infrastructure
{
    public class CustomeAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as User;
            if (user is null)
            {
                context.Result = new JsonResult(
                    new { message = "You are not allowed to access this API." }
                    )
                {
                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
