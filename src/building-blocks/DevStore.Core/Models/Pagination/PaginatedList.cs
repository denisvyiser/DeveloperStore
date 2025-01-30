using Newtonsoft.Json;

namespace DevStore.Core.Models.Pagination
{
    public class PaginatedList<TEntity>
    {
        public PaginatedList()
        { }
        public PaginatedList(IQueryable<TEntity> entities, PaginationObject pagination)
        {
            Page = pagination.Page;

            TotalItem = pagination.TotalItem;
            CurrentPage = pagination.Page.Index;
            PageSize = pagination.Page.Quantity;
            TotalPages = (int)Math.Ceiling(TotalItem / (double)pagination.Page.Quantity);
            Data = entities.ToList();
        }

        public IList<TEntity> Data { get; set; }
        public int TotalItem { get; set; }
        public int CurrentPage { get; set; }

        [JsonIgnore]
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        
        [JsonIgnore]
        public int FirstRecordOnPage
        {
            get { return TotalItem > 0 ? (CurrentPage - 1) * PageSize + 1 : 0; }
        }

        [JsonIgnore]
        public int LastRecordOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalItem); }
        }

        [JsonIgnore]
        public Page Page { get; set; }

    }
}

