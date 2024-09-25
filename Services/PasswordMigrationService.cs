using BCrypt.Net;
using efcoreRestFull.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Services
{
    public class PasswordMigrationService
    {
        private readonly DataContext _context;

        public PasswordMigrationService(DataContext context)
        {
            _context = context;
        }


        public async Task MigratePasswordsAsync(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (!string.IsNullOrEmpty(customer.Password) && !customer.Password.StartsWith("$2a$"))
                {
                    customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);


                    await UpdateUserInDatabase(customer);
                }
            }
        }


        private async Task UpdateUserInDatabase(Customer customer)
        {
            var customerFromDb = await _context.Customers.FindAsync(customer.Id);
            
            if (customerFromDb != null)
            {
                Console.WriteLine(customerFromDb.Password);
                customerFromDb.Password = customer.Password;
                _context.Customers.Update(customerFromDb);
                _context.SaveChanges();
            }
            
        }


        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        public async Task MigrateAllPasswordsAsync()
        {
            var allCustomers = await _context.Customers.ToListAsync();


            await MigratePasswordsAsync(allCustomers);
        }
    }
}