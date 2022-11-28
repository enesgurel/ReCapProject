﻿using Core.DataAccess.EntityFramework;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
    }
}
