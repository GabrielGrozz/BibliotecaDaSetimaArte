using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaDaSetimaArte.Filters
{
    public class ApiLogginFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("executado antes a aplicação #################################################");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("executando depois da aplicação #################################################");
        }

    }
}
