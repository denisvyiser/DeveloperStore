using DevStore.Api.Core.ResponseModels;
using DevStore.Core.Models.Pagination;

namespace DevStore.Application.Core.Interfaces
{
    public interface IAppServiceBase<TView> where TView : ViewBase
    {
        Task<TView> Save(TView model);
        Task Remove(Guid id);

        Task<TView> Update(TView model);

        Task<PaginatedList<TView>> GetPaginated(Dictionary<string, string> queryParams);
        Task<TView> Get(Guid id);
    }
}
