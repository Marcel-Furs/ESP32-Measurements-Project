using Microsoft.EntityFrameworkCore;
using PomiaryEsp32.Data.Models;
using System.Linq.Expressions;

namespace PomiaryEsp32.Data.Repositories
{
    public class UserRepository : BaseCrudRepository<User, int>
    {
        public UserRepository(DataContext context) : base(context)
        {

        }

        public override async Task<User> Get(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<User> Get(Expression<Func<User, bool>> exp)
        {
            return await context.Users.FirstOrDefaultAsync(exp);
        }

        public override async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public override async Task<List<User>> GetAll(Expression<Func<User, bool>> exp)
        {
            return await context.Users.Where(exp).ToListAsync();
        }
    }
}
