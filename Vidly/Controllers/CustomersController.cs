using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }


        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerViewModel
            {

                MembershipTypes = membershipTypes
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }

            var viewModel = new CustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                
            };

            return View(viewModel);
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            if (customer == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.Single(s => s.Id == customer.Id);

                customerInDb.IsSubscribedToNewsletter=customer.IsSubscribedToNewsletter;
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId= customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;

                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }

            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(customerViewModel);

        }


        public ActionResult Delete(int id)
        {
            var viewModel = new CustomerViewModel
            {
                Customer = _context.Customers.Single(c => c.Id == id),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        
    }
}