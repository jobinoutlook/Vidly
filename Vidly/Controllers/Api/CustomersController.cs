using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    //Use Postman for testing API
    public class CustomersController : ApiController
    {

        ApplicationDbContext _context;

        public CustomersController()
        {
                _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList(); 
        }

        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }

            return customer;
        }


        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);   
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            

            Customer customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipType = customer.MembershipType;
            
            _context.SaveChanges();

        }
        //DELETE /api/customers/1
        public void DeleteCustomer(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
