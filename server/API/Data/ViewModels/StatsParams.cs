namespace API.Data.ViewModels
{
    /// <summary>
    /// Represents the parameters that come from the user request.
    /// </summary>
    public class StatsParams
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 20;
        private string _search;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int PageIndex { get; set; } = 1;
        public string Sort { get; set; }

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}