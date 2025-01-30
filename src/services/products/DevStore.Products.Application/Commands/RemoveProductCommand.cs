using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Products.Application.Commands
{
    public class RemoveProductCommand : Command, IRemoveCommand
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}
