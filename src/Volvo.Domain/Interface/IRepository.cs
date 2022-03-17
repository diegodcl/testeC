using Volvo.Domain.Models;

namespace Volvo.Domain.Interface
{
    public interface IRepository<Model> where Model:BaseModel
    {
         Task<Model> CreateAsync (Model model);
         Task<Model> UpdateAsync (Model model);
         Task<bool> DeleteAsync (Guid Id);
         Task<Model> SelectAsync(Guid Id);
         Task<IEnumerable<Model>> SelectAsync();
    }
}