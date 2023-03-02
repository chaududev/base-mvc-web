using AppCrud.Data;
using AppCrud.Interface;
using AppCrud.Models;
using AppCrud.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AppCrud.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public string Insert(CustomerViewModel Customer)
        {
            using (var db = new MyDbContext())
            {
                Customer Type = new Customer(Customer.FullName, Customer.Birthday, Customer.Date, Customer.Phone, Customer.Address, Customer.Email);
                db.Add(Type);
                db.SaveChanges();
                return "Insert Success";
            }
        }

        public string Delete(int Id)
        {
            using (var db = new MyDbContext())
            {
                var Custome = db.Customers.Where(e => e.Id == Id).FirstOrDefault();
                if (Custome == null) return "Delete failed";
                db.Customers.Remove(Custome);
                db.SaveChanges();
                return "Delete Success";
            }
        }

        public Customer GetById(int Id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Customers.SingleOrDefault(e => e.Id == Id);
                return rs;
            }
        }

        public List<Customer> GetList()
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Customers.ToList();
                return rs;
            }
        }

        public List<Customer> GetListLike(string Name)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Customers.Where(e => e.FullName.Contains(Name)).ToList();
                return rs;
            }
        }

        public string Update(int Id, CustomerViewModel Customer)
        {
            using (var db = new MyDbContext())
            {
                Customer CustomesBefore = db.Customers.SingleOrDefault(e => e.Id == Id);
                CustomesBefore.Update(Customer.FullName, Customer.Birthday, Customer.Date, Customer.Phone, Customer.Address, Customer.Email);
                db.SaveChanges();
                return "Update Success";
            }
        }
    }
}


