using TourProgram.DAL;

namespace TourProgram.BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TourProgramDbContext _db;

        public UnitOfWork(TourProgramDbContext db)
        {
            _db = db;

            //ProductUnit = new EmpAdvanceRepository(_db);
        }

        //public IEmpAdvanceRepository ProductUnit { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}


