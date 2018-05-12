using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MySqlRepositories
{
  public  class PhysicianRepository : BaseRepository<Physician, int>, IPhysicianRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PhysicianRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
    public interface IPhysicianRepository : IGenericRepository<Physician, int>
    {
    }
}
