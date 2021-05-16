using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base_FrameWork.Infrastructure;

namespace MB.Infrastructure.EfCore
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MBContext _context;

        public UnitOfWorkEf(MBContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
           _context.Database.RollbackTransaction();
        }
    }
}
