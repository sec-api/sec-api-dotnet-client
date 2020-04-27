namespace SecApi
{
    public class CompanyTicker
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public string Exchange { get; set; }
        
        /// <summary>
        /// Ticker symbol
        /// </summary>
        public string Ticker { get; set; }
        
        /// <summary>
        /// Central Index Key
        /// </summary>
        public long Cik { get; set; }
        
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public string CompanyId { get; set; }
    }
}