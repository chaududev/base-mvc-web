using AppCrud.Interface;
using AppCrud.Models;
using AppCrud.ViewModel;
using System.Collections.Generic;

namespace AppCrud.Service.CustomersService
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _customerRepository)
        {
            this.customerRepository = _customerRepository;
        }

        public string Insert(CustomerViewModel Customer)
        {
             return customerRepository.Insert(Customer);
        }

        public string Delete(int Id)
        {
            var clothe = customerRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return customerRepository.Delete(Id);
        }

        public Customer GetById(int Id)
        {
            return customerRepository.GetById(Id);
        }

        public List<Customer> GetList()
        {
            return customerRepository.GetList();
        }

        public List<Customer> GetListLike(string Name)
        {
            return customerRepository.GetListLike(Name);
        }

        public string Update(int Id, CustomerViewModel Customer)
        {
            var clothe = customerRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return customerRepository.Update(Id, Customer);
        }
    }
}