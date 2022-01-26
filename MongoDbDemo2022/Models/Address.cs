using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDemo2022.Models
{
    [BsonIgnoreExtraElements]
    internal class Address
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Municipality { get; set; }
        public int ZipCode { get; set; }
    }
}
