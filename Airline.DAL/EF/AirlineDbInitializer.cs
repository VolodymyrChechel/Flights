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

            db.Workers.Add(new Worker() { FirstName = "Volodymyr", Surrname = "Shulyayev", BirthDate = DateTime.Parse("1963-3-18"), PhoneNumber = "+380931852367", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { FirstName = "Roman", Surrname = "Shchors", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380503925682", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { FirstName = "Serhii", Surrname = "Savaryn", BirthDate = DateTime.Parse("1961-9-6"), PhoneNumber = "+380939939184", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { FirstName = "Taras", Surrname = "Yovenko", BirthDate = DateTime.Parse("1970-12-15"), PhoneNumber = "+380674198768", CrewmanType = CrewmanType.Captain });
            db.Workers.Add(new Worker() { FirstName = "Oleksandr", Surrname = "Zelenko", BirthDate = DateTime.Parse("1969-7-3"), PhoneNumber = "+380675520025", CrewmanType = CrewmanType.Captain });

            db.Workers.Add(new Worker() { FirstName = "Oleksii", Surrname = "Bondarenko", BirthDate = DateTime.Parse("1974-3-5"), PhoneNumber = "+380634709089", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Yevhen", Surrname = "Momot", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380994249474", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Yakiv", Surrname = "Oliynyk", BirthDate = DateTime.Parse("1961-4-29"), PhoneNumber = "+380509131890", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Bohdan", Surrname = "Stefanyk", BirthDate = DateTime.Parse("1973-12-2"), PhoneNumber = "+380992347336", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Anton", Surrname = "Honcharenko", BirthDate = DateTime.Parse("1980-6-1"), PhoneNumber = "+380994726234", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Anatoli", Surrname = "Kravchenko", BirthDate = DateTime.Parse("1974-2-9"), PhoneNumber = "+380679942809", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Vasyl", Surrname = "Skliar", BirthDate = DateTime.Parse("1966-8-19"), PhoneNumber = "+380931007862", CrewmanType = CrewmanType.AircraftPilot });
            db.Workers.Add(new Worker() { FirstName = "Leontiy", Surrname = "Kovalenko", BirthDate = DateTime.Parse("1965-5-8"), PhoneNumber = "+380675087772", CrewmanType = CrewmanType.AircraftPilot });

            db.Workers.Add(new Worker() { FirstName = "Maksym", Surrname = "Shevchuk", BirthDate = DateTime.Parse("1976-3-18"), PhoneNumber = "+380675980319", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { FirstName = "Vitaliy", Surrname = "Kurylenko", BirthDate = DateTime.Parse("1986-12-11"), PhoneNumber = "+380678289922", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { FirstName = "Semen", Surrname = "Lukyanenko", BirthDate = DateTime.Parse("1969-9-14 "), PhoneNumber = "+380500485314", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { FirstName = "Pavlo", Surrname = "Petrenko", BirthDate = DateTime.Parse("1986-5-24"), PhoneNumber = "+380636394772", CrewmanType = CrewmanType.NavigatorOfficer });
            db.Workers.Add(new Worker() { FirstName = "Denys", Surrname = "Melnik", BirthDate = DateTime.Parse("1985-7-3"), PhoneNumber = "+380998781812", CrewmanType = CrewmanType.NavigatorOfficer });

            db.Workers.Add(new Worker() { FirstName = "Viktor", Surrname = "Andruko", BirthDate = DateTime.Parse("1972-12-26"), PhoneNumber = "+380679592459", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { FirstName = "Roman", Surrname = "Dudnik", BirthDate = DateTime.Parse("1976-2-25"), PhoneNumber = "+380508116140", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { FirstName = "Serhii", Surrname = "Chulkov", BirthDate = DateTime.Parse("1982-8-6"), PhoneNumber = "+380505182165", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { FirstName = "Stepan", Surrname = "Avramenko", BirthDate = DateTime.Parse("1980-12-21"), PhoneNumber = "+380671767544", CrewmanType = CrewmanType.RadioOperator });
            db.Workers.Add(new Worker() { FirstName = "Yakiv", Surrname = "Savaryn", BirthDate = DateTime.Parse("1974-10-24"), PhoneNumber = "+380962085632", CrewmanType = CrewmanType.RadioOperator });

            db.Workers.Add(new Worker() { FirstName = "Alla", Surrname = "Dudnik", BirthDate = DateTime.Parse("1992-4-27"), PhoneNumber = "+380935892850", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Veronika", Surrname = "Danilenko", BirthDate = DateTime.Parse("1993-3-3"), PhoneNumber = "+380632237795", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Larysa", Surrname = "Holub", BirthDate = DateTime.Parse("1990-8-5"), PhoneNumber = "+380963273067", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Zoya", Surrname = "Vovk", BirthDate = DateTime.Parse("1989-6-15"), PhoneNumber = "+380501710565", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Anna", Surrname = "Biletskyy", BirthDate = DateTime.Parse("1986-5-17"), PhoneNumber = "+380965795062", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Anna", Surrname = "Boyko", BirthDate = DateTime.Parse("1991-5-26"), PhoneNumber = "+380996732806", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Liliya", Surrname = "Hryshchuk", BirthDate = DateTime.Parse("1990-4-16"), PhoneNumber = "+380500444989", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Anna", Surrname = "Yevdokymenko", BirthDate = DateTime.Parse("1987-12-3"), PhoneNumber = "+380995883841", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Valentyna", Surrname = "Dzubenko", BirthDate = DateTime.Parse("1993-1-25"), PhoneNumber = "+380938686178", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Anastasiya", Surrname = "Gura", BirthDate = DateTime.Parse("1988-12-26"), PhoneNumber = "+380671988191", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Kseniya", Surrname = "Palinchak", BirthDate = DateTime.Parse("1986-5-29"), PhoneNumber = "+380638759273", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Vira", Surrname = "Orlyk", BirthDate = DateTime.Parse("1988-4-16"), PhoneNumber = "+380990082474", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Inna", Surrname = "Rodchenko", BirthDate = DateTime.Parse("1992-8-20"), PhoneNumber = "+380960066654", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Liliya", Surrname = "Sokulska", BirthDate = DateTime.Parse("1994-8-30"), PhoneNumber = "+380932830762", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Inna", Surrname = "Tymoshenko", BirthDate = DateTime.Parse("1992-3-16"), PhoneNumber = "+380990921024", CrewmanType = CrewmanType.AirHostess });
            db.Workers.Add(new Worker() { FirstName = "Kseniya", Surrname = "Chachula", BirthDate = DateTime.Parse("1992-2-27"), PhoneNumber = "+380679904500", CrewmanType = CrewmanType.AirHostess });

            db.Planes.Add(new Plane() { Name = "Boeing 737-800", Capacity = 150, Velocity = 900 });
            db.Planes.Add(new Plane() { Name = "Airbus А330-200", Capacity = 240, Velocity = 900});
            db.Planes.Add(new Plane() { Name = "Sukhoi SuperJet 100", Capacity = 85, Velocity = 840});

            var boeing = db.Planes.First(x => x.Name.Contains("Boeing"));
            var airbus = db.Planes.First(x => x.Name.Contains("Airbus"));
            var sukhoi = db.Planes.First(x => x.Name.Contains("Sukhoi"));

            db.FlightParks.Add(new FlightPark() {Name = "Korolev", Plane = boeing});
            db.FlightParks.Add(new FlightPark() {Name = "Sikorsky", Plane = airbus});
            db.FlightParks.Add(new FlightPark() {Name = "Antonov", Plane = sukhoi});
            db.FlightParks.Add(new FlightPark() {Name = "Paton", Plane = sukhoi});
            db.FlightParks.Add(new FlightPark() {Name = "Glushko ", Plane = sukhoi});



            db.SaveChanges();
        }
    }
}