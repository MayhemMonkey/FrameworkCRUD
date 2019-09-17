using System.Threading.Tasks;

namespace Framework.CRUD.Repo
{
    public interface ICrudRepo<TO, TI>
    {
        Task<TO> Get(TI id);
        Task<TO> Update(TI id, TO obj);
        Task<bool> Delete(TI id);
        Task<TO> Insert(TO obj);
    }
}