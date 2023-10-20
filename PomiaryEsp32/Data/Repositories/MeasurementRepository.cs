using Microsoft.EntityFrameworkCore;
using PomiaryEsp32.Data.Models;
using System.Linq.Expressions;

namespace PomiaryEsp32.Data.Repositories
{
    public class MeasurementRepository : BaseCrudRepository<Measurement, int>
    {
        public MeasurementRepository(DataContext context) : base(context)
        {

        }

        public override async Task<Measurement> Get(int id)
        {
            return await context.Measurements.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Measurement> Get(Expression<Func<Measurement, bool>> exp)
        {
            return await context.Measurements.FirstOrDefaultAsync(exp);
        }

        public override async Task<List<Measurement>> GetAll()
        {
            return await context.Measurements.ToListAsync();
        }

        public override async Task<List<Measurement>> GetAll(Expression<Func<Measurement, bool>> exp)
        {
            return await context.Measurements.Where(exp).ToListAsync();
        }
    }
}
