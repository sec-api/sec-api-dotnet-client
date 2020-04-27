namespace SecApi
{
    public class CompanyQuery
    {
        /// <summary>
        /// Company Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// SIC code
        /// </summary>
        public short? Sic { get; set; }
        
        /// <summary>
        /// CIK
        /// </summary>
        public long? Cik { get; set; }
        
        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }
    }
}