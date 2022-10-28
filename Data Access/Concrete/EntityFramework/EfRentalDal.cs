using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Data_Access.Abstract;
using Entities.Concrete;

namespace Data_Access.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {

    }
}
