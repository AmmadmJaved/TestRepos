using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.MySqlRepositories
{
    public class PatientUserRepository : BaseRepository<PatientUser, int>, IPatientUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PatientUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public PatientUser GetByEmail(string Email)
        {

            var query = this.GetAll().FirstOrDefault(x => x.Email == Email);
            return query;
        }
        //public void Edit(PatientUser entity)
        //{

        //    context.Entry<PatientUser>(entity).State = System.Data.EntityState.Modified;
        //}

    }
    public interface IPatientUserRepository : IGenericRepository<PatientUser, int>
    {
        PatientUser GetByEmail(string Email);
    }
}
