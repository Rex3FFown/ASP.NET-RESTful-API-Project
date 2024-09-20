
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using efcoreRestFull.Context;
using efcoreRestFull.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        public readonly IMapper _mapper;
        public readonly DataContext _context;
        public CustomerController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {var customers = await _context.Customers.OrderBy(c=>c.Id).ToListAsync();
            var customersDto = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(customersDto);

        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer([FromRoute]int customerId,[FromBody] Customer customer)
        {
            Customer thisCustomer = _context.Customers.Find(customerId);
            thisCustomer.Name = customer.Name;
            thisCustomer.Surname = customer.Surname;
            thisCustomer.Email = customer.Email;
            thisCustomer.Password = customer.Password;
            thisCustomer.Address = customer.Address;
            _context.Customers.Update(thisCustomer);
             _context.SaveChanges();
             return Ok(customer);
        }

        [HttpDelete("{customerId}")]
        public void DeleteCustomer([FromRoute] int customerId)
        {
            Customer thisCustomer = _context.Customers.Find(customerId);
            _context.Customers.Remove(thisCustomer);
            _context.SaveChanges();
            
        }
    }
}