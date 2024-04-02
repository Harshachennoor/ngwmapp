using Microsoft.EntityFrameworkCore;

namespace ngwmapp
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Customer>().HasData(
        //         new Customer
        //         {
        //             CustomerId = "1",
        //             FirstName = "Harshavardhan",
        //             LastName = "Chennoor",
        //             Email = "harshachennoor@gmail.com",
        //             Password = "Harsha@123",
        //             PhoneNumber = "3316660212"
        //         }
        //     );
        // }
    }
}