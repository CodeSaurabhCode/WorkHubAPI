namespace WorkHubBackEndServices.Interfaces
{
    public class ItemSpecParams
    {
        private const int MaxPageSize =  20;

        public int PageIndex  { get; set; } = 1; 
        private int _pageSize = 6; 
        
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? CategoryId { get; set; }

        public string? Sort { get; set; }

        //private string? _search { get; set; }

        //public string? Search 
        //{ 
        //    get => _search;
        //    set => value.ToLower() ;
        //}

    }
}
