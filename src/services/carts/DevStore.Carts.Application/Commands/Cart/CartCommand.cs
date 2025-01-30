using DevStore.Carts.Domain.Models.Enums;
using DevStore.Core.Mediatr.Commands;

namespace DevStore.Carts.Application.Commands
{
    public abstract class CartCommand : Command
    {
        public Guid UserId { get; set; }
        public Status Status { get; set; }
    }
}
