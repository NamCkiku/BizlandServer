using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.CrossCutting.Bus
{
    public class LogingBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
    {
        private readonly ILogger<TRequest> logger;

        public LogingBehavior(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        public Task<TRespone> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespone> next)
        {
            logger.LogInformation($"Handling  {typeof(TRequest)}");
            return next();
        }
    }
}
