using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Sales.Application.Commands
{
    public class RemoveSaleCommand : Command, IRemoveCommand
    {
        public RemoveSaleCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}
