using CLG.OperationAPI.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CLG.OperationAPI.Application.Repositories
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly Context _context;

        public OperationRepository(Context context)
        {
            _context = context;
        }

        public async Task AddOperation(Operation request)
        {
            request.Date = DateTime.Now;
            _context.Operations.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Operation>> GetDailyReport(DateTime date)
        {
            var result = await _context.Operations.Where(o => o.Date < Convert.ToDateTime(date.ToShortDateString()).AddDays(+1)
                                           && o.Date > Convert.ToDateTime(date.ToShortDateString()).AddDays(-1)).ToListAsync();

            return result;
        }
    }
}
