using System;
using System.Collections.Generic;

namespace SecApi
{
    public class Filing
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
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Company Central Index Key (CIK) 
        /// </summary>
        public long CompanyCik { get; set; }

        /// <summary>
        /// Central Index Key (CIK) in full size format with leading zeros
        /// </summary>
        public string CompanyFullCik { get; set; }

        /// <summary>
        /// Filing form type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File number
        /// </summary>
        public string FileNo { get; set; }

        /// <summary>
        /// Film number
        /// </summary>
        public string FilmNo { get; set; }

        /// <summary>
        /// Accession number
        /// </summary>
        public string AccessionNo { get; set; }

        /// <summary>
        /// Act
        /// </summary>
        public string Act { get; set; }

        /// <summary>
        /// Is amend
        /// </summary>
        public bool Amend { get; set; }

        /// <summary>
        /// Is cover
        /// </summary>
        public bool Cover { get; set; }

        /// <summary>
        /// Is paper
        /// </summary>
        public bool Paper { get; set; }

        /// <summary>
        /// Filing date
        /// </summary>
        public DateTime FilingDate { get; set; }

        /// <summary>
        /// Filing acceptance date
        /// </summary>
        public DateTime? AcceptanceDate { get; set; }

        /// <summary>
        /// Period of report
        /// </summary>
        public DateTime? PeriodOfReport { get; set; }

        /// <summary>
        /// Number of files in the filing
        /// </summary>
        public int NumberOfFiles { get; set; }

        /// <summary>
        /// Filing files
        /// </summary>
        public List<FilingFile> Files { get; set; }
    }
}