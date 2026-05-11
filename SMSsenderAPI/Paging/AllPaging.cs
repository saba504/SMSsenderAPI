using Microsoft.Extensions.Primitives;

namespace SMSsenderAPI.Paging
{
    public class AllPaging<T>
    {
        public IEnumerable<T> Items { get; private set; }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public long TotalPages { get; private set; }
        public long TotalCount { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public AllPaging(IEnumerable<T> items, long count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = PageSize;
            this.TotalPages = (long)Math.Ceiling(count / (double)pageSize);
            this.TotalCount = count;
            this.Items = items;

        }

        public static Task<AllPaging<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return Task.Run(() => new AllPaging<T>(items, count, pageIndex, pageSize));
        }


        public Dictionary<string, StringValues> GetParams() => new()
        {
            [nameof(PageIndex)] = PageIndex.ToString(),
            [nameof(PageSize)] = PageSize.ToString(),


            [nameof(TotalPages)] = TotalPages.ToString(),
            [nameof(TotalCount)] = TotalCount.ToString(),


            [nameof(HasPreviousPage)] = HasPreviousPage.ToString(),
            [nameof(HasPreviousPage)] = HasPreviousPage.ToString(),

        };
    }
}
