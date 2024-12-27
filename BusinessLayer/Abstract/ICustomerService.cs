using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
        Customer ValidateCustomer(string email, string password);
    }
}
