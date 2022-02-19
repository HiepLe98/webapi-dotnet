using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApp.Data;
using WebCoreApp.Models;

namespace WebCoreApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public CategoryVM Add(CategoryVM category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryVM GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryVM category)
        {
            throw new NotImplementedException();
        }
    }
}
