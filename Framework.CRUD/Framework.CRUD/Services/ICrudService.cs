using System.Threading.Tasks;

namespace Framework.CRUD.Services
{
    public interface ICrudService<TO, TI>
    {
        Task<TO> Get(TI id);
        Task<TO> Update(TI id, TO obj);
        Task<bool> Delete(TI id);
        Task<TO> Insert(TO obj);
    }
}