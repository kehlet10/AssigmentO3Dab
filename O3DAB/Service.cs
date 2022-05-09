using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using O3DAB.Classes;
using MongoDB.Driver;

namespace O3DAB.Service
{
    internal class Service
    {   private IMongoCollection<Location> _location;
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string locationDB = "LocationDB";
        private readonly string collection = "Location";

        public Service()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(locationDB);
            _location = database.GetCollection<Location>(collection);
        }
    }
}
