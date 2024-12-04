using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Domain.Enitities;
using Microsoft.EntityFrameworkCore;

namespace TestWithValue.Data.Repository
{
    public class CaseRepository : ICaseRepository
    {
        private readonly TestWithValueDbContext _context;
        public CaseRepository(TestWithValueDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tbl_Case>> GetAllCasesAsync()
        {
            return await _context.tbl_Cases.Include(c => c.User).ToListAsync();
        }

        public async Task<Tbl_Case> GetCaseByIdAsync(int caseId)
        {
            return await _context.tbl_Cases.Include(c => c.User).FirstOrDefaultAsync(c => c.CaseId == caseId);
        }

        public async Task<IEnumerable<Tbl_Case>> GetCasesByUserIdAsync(string userId)
        {
            return await _context.tbl_Cases
                .Include(c => c.User)
                .Where(c => c.UserId == userId)
                .ToListAsync(); // فیلتر کردن بر اساس UserId
        }

        public async Task AddCaseAsync(Tbl_Case newCase)
        {
            try
            {
                await _context.tbl_Cases.AddAsync(newCase);
            }
            catch (Exception ex)
            {

                var inner = ex.InnerException.Message;
                inner.Trim();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
