using DevStore.Carts.Domain.Models.Enums;
using DevStore.Core.Helpers.Repository;
using DevStore.Core.Models.Entities;

namespace DevStore.Carts.Domain.Models.Entities
{
    public class Cart : Entity
    {
        public Cart(Guid id,Guid userId, Status status)
        {
            Id = id;
            UserId = userId;
            Status = status;
        }

        [PropertyValidation]
        public Guid UserId { get; set; }

        [PropertyValidation]
        public Status Status { get; set; }
        public List<CartProduct> CartProduct { get; set; } = new List<CartProduct>();
    }
}
