namespace SecApi
{
    public sealed class FilingFile
    {
        /// <summary>
        /// File sequence number
        /// </summary>
        public int? Sequence { get; set; }
        
        /// <summary>
        /// Filename
        /// </summary>
        public string Filename { get; set; }
        
        /// <summary>
        /// File type
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// File description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// File size in bytes
        /// </summary>
        public long Size { get; set; }
    }
}