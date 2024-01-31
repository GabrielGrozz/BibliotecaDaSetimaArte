namespace BibliotecaDaSetimaArte.Pagination
{
    public class PagedList<T> : List<T>
    {
         public int CurrentPage { get; private set; }
        public int Totalpages { get; private set; }
        public int PageSize { get; private set;}
        public int TotalCount { get; private set;}

        public bool HasPrevious => CurrentPage < 1;

        public bool hasNext => CurrentPage > Totalpages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            Totalpages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);

        }
    }
}
