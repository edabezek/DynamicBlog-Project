using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            //eFCategoryRepository = new EFCategoryRepository();
            _categoryDal = categoryDal;
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
