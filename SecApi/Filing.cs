using System;
using System.Collections.Generic;

namespace SecApi
{
    public enum FilingCikType
    {
        Filer = 0,
        FiledBy = 1,
        SubjectCompany = 2,
        ReportingOwner = 3,
        Issuer = 4,
        SerialCompany = 5,
        FiledFor = 6,
        Other = 7
    }
    
    public sealed class FilingCik
    {
        public long Cik { get; set; }
        public FilingCikType Type { get; set; }

        public FilingCik()
        {
        }

        public FilingCik(long cik, FilingCikType type)
        {
            Cik = cik;
            Type = type;
        }
    }

    public class Filing
    {
        /// <summary>
        /// Filing Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// CIKs of entities this filing is related to
        /// </summary>
        public HashSet<FilingCik> Ciks { get; set; }
        
        /// <summary>
        /// Company Central Index Key (CIK) 
        /// </summary>
        public long PrimaryCik { get; set; }

        /// <summary>
        /// Central Index Key (CIK) in full size format with leading zeros
        /// </summary>
        public string PrimaryFullCik { get; set; }

        /// <summary>
        /// Company name of the primary CIK
        /// </summary>
        public string CompanyName { get; set; }
        
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
        public long AccessionNo { get; set; }

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