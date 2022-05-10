using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using O3DAB.Services;

namespace O3DAB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service1 = new Service();
            SeedData(service1);
            {
                            


                /*
                var connectionString = "mongodb://localhost:27017";
                var dbName = "O3MongoDbMunicipality";
                MongoClient client = null;
                MongoServer server = null;
                MongoDatabase db = null;

                //Mapping classes for serialization
                BsonClassMap.RegisterClassMap<Location>();
                BsonClassMap.RegisterClassMap<TimeSlot>();
                BsonClassMap.RegisterClassMap<Key>();
                BsonClassMap.RegisterClassMap<Member>();
                BsonClassMap.RegisterClassMap<Society>();

                Console.WriteLine("We did it reddit");

                //Client
                try
                {

                    client = new MongoClient(connectionString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - Setting up client" + ex.Message);
                }
                //Server
                try
                {
                    server = client.GetServer();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - Setting up server" + ex.Message);
                }
                //Database
                try
                {
                    db = server.GetDatabase(dbName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - Setting up Database" + ex.Message);
                }
                {
                    
                    //Setting up collections - Members
                    try
                    {
                        var MemberCollection = db.GetCollection<BsonDocument>("Society");
                        var Andreas = new BsonDocument
                        {
                            {"_id", new ObjectId() },
                            {"Name", "Andreas" },
                            {"Address", "Mejlgade 102" },
                            {"CPR", 190297 }
                        };
                        var Daniel = new BsonDocument
                        {
                            {"_id", new ObjectId() },
                            {"Name", "Daniel" },
                            {"Address", "Mejlgade 103" },
                            {"CPR", 190397 }
                        };
                        var Maggi = new BsonDocument
                        {
                            {"_id", new ObjectId() },
                            {"Name", "Maggi" },
                            {"Address", "Mejlgade 104" },
                            {"CPR", 190497 }
                        };

                        var Michelle = new BsonDocument
                        {
                            {"_id", new ObjectId() },
                            {"Name", "Michelle" },
                            {"Address", "Mejlgade 105" },
                            {"CPR", 190597 }
                        };

                        var Society = new BsonDocument
                        {
                            {"_id", new ObjectId() },
                            {"CVR", 1927573 },
                            {"Activity", "Armlægning" },
                            {"MemberCount", 2},
                            {"MemberId's", [{}, {2} ]}
                        };

                    var Members = new List<BsonDocument>();
                        Members.Add(Andreas);
                        Members.Add(Daniel);
                        Members.Add(Maggi);
                        Members.Add(Michelle);

                        MemberCollection.InsertBatch(Members);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error - Setting up collection: " + ex.Message);
                    }

                    //Setting up collections - Society
                   //try
                   //{
                   //    var MemberCollection = db.GetCollection<BsonDocument>("Society");
                   //    var Society = new BsonDocument
                   //    {
                   //        {"_id", 1 },
                   //        {"CVR", 1927573 },
                   //        {"Activity", "Armlægning" },
                   //        {"MemberCount", 2},
                   //        {"MemberId's", [{1}, {2} ]}
                   //    };
                   //
                   //
                   //    var Members = new List<BsonDocument>();
                   //    Members.Add(Andreas);
                   //    Members.Add(Daniel);
                   //    Members.Add(Maggi);
                   //    Members.Add(Michelle);
                   //
                   //    MemberCollection.InsertBatch(Members);
                   //}
                   //catch (Exception ex)
                   //{
                   //    Console.WriteLine("Error - Setting up collection: " + ex.Message);
                   //}
                    
                }
                Console.WriteLine("Database name:" + db.Name);
            */
            }
            service1.LocationQuery();
            service1.SocietyQuery();
        }
        private static void SeedData(Service service)
        {
            #region LocationSeed
            Location location1 = new Location()
            {
                LocationName = "Shannon 003B",
                LocationAddress = "Finlandsgade 22",
                Capacity = 60,
            };
            Location location2 = new Location()
            {
                LocationName = "Shannon 009A",
                LocationAddress = "Finlandsgade 22",
                Capacity = 120,
            };
            Location location3 = new Location()
            {
                LocationName = "Shannon 003C",
                LocationAddress = "Finlandsgade 22",
                Capacity = 50,
            };
            service.AddLocation(location1);
            service.AddLocation(location2);
            service.AddLocation(location3);
            #endregion
            #region MemberSeed
            Member member1 = new Member()
            {
                MemberName = "Michelle",
                MemberAddress = "Precipice of Fate",
                Cpr = "1234567890"
            };
            Member member2 = new Member()
            {
                MemberName = "Maggi",
                MemberAddress = "Randers",
                Cpr = "1092387456"
            };
            Member member3 = new Member()
            {
                MemberName = "Daniela",
                MemberAddress = "Nordcenter Stor",
                Cpr = "5678912340"
            };
            Member member4 = new Member()
            {
                MemberName = "Andrea",
                MemberAddress = "Åen",
                Cpr = "5678901234"
            };
            service.AddMember(member1);
            service.AddMember(member2);
            service.AddMember(member3);
            service.AddMember(member4);
            Console.WriteLine(member1.MemberName);
            Console.WriteLine(location1.Id + " " + member1.Id);
            #endregion
            #region SocietySeed
            Society society1 = new Society()
            {
                Cvr = "32345678",
                Activity = "Armlægning",
                MemberCount = 2,
                ChairmanId = service.GetMember(member1.Id).Id
            };
            Society society2 = new Society()
            {
                Cvr = "1213215",
                Activity = "Brolægning",
                MemberCount = 3,
                ChairmanId = service.GetMember(member2.Id).Id

            };
            Society society3 = new Society()
            {
                Cvr = "5423734",
                Activity = "Fodbold",
                MemberCount = 22,
                ChairmanId = service.GetMember(member3.Id).Id
            };
            service.AddSociety(society1);
            service.AddSociety(society2);
            service.AddSociety(society3);
            #endregion
            #region KeySeed
            Key key1 = new Key()
            {
                LocationId = service.GetLocation(location1.Id).Id,
                MemberId = service.GetMember(member1.Id).Id
            };
            service.AddKey(key1);
            Console.WriteLine(key1.LocationId + " " + key1.MemberId);
            #endregion
        }
    }
}
