using Microsoft.EntityFrameworkCore;
using Volvo.Domain.Interface;
using Volvo.Domain.Models;
using Volvo.EntityFramework.Context;

namespace Volvo.EntityFramework.Repository
{
    public class BaseRepository<Model> : IRepository<Model> where Model : BaseModel
    {
        protected readonly MyContext _context;
        private DbSet<Model> _dbset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbset = _context.Set<Model>();
        }

        public async Task<Model> CreateAsync(Model model)
        {
            try
            {
                if (model.Id == Guid.Empty)
                {
                    model.Id = Guid.NewGuid();
                }
                model.CreatedAt = DateTime.UtcNow;
                _dbset.Add(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return model;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var result = await _dbset.SingleOrDefaultAsync(m=>m.Id.Equals(Id));

                if (result==null)
                    return false;

                _dbset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Model> SelectAsync(Guid Id)
        {
            try
            {
                 return await _dbset.SingleOrDefaultAsync(m=>m.Id.Equals(Id));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Model>> SelectAsync()
        {
            try
            {
                 return await _dbset.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Model> UpdateAsync(Model model)
        {
            try
            {
                var result = await _dbset.SingleOrDefaultAsync(m=>m.Id.Equals(model.Id));

                if (result==null)
                    return null;

                model.UpdatedAt = DateTime.UtcNow;
                model.CreatedAt= result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return model;
        }
    }
}