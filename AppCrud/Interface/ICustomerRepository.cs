using System.Collections.Generic;
using System;
using AppCrud.Models;
using AppCrud.ViewModel;

namespace AppCrud.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetList();
        List<Customer> GetListLike(string Name);
        Customer GetById(int Id);
        String Insert(CustomerViewModel Customer);
        String Update(int Id, CustomerViewModel Customer);
        String Delete(int Id);
    }
}
