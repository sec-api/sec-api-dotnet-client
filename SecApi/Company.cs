using System.Collections.Generic;

namespace SecApi
{
    public class Company
    {
        /// <summary>
        /// Company Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// SEC Central Index Key (CIK)
        /// </summary>
        public long Cik { get; set; }

        /// <summary>
        /// Central Index Key (CIK) in full size format with leading zeros
        /// </summary>
        public string FullCik { get; set; }

        /// <summary>
        /// Tickers
        /// </summary>
        public List<CompanyTicker> Tickers { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Standard Industrial Classification (SIC)
        /// </summary>
        public short? Sic { get; set; }
        
        /// <summary>
        /// Internal Revenue Service (IRS)
        /// </summary>
        public int? Irs { get; set; }
        
        /// <summary>
        /// Location state
        /// </summary>
        public string LocState { get; set; }

        /// <summary>
        /// Location state name
        /// </summary>
        public string LocStateName { get; set; }

        /// <summary>
        /// Incorporation state
        /// </summary>
        public string IncState { get; set; }

        /// <summary>
        /// Incorporation state name
        /// </summary>
        public string IncStateName { get; set; }

        /// <summary>
        /// Business address
        /// </summary>
        public Address BusinessAddr { get; set; }
        
        /// <summary>
        /// Mailing address
        /// </summary>
        public Address MailingAddr { get; set; }
    }
}