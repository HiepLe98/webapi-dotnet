using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApp.Models;

namespace WebCoreApp.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(Guid id);
        CategoryVM Add(CategoryVM category);
        void Update(CategoryVM category);
        void Delete(Guid id);
    }
}
