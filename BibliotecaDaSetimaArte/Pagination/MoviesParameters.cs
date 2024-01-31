namespace BibliotecaDaSetimaArte.Pagination
{
    public class MoviesParameters
    {
        const int MaxPageSize = 35;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 8;
        
        public int PageSize 
        {
            get 
            {
                return _pageSize; 
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
            } 
        }
    }
}
