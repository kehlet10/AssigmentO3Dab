using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


namespace O3DAB
{
    public class Location
    {
        public ObjectId ID { get; set; }
        public string LocationAddress { get; set; }
        public string LocationName { get; set; }
        public int Capacity { get; set; }
        public List<Society> bookedBy { get; set; }
        public List<TimeSlot> TimeForBooking { get; set; }

        public Key key { get; set; }
    }
    public class TimeSlot
    {
        public ObjectId ID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }

    public class Key
    {
        public ObjectId ID { get; set; }
        public int LocationId { get; set; }
    }

    public class Member
    {

        public ObjectId ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CPR { get; set; }
    }

    public class Society
    {
        public ObjectId ID { get; set; }
        public int CVR { get; set; }
        public string Activity { get; set; }
        public int MemberCount { get; set; }

        public List<Member> Members { get; set; }
        public int ChairmanId  { get; set; }
    }

   
}
