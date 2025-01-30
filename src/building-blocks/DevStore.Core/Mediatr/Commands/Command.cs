using DevStore.Core.Extensions;
using DevStore.Core.Mediatr.Messages;
using FluentValidation.Results;

namespace DevStore.Core.Mediatr.Commands
{
    public abstract class Command : RequestMessage
    {
        public Guid Id { get; protected set; }
        public DateTime Timestamp { get; private set; } = DateTime.Now.ToBrazilianTimezone();
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public void SetCommandId(Guid id)
        {
            Id = id;
        }
        protected Command()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }

        public abstract bool IsValid();
    }
}