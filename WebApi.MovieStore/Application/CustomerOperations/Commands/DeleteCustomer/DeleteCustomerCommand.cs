using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        public int CustomerID { get; set; }
        public DeleteCustomerCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerID);
            if (customer is null)
            {
                throw new InvalidOperationException("Böyle bir kullanıcı yok.");
            }
            
            customer.IsActive=false;
            _context.SaveChanges();
        }
    }
}
