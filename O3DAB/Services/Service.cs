using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace O3DAB.Services
{
    public class Service
    {   
        public IMongoCollection<Location> _locations;
        public IMongoCollection<Member> _members;
        public IMongoCollection<Society> _societies;
        public IMongoCollection<TimeSlot> _timeSlots;
        public IMongoCollection<Key> _keys;

        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string MunicipalityDb = "MunicipalityDb";
        private readonly string lcollection = "Locations";
        private readonly string mcollection = "Members";
        private readonly string scollection = "Societies";
        private readonly string tcollection = "Time Slots";
        private readonly string kcollection = "Keys";

        public Service()
        {
            var client = new MongoClient(connectionString);
            client.DropDatabase(MunicipalityDb);  // Drop Database
            var database = client.GetDatabase(MunicipalityDb);
            _locations = database.GetCollection<Location>(lcollection);
            _members = database.GetCollection<Member>(mcollection);
            _societies = database.GetCollection<Society>(scollection);
            _timeSlots = database.GetCollection<TimeSlot>(tcollection);
            _keys = database.GetCollection<Key>(kcollection);
        }

        public void setChairman(Society society, Member member)
        {
        
            Society newSociety = GetSociety(society.Id);

            newSociety.ChairmanId = member.Id;

            UpdateSociety(society.Id, newSociety);
        }

        public TimeSlot AddTimeSlot(TimeSlot timeSlot)
        {
            _timeSlots.InsertOne(timeSlot);
            return timeSlot;
        }
        public Location AddLocation(Location location)
        {
            _locations.InsertOne(location);
            return location;
        }
        public Location GetLocation(ObjectId id)
        {
            return _locations.Find<Location>(l => l.Id == id).FirstOrDefault();
        }
        public Society AddSociety(Society society)
        {
            _societies.InsertOne(society);
            return society;
        }
        public Society GetSociety(ObjectId id)
        {
            return _societies.Find<Society>(s => s.Id == id).FirstOrDefault();
        }
        public Member AddMember(Member member)
        {
            _members.InsertOne(member);
            return member;
        }
        public Member GetMember(ObjectId id)
        {
            return _members.Find<Member>(m => m.Id == id).FirstOrDefault();
        }
        public TimeSlot AddTimeSlots(TimeSlot timeSlot)
        {
            _timeSlots.InsertOne(timeSlot);
            return timeSlot;
        }
        public TimeSlot GetTimeSlot(ObjectId id)
        {
            return _timeSlots.Find<TimeSlot>(t => t.Id == id).FirstOrDefault();
        }
        public Key AddKey(Key key)
        {
            _keys.InsertOne(key);
            return key;
        }
        public Key GetKey(ObjectId id)
        {
            return _keys.Find<Key>(k => k.Id == id).FirstOrDefault();
        }
        public void LocationQuery()
        {
            List<Location> locations = new List<Location>();
            locations = _locations.Find(location => true).ToList();
            foreach(Location l in locations)
            {
                Console.WriteLine("Location Name: " + l.LocationName + ", Location Address: " + l.LocationAddress);
            }
        }
        public void SocietyQuery()
        {
            List<Society> societies = new List<Society>();
            societies = _societies.Find(societies => true).Sort("{Activity: 1}").ToList();
            foreach(Society s in societies)
            {
                Console.WriteLine("Society Activity: " + s.Activity + ", Society Cvr: " + s.Cvr + ", Chairman Id: " + s.ChairmanId + ", Member count: " + s.MemberCount );
            }
        }

        public void UpdateLocation(ObjectId id, Location newLocation)
        {
            _locations.ReplaceOne(l => l.Id == id, newLocation);
        }

        public void UpdateSociety(ObjectId id, Society newSociety)
        {
            _societies.ReplaceOne(s => s.Id == id, newSociety);
        }

        public void AddMemberToSociety(Society society, Member member)
        {

            Society newSociety = GetSociety(society.Id);

            Console.WriteLine("ALLEZ{0} :", society.Members.Count);
            if (newSociety.Members.Count == 0)
            {
                Console.WriteLine("Kaldt");
                setChairman(newSociety, member);
                newSociety.Members.Add(member);
                UpdateSociety(society.Id, newSociety);
            }
            else
            {
                newSociety.Members.Add(member);

                UpdateSociety(society.Id, newSociety);
            }


        }

        public void CreateBooking(Location location, Society society, TimeSlot TimeForBooking)
        {
            Location newLocation = GetLocation(location.Id);

            newLocation.bookedBy.Add(society);
            newLocation.TimeForBooking.Add(TimeForBooking);

            UpdateLocation(location.Id, newLocation);

        }
    }
}
