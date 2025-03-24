using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            return new SuccessfulDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessfulDataResult<Category>(_categoryDal.Get(x => x.CategoryId == categoryId));
        }
    }
}
