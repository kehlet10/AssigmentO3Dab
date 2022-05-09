using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3DAB.Services
{
    public class MemberService
    {
        public IMongoCollection<Member> _members;
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string MunicipalityDb = "MunicipalityDb";
        private readonly string mcollection = "Members";
        public MemberService()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(MunicipalityDb);
            _members = database.GetCollection<Member>(mcollection);
        }
        public Member AddMember(Member member)
        {
            _members.InsertOne(member);
            return member;
        }
    }
}
