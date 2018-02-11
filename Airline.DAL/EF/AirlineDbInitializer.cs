using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airline.Common.Enums;
using Airline.DAL.Entities;

namespace Airline.DAL.EF
{
    public class AirlineDbInitializer : DropCreateDatabaseIfModelChanges<AirlineContext>
    {
        protected override void Seed(AirlineContext db)
        {
            db.Airports.Add(new Airport() {IATA = "KBP", City = "Kyiv", Name = "Boryspil International Airport"});
            db.Airports.Add(new Airport() {IATA = "CKC", City = "Cherkasy", Name = "Cherkasy International Airport" });
            db.Airports.Add(new Airport() {IATA = "CWC", City = "Chernivtsi", Name = "Chernivtsi International Airport" });
            db.Airports.Add(new Airport() {IATA = "DNK", City = "Dnipropetrovsk", Name = "Dnipropetrovsk International Airport" });
            db.Airports.Add(new Airport() {IATA = "IFO", City = "Ivano-Frankivsk", Name = "Ivano-Frankivsk International Airport" });
            db.Airports.Add(new Airport() {IATA = "HRK", City = "Kharkiv", Name = "Kharkiv International Airport" });
            db.Airports.Add(new Airport() {IATA = "KHE", City = "Kherson", Name = "Kherson International Airport" });
            db.Airports.Add(new Airport() {IATA = "IEV", City = "Kyiv", Name = "Kiev (Zhuliany) International Airport" });
            db.Airports.Add(new Airport() {IATA = "KWG", City = "Kryvyi Rih", Name = "Boryspil International Airport"});
            db.Airports.Add(new Airport() {IATA = "LWO", City = "Lviv", Name = "Lviv Danylo Halytskyi International Airport" });
            db.Airports.Add(new Airport() {IATA = "ODS", City = "Odessa", Name = "Odessa International Airport" });

            db.Flights.Add(new Flight {Id="KH007", FromIATA = "KBP", ToIATA = "HRK", PlannedDepartureTime = new TimeSpan(1,0,0), PlannedFlightTime = new TimeSpan(1,30,0)});
            db.Flights.Add(new Flight {Id="KH008", FromIATA = "KBP", ToIATA = "HRK", PlannedDepartureTime = new TimeSpan(10,0,0), PlannedFlightTime = new TimeSpan(1,30,0)});
            db.Flights.Add(new Flight {Id="KD019", FromIATA = "KBP", ToIATA = "DNK", PlannedDepartureTime = new TimeSpan(5,0,0), PlannedFlightTime = new TimeSpan(2,36,0)});
            db.Flights.Add(new Flight {Id="KD018", FromIATA = "DNK", ToIATA = "HRK", PlannedDepartureTime = new TimeSpan(15,45,0), PlannedFlightTime = new TimeSpan(2,36,0)});
            db.Flights.Add(new Flight {Id="LD345", FromIATA = "LWO", ToIATA = "DNK", PlannedDepartureTime = new TimeSpan(16,50,0), PlannedFlightTime = new TimeSpan(3,15,0)});
            db.Flights.Add(new Flight {Id="LD355", FromIATA = "DNK", ToIATA = "LWO", PlannedDepartureTime = new TimeSpan(3,30,0), PlannedFlightTime = new TimeSpan(3,15,0)});

            db.Workers.Add(new Worker() { Name = "Bohdan", Surname = "Shulyayev", BirthDate = DateTime.Parse("1963-3-18"), PhoneNumber = "+380931852367", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { Name = "Roman", Surname = "Shchors", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380503925682", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { Name = "Serhii", Surname = "Savaryn", BirthDate = DateTime.Parse("1961-9-6"), PhoneNumber = "+380939939184", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { Name = "Taras", Surname = "Yovenko", BirthDate = DateTime.Parse("1970-12-15"), PhoneNumber = "+380674198768", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { Name = "Oleksandr", Surname = "Zelenko", BirthDate = DateTime.Parse("1969-7-3"), PhoneNumber = "+380675520025", CrewmanType = CrewmanType.Captain });

            db.Workers.Add(new Worker() { Name = "Oleksii", Surname = "Bondarenko", BirthDate = DateTime.Parse("1974-3-5"), PhoneNumber = "+380634709089", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Yevhen", Surname = "Momot", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380994249474", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Yakiv", Surname = "Oliynyk", BirthDate = DateTime.Parse("1961-4-29"), PhoneNumber = "+380509131890", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Bohdan", Surname = "Stefanyk", BirthDate = DateTime.Parse("1973-12-2"), PhoneNumber = "+380992347336", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Anton", Surname = "Honcharenko", BirthDate = DateTime.Parse("1980-6-1"), PhoneNumber = "+380994726234", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Anatoli", Surname = "Kravchenko", BirthDate = DateTime.Parse("1974-2-9"), PhoneNumber = "+380679942809", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Vasyl", Surname = "Skliar", BirthDate = DateTime.Parse("1966-8-19"), PhoneNumber = "+380931007862", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { Name = "Leontiy", Surname = "Kovalenko", BirthDate = DateTime.Parse("1965-5-8"), PhoneNumber = "+380675087772", CrewmanType = CrewmanType.AircraftPilot });

            db.Workers.Add(new Worker() { Name = "Maksym", Surname = "Shevchuk", BirthDate = DateTime.Parse("1976-3-18"), PhoneNumber = "+380675980319", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { Name = "Vitaliy", Surname = "Kurylenko", BirthDate = DateTime.Parse("1986-12-11"), PhoneNumber = "+380678289922", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { Name = "Semen", Surname = "Lukyanenko", BirthDate = DateTime.Parse("1969-9-14 "), PhoneNumber = "+380500485314", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { Name = "Pavlo", Surname = "Petrenko", BirthDate = DateTime.Parse("1986-5-24"), PhoneNumber = "+380636394772", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { Name = "Denys", Surname = "Melnik", BirthDate = DateTime.Parse("1985-7-3"), PhoneNumber = "+380998781812", CrewmanType = CrewmanType.NavigatorOfficer });

            db.Workers.Add(new Worker() { Name = "Viktor", Surname = "Andruko", BirthDate = DateTime.Parse("1972-12-26"), PhoneNumber = "+380679592459", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { Name = "Roman", Surname = "Dudnik", BirthDate = DateTime.Parse("1976-2-25"), PhoneNumber = "+380508116140", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { Name = "Serhii", Surname = "Chulkov", BirthDate = DateTime.Parse("1982-8-6"), PhoneNumber = "+380505182165", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { Name = "Stepan", Surname = "Avramenko", BirthDate = DateTime.Parse("1980-12-21"), PhoneNumber = "+380671767544", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { Name = "Yakiv", Surname = "Savaryn", BirthDate = DateTime.Parse("1974-10-24"), PhoneNumber = "+380962085632", CrewmanType = CrewmanType.RadioOperator });

            db.Workers.Add(new Worker() { Name = "Zoya", Surname = "Holub", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380931892850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Valentyna", Surname = "Dudnik", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935892850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Valentyna", Surname = "Hryshchuk", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380936592850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Alla", Surname = "Dzubenko", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935856850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Kseniya", Surname = "Yevdokymenko", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935912850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Liliya", Surname = "Gura", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935897750", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Alla", Surname = "Kovalenko", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935152850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Inna", Surname = "Lukyanenko", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935896650", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Veronika", Surname = "Danilenko", BirthDate = DateTime.Parse("1993-3-3"), PhoneNumber = "+380632237795", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Larysa", Surname = "Holub", BirthDate = DateTime.Parse("1990-8-5"), PhoneNumber = "+380963273067", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Zoya", Surname = "Vovk", BirthDate = DateTime.Parse("1989-6-15"), PhoneNumber = "+380501710565", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Anna", Surname = "Biletskyy", BirthDate = DateTime.Parse("1986-5-17"), PhoneNumber = "+380965795062", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Anna", Surname = "Boyko", BirthDate = DateTime.Parse("1991-5-26"), PhoneNumber = "+380996732806", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Liliya", Surname = "Hryshchuk", BirthDate = DateTime.Parse("1990-4-16"), PhoneNumber = "+380500444989", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Anna", Surname = "Yevdokymenko", BirthDate = DateTime.Parse("1987-12-3"), PhoneNumber = "+380995883841", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Valentyna", Surname = "Dzubenko", BirthDate = DateTime.Parse("1993-1-25"), PhoneNumber = "+380938686178", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Anastasiya", Surname = "Gura", BirthDate = DateTime.Parse("1988-12-26"), PhoneNumber = "+380671988191", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Kseniya", Surname = "Palinchak", BirthDate = DateTime.Parse("1986-5-29"), PhoneNumber = "+380638759273", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Vira", Surname = "Orlyk", BirthDate = DateTime.Parse("1988-4-16"), PhoneNumber = "+380990082474", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Inna", Surname = "Rodchenko", BirthDate = DateTime.Parse("1992-8-20"), PhoneNumber = "+380960066654", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Liliya", Surname = "Sokulska", BirthDate = DateTime.Parse("1994-8-30"), PhoneNumber = "+380932830762", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Inna", Surname = "Tymoshenko", BirthDate = DateTime.Parse("1992-3-16"), PhoneNumber = "+380990921024", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Kseniya", Surname = "Chachula", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380679904506", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Anna", Surname = "Vovk", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380679704500", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Kseniya", Surname = "Holub", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380679904500", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Vira", Surname = "Danilenko", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380674404540", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { Name = "Alla", Surname = "Avramenko", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380679104500", CrewmanType = CrewmanType.AirHostess });

            var boeing = db.Planes.Add(new Plane() { Name = "Boeing 737-800", Capacity = 150, Velocity = 900 });
            var airbus = db.Planes.Add(new Plane() { Name = "Airbus А330-200", Capacity = 240, Velocity = 900 });
            var sukhoi = db.Planes.Add(new Plane() { Name = "Sukhoi SuperJet 100", Capacity = 85, Velocity = 840 });

            var crew1 = db.CrewCompositions.Add(new CrewComposition
            {
                AircraftPilotAmount = 2,
                AirHostessAmount = 5,
                CaptainAmount = 1,
                NavigatorOfficerAmount = 1,
                RadioOperatorAmount = 1
            });
            var crew2 = db.CrewCompositions.Add(new CrewComposition
            {
                AircraftPilotAmount = 3,
                AirHostessAmount = 7,
                CaptainAmount = 1,
                NavigatorOfficerAmount = 1,
                RadioOperatorAmount = 1
            });

            db.FlightParks.Add(new FlightPark() {Name = "Korolev", Plane = boeing, CrewComposition = crew2});
            db.FlightParks.Add(new FlightPark() {Name = "Sikorsky", Plane = airbus, CrewComposition = crew2});
            db.FlightParks.Add(new FlightPark() {Name = "Shevchenko", Plane = airbus, CrewComposition = crew1});
            db.FlightParks.Add(new FlightPark() {Name = "Antonov", Plane = sukhoi, CrewComposition = crew1 });
            db.FlightParks.Add(new FlightPark() {Name = "Paton", Plane = sukhoi, CrewComposition = crew1 });
            db.FlightParks.Add(new FlightPark() {Name = "Glushko ", Plane = sukhoi, CrewComposition = crew1 });
            db.FlightParks.Add(new FlightPark() {Name = "Dovzhenko", Plane = sukhoi, CrewComposition = crew1 });

            db.SaveChanges();
        }
    }
}