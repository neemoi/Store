using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IRepository.User;

namespace Application.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPaginationRepository PaginationRepository { get; }

        IProductRepository ProductRepository { get; }

        IPaymentsRepository PaymentsRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IDeliveryRepository DeliveryRepository { get; }

        IOrderRepository OrderRepository { get; }

        IUserOrderRepository UserOrderRepository { get; }

        IProfileRepository ProfileRepository { get; }

        IRoleRepostitory RoleRepostitory { get; }

        IUserRepository UserRepository { get; }
        
        Task SaveChangesAsync();
    }
}
