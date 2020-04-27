namespace SecApi
{
    public class FilingSort
    {
        /// <summary>
        /// Sort field
        /// </summary>
        public FilingSortField Field { get; set; }
        
        /// <summary>
        /// Sort direction
        /// </summary>
        public SortDirection? Direction { get; set; }
    }
}