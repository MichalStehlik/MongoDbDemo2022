using MongoDbDemo2022.Helpers;
using MongoDbDemo2022.Models;
using System;

namespace MongoDbDemo2022
{
    class Program
    {
        // https://www.nuget.org/packages/MongoDB.Driver/2.14.1?_src=template
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AddressBook"); // defaultní připojení k localhost:27017
            Address ad1 = new Address { Street = "Masarykova 3", Municipality = "Liberec", ZipCode = 46003};
            // db.Create("contacts", ad1);
            // Person me = new Person { Firstname = "Michal", Lastname = "Stehlík" };
            // db.Create("contacts", me);
            // Person semerad = new Person { Firstname = "Jaroslav", Lastname = "Semerád", HomeAddress = ad1 };
            // Person oscadal = new Person { Firstname = "Jaromír", Lastname = "Osčádal", HomeAddress = ad1 };
            // db.Create("contacts", oscadal);
            var recs1 = db.List<Person>("contacts");
            foreach(var r1 in recs1)
            {
                Console.WriteLine($"{r1.Id}: {r1.Firstname}");
            }
            db.Delete<Person>("contacts", new Guid("ada1d518-8987-465e-b2ec-7178286b3ed1"));
            var human = db.Read<Person>("contacts", new Guid("5404cd05-53bd-4f96-9854-6979f11daa9a"));
            human.HomeAddress = ad1;
            db.Upsert("contacts", new Guid("5404cd05-53bd-4f96-9854-6979f11daa9a"), human);
        }
    }
}
