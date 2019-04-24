using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_AngularJS_WebAPI_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        [Route("api/AjaxAPI/GetCustomers")]
        [HttpPost]
        public List<Customer> GetCustomers()
        {
            CustomersEntities entities = new CustomersEntities();
            return entities.Customers.ToList();
        }

        [Route("api/AjaxAPI/InsertCustomer")]
        [HttpPost]
        public Customer InsertCustomer(Customer customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return customer;
        }

        [Route("api/AjaxAPI/UpdateCustomer")]
        [HttpPost]
        public bool UpdateCustomer(Customer customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Country = customer.Country;
                entities.SaveChanges();
            }

            return true;
        }

        [Route("api/AjaxAPI/DeleteCustomer")]
        [HttpPost]
        public void DeleteCustomer(Customer _customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == _customer.CustomerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }
    }
}
