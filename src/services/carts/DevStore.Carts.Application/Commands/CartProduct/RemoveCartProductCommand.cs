using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Carts.Application.Commands
{
    public class RemoveCartProductCommand : Command, IRemoveCommand
    {
        public RemoveCartProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}
