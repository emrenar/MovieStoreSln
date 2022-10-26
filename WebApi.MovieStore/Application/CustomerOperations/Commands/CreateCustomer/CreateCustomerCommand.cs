using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        public CreateCustomerModel Model { get; set; }

        public CreateCustomerCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.CustomerName == Model.CustomerName && x.CustomerSurname == Model.CustomerSurname);
            if (customer is not null)
            {
                throw new InvalidOperationException("Bu kullanıcı zaten var.");
            }
            customer = new Customer();
            customer.CustomerName = Model.CustomerName;
            customer.CustomerSurname = Model.CustomerSurname;
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

    }
    public class CreateCustomerModel
    {
        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }
       
    }
}
