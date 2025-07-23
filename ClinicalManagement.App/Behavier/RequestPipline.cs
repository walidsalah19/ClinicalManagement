using FluentValidation;
using MediatR;

namespace ClinicalManagement.Application.Behavier
{
    public class RequestPipline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestPipline(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators.Select(o => o.Validate(context))
                .SelectMany(om=>om.Errors)
                .Where(er=>er !=null)
                .ToList();


            if(failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();

        }
    }
}
