using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customers);
        IResult Update(Customer customers);
        IResult Delete(Customer customers);
        IDataResult<List<Customer>> GetAll();
    }
}
