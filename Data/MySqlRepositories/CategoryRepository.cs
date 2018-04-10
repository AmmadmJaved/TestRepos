using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MySqlRepositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
    public interface ICategoryRepository : IGenericRepository<Category, int>
    {
    }
}
