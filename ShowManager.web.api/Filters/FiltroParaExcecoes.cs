using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowManager.web.api.Filters
{
    public class FiltroParaExcecoes : IExceptionFilter
    {
        private readonly ILogger<FiltroParaExcecoes> _logger;

        public FiltroParaExcecoes(ILogger<FiltroParaExcecoes> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu um erro durante o processamento da requisição");

            var result = new ObjectResult(new
            {
                Mensagem = "Ocorreu um erro durante o processamento",
                Detalhes = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
