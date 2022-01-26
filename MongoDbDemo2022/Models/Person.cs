using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDemo2022.Models
{
    [BsonIgnoreExtraElements]
    class Person
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [BsonElement("Home")]
        public Address HomeAddress { get; set; }
    }
}
