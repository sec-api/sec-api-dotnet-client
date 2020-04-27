namespace SecApi
{
    public class SicCode
    {
        /// <summary>
        /// SIC code
        /// </summary>
        public short Code { get; set; }
        
        /// <summary>
        /// name
        /// </summary>
        public string Industry { get; set; }
        
        /// <summary>
        /// Office
        /// </summary>
        public string Office { get; set; }
        
        /// <summary>
        /// Division
        /// </summary>
        public string Division { get; set; }
        
        /// <summary>
        /// Number of companies related to this SIC code
        /// </summary>
        public long Companies { get; set; }
    }
}