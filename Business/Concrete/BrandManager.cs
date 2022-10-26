﻿using Business.Abstract;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccesResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>();
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            _brandDal.Get(b=>b.BrandId == brandId);
            return new SuccessDataResult<Brand>();
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccesResult();
        }
    }
}
