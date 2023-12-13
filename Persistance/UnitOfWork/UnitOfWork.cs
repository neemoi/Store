using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IRepository.User;
using Application.Services.UnitOfWork;
using WebAPIKurs;

namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPaginationRepository PaginationRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPaymentsRepository PaymentsRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IDeliveryRepository DeliveryRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IUserOrderRepository UserOrderRepository { get; }

        public IProfileRepository ProfileRepository { get; }

        public IRoleRepostitory RoleRepostitory { get; }

        public IUserRepository UserRepository { get; }


        private readonly WebsellContext _websellContext;

        public UnitOfWork(IPaginationRepository paginationRepository, IProductRepository productRepository, IPaymentsRepository paymentsRepository, ICategoryRepository categoryRepository, IDeliveryRepository deliveryRepository, IOrderRepository orderRepository, IUserOrderRepository userOrderRepository, IProfileRepository profileRepository, IRoleRepostitory roleRepostitory, IUserRepository userRepository, WebsellContext websellContext)
        {
            PaginationRepository = paginationRepository;
            ProductRepository = productRepository;
            PaymentsRepository = paymentsRepository;
            CategoryRepository = categoryRepository;
            DeliveryRepository = deliveryRepository;
            OrderRepository = orderRepository;
            UserOrderRepository = userOrderRepository;
            ProfileRepository = profileRepository;
            RoleRepostitory = roleRepostitory;
            UserRepository = userRepository;
            _websellContext = websellContext;
        }

        public Task SaveChangesAsync()
        {
            return _websellContext.SaveChangesAsync();
        }
    }
}
