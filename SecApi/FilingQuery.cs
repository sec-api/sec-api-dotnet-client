namespace SecApi
{
    public class FilingQuery
    {
        /// <summary>
        /// Filing Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Company Id
        /// </summary>
        public string CompanyId { get; set; }
        
        /// <summary>
        /// Filing form type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Accession number
        /// </summary>
        public string AccessionNo { get; set; }
    }
}