﻿using MongoDB.Bson;
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
            Console.WriteLine("Establishing connection to MongoDB...");
            var service1 = new Service();
            Console.WriteLine("Seeding dummy data...");
            SeedData(service1);

            Console.WriteLine("\nQuery for Locations in the Municipality:");
            service1.LocationQuery();
            Console.WriteLine("\nQuery for all Societies in the Municipality:");
            service1.SocietyQuery();

            service1.PrintMemberBookings();
        }

        private static void SeedData(Service service)
        {
            #region LocationSeed
            Location location1 = new Location()
            {
                LocationName = "Shannon 003B",
                LocationAddress = "Finlandsgade 22",
                Capacity = 60,
                bookedBy = new List<Society>(),
                TimeForBooking = new List<TimeSlot>()
            };
            Location location2 = new Location()
            {
                LocationName = "Shannon 009A",
                LocationAddress = "Finlandsgade 22",
                Capacity = 120,
                bookedBy = new List<Society>(),
                TimeForBooking = new List<TimeSlot>()
            };
            Location location3 = new Location()
            {
                LocationName = "Shannon 003C",
                LocationAddress = "Finlandsgade 22",
                Capacity = 50,
                bookedBy = new List<Society>(),
                TimeForBooking = new List<TimeSlot>()
            };
            service.AddLocation(location1);
            service.AddLocation(location2);
            service.AddLocation(location3);
            #endregion
            #region MemberSeed
            Member Michelle = new Member()
            {
                MemberName = "Michelle",
                MemberAddress = "Precipice of Fate",
                Cpr = "1234567890"
            };
            Member Maggi = new Member()
            {
                MemberName = "Maggi",
                MemberAddress = "Randers",
                Cpr = "1092387456"
            };
            Member Daniela = new Member()
            {
                MemberName = "Daniela",
                MemberAddress = "Nordcenter Stor",
                Cpr = "5678912340"
            };
            Member Andrea = new Member()
            {
                MemberName = "Andrea",
                MemberAddress = "Åen",
                Cpr = "5678901234"
            };
            service.AddMember(Michelle);
            service.AddMember(Maggi);
            service.AddMember(Daniela);
            service.AddMember(Andrea);
            #endregion
            #region SocietySeed
            Society society1 = new Society()
            {
                Cvr = "32345678",
                Activity = "Armlægning",
                MemberCount = 2,
                ChairmanId = new ObjectId(),
                Members = new List<Member>()
            };
            Society society2 = new Society()
            {
                Cvr = "1213215",
                Activity = "Brolægning",
                MemberCount = 3,
                ChairmanId = new ObjectId(),
                Members = new List<Member>()

            };
            Society society3 = new Society()
            {
                Cvr = "5423734",
                Activity = "Fodbold",
                MemberCount = 22,
                ChairmanId = new ObjectId(),
                Members = new List<Member>()
            };
            service.AddSociety(society1);
            service.AddSociety(society2);
            service.AddSociety(society3);
            #endregion
            #region KeySeed
            Key key1 = new Key()
            {
                LocationId = service.GetLocation(location1.Id).Id,
                MemberId = service.GetMember(Michelle.Id).Id
            };
            service.AddKey(key1);
            #endregion
            #region TimeSlotSeed

            TimeSlot _8to9 = new TimeSlot()
            {
                From = new TimeSpan(08, 00, 00),
                To = new TimeSpan(09, 00, 00)
            };
            TimeSlot _9to10 = new TimeSlot()
            {
                From = new TimeSpan(09, 00, 00),
                To = new TimeSpan(10, 00, 00)
            };
            TimeSlot _10to11 = new TimeSlot()
            {
                From = new TimeSpan(09, 00, 00),
                To = new TimeSpan(10, 00, 00)
            };
            TimeSlot _11to12 = new TimeSlot()
            {
                From = new TimeSpan(11, 00, 00),
                To = new TimeSpan(12, 00, 00)
            };
            TimeSlot _12to13 = new TimeSlot()
            {
                From = new TimeSpan(12, 00, 00),
                To = new TimeSpan(13, 00, 00)
            };
            TimeSlot _13to14 = new TimeSlot()
            {
                From = new TimeSpan(13, 00, 00),
                To = new TimeSpan(14, 00, 00)
            };
            TimeSlot _14to15 = new TimeSlot()
            {
                From = new TimeSpan(14, 00, 00),
                To = new TimeSpan(15, 00, 00)
            };
            TimeSlot _15to16 = new TimeSlot()
            {
                From = new TimeSpan(15, 00, 00),
                To = new TimeSpan(16, 00, 00)
            };
            TimeSlot _16to17 = new TimeSlot()
            {
                From = new TimeSpan(16, 00, 00),
                To = new TimeSpan(17, 00, 00)
            };
            TimeSlot _17to18 = new TimeSlot()
            {
                From = new TimeSpan(17, 00, 00),
                To = new TimeSpan(18, 00, 00)
            };
            TimeSlot _18to19 = new TimeSlot()
            {
                From = new TimeSpan(18, 00, 00),
                To = new TimeSpan(19, 00, 00)
            };
            TimeSlot _19to20 = new TimeSlot()
            {
                From = new TimeSpan(19, 00, 00),
                To = new TimeSpan(20, 00, 00)
            };


            service.AddTimeSlot(_8to9);
            service.AddTimeSlot(_9to10);
            service.AddTimeSlot(_10to11);
            service.AddTimeSlot(_11to12);
            service.AddTimeSlot(_12to13);
            service.AddTimeSlot(_13to14);
            service.AddTimeSlot(_14to15);
            service.AddTimeSlot(_15to16);
            service.AddTimeSlot(_16to17);
            service.AddTimeSlot(_17to18);
            service.AddTimeSlot(_18to19);
            service.AddTimeSlot(_19to20);



            #endregion

            service.AddMemberToSociety(society2, Michelle);
            service.AddMemberToSociety(society3, Maggi);
            service.AddMemberToSociety(society2, Daniela);
            service.AddMemberToSociety(society1, Andrea);

            service.CreateBooking(location1, society1, _16to17);
            service.CreateBooking(location2, society2, _16to17);
            service.CreateBooking(location3, society3, _16to17);
            service.CreateBooking(location2, society1, _17to18);

            //Create booking that is unavailable
            service.CreateBooking(location1, society2, _16to17);

            //Should print 2 bookings
            //service.PrintBookings(society1);

            
        }
    }
}
