using System;
namespace Domain.Entities
{
    public class FileRepositoryModel
    {
        public int PKFile { get; set; }  
        public string FileName { get; set; }       
        public string SerialNumber { get; set; }   
        public int FKProcess { get; set; } 
        public string Source { get; set; }   
        public byte[] FileData { get; set; }
        public DateTime FileDateTime { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}