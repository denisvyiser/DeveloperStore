using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Carts.Application.Commands
{
    public class RemoveCartCommand : Command, IRemoveCommand
    {
        public RemoveCartCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}
