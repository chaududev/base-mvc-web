using AppCrud.Models;
using AppCrud.ViewModel;
using System.Collections.Generic;

namespace AppCrud.Service.CustomersService
{
    public interface ICustomerService
    {
        List<Customer> GetList();
        List<Customer> GetListLike(string Name);
        Customer GetById(int Id);

        string Insert(CustomerViewModel Customer);
        string Update(int Id, CustomerViewModel Customer);
        string Delete(int Id);
    }
}