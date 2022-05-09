using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Attributes;


namespace O3DAB
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string LocationName { get; set; }
        [BsonElement("Address")]
        public string LocationAddress { get; set; }
        [BsonElement("Capacity")]
        public int Capacity { get; set; }
        public List<Society> bookedBy { get; set; }
        public List<TimeSlot> TimeForBooking { get; set; }

        public Key key { get; set; }
    }
    public class TimeSlot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("From")]
        public DateTime From { get; set; }
        [BsonElement("To")]
        public DateTime To { get; set; }

    }

    public class Key
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("LocationId")]
        public ObjectId LocationId { get; set; }
    }

    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string MemberName { get; set; }
        [BsonElement("Address")]
        public string MemberAddress { get; set; }
        [BsonElement("CPR")]
        public string Cpr { get; set; }
    }

    public class Society
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("CVR")]
        public int CVR { get; set; }
        [BsonElement("Activity")]
        public string Activity { get; set; }
        [BsonElement("MemberCount")]
        public int MemberCount { get; set; }
        public List<Member> Members { get; set; }
        public int ChairmanId  { get; set; }
    }

   
}
