using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;

namespace O3DAB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var dbName = "O3MongoDbMunicipality";
            MongoClient client = null;
            MongoServer server = null;
            MongoDatabase db = null;
            //Client
            try { 
            
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

                //var Society = new BsonDocument
                //{
                //    {"_id", new ObjectId() },
                //    {"CVR", 1927573 },
                //    {"Activity", "Armlægning" },
                //    {"MemberCount", 2},
                //    {"MemberId's", [{}, {2} ]}
                //};

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

            Console.WriteLine("Database name:" + db.Name);
        }

    }

}
