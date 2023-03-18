using System;

namespace HashApi.Data.Entities
{
    public class Hash
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public string Sha1 { get; set; }
    }
}
