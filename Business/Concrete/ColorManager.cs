using Business.Abstract;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccesResult();
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>();
        }

        public IDataResult<Color> GetById(int colorId)
        {
            _colorDal.Get(c => c.ColorId == colorId);
            return new SuccessDataResult<Color>();
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult();
        }
    }
}
