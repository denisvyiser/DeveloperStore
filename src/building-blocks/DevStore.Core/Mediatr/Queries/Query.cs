using DevStore.Core.Extensions;
using DevStore.Core.Mediatr.Messages;
using FluentValidation.Results;

namespace DevStore.Core.Mediatr.Queries
{
    public abstract class Query<TResponse> : ResponseMessage<TResponse>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected Query()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }

        public abstract bool IsValid();
    }
}