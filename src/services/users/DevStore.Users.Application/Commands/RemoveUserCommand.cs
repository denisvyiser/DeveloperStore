using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Users.Application.Commands
{
    public class RemoveUserCommand : Command, IRemoveCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}
