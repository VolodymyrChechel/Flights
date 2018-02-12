using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.BLL.Util;
using Airline.Common.Enums;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class TimetableService : ITimetableService
    {
        private IUnitOfWork Database { get; set; }

        public TimetableService(IUnitOfWork uow)
        {
            Database = uow;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile(new BllMappingProfile());
            //});
        }

        public IEnumerable<TimetableDto> GetTimetables()
        {
            var timetables = Database.Timetables.GetAll().Include(x => x.Flight.From).Include(x => x.Flight.To);

            var timetableDtos = Mapper.Map<IEnumerable<Timetable>, IEnumerable<TimetableDto>>(timetables);
            return timetableDtos;
        }

        public IEnumerable<TimetableDto> GetSortedTimetables(SortOptions sortOption)
        {
            var timetables = Database.Timetables.GetAll().Include(x => x.Flight.From).Include(x => x.Flight.To);
            if (sortOption == SortOptions.DescendByNumeber)
            {
                timetables = timetables.OrderByDescending(x => x.Id);
            }
            else if (sortOption == SortOptions.AscendByNumber)
            {
                timetables = timetables.OrderBy(x => x.Id);
            }
            else if (sortOption == SortOptions.DescendByName)
            {
                timetables = timetables.OrderByDescending(x => x.Flight.Id);
            }
            else if (sortOption == SortOptions.AscendByNumber)
            {
                timetables = timetables.OrderBy(x => x.Flight.Id);
            }

            var timetableDtos = Mapper.Map<IEnumerable<Timetable>, IEnumerable<TimetableDto>>(timetables);
            return timetableDtos;
        }

        public IEnumerable<TimetableDto> GetSelectedTimetables(SelectionField selectionField, string selectKeyword)
        {
            var timetables = Database.Timetables.GetAll().Include(x => x.Flight.From).Include(x => x.Flight.To);

            if (selectionField == SelectionField.DeparturePlace)
            {
                timetables = timetables.Where(x => x.Flight.FromIATA.Contains(selectKeyword.ToUpper()));
            }
            else if (selectionField == SelectionField.ArrivingPlace)
            {
                timetables = timetables.Where(x => x.Flight.ToIATA.Contains(selectKeyword.ToUpper()));
            }
            else if (selectionField == SelectionField.Date)
            {
                var test = DateTime.ToString("MM/dd/yyyy");
                timetables = timetables.Where(x => x.DateTime.ToString("MM/dd/yyyy") == selectKeyword);
            }

            var timetableDtos = Mapper.Map<IEnumerable<Timetable>, IEnumerable<TimetableDto>>(timetables);
            return timetableDtos;
        }

        public IEnumerable<TimetableDto> GetSearchedTimetables(string searchWord)
        {
            var timetables = Database.Timetables.GetAll().Include(x => x.Flight.From).Include(x => x.Flight.To).Include(x => x.Flight)
                .Where(x => x.Flight.Id.ToUpper().Contains(searchWord.ToUpper()));

            var timetableDtos = Mapper.Map<IEnumerable<Timetable>, IEnumerable<TimetableDto>>(timetables);
            return timetableDtos;
        }

        public TimetableDto GetTimetable(object key)
        {
            if (key == null)
                throw new ArgumentException("Timetable's id was not set");

            var timetable = Database.Timetables.Get(key);

            if (timetable == null)
                throw new ArgumentException($"Timetable with key={key} was not found");

            var timetableDto = Mapper.Map<Timetable, TimetableDto>(timetable);

            return timetableDto;
        }

        public void CreateTimetable(TimetableDto timetableDto)
        {
            if (timetableDto == null)
                throw new ArgumentException("Timetable's object was not passed");

            var timetable = Mapper.Map<TimetableDto, Timetable>(timetableDto);

            Database.Timetables.Create(timetable);
            Database.Save();
        }

        public void EditTimetable(TimetableDto timetableDto)
        {
            if (timetableDto == null)
                throw new ArgumentException("Timetable's object was not passed");

            var timetable = Mapper.Map<TimetableDto, Timetable>(timetableDto);

            Database.Timetables.Update(timetable);
            Database.Save();
        }

        public void DeleteTimetable(object key)
        {
            if (key == null)
                throw new ArgumentException("Timetable's id was not set");

            Database.Timetables.Delete(key);
            Database.Save();
        }

        public void ApproveTimetable(object key)
        {
            if (key == null)
                throw new ArgumentException("Timetable's id was not set");

            var timetable = Database.Timetables.Get(key);

            if (timetable == null)
                throw new ArgumentException("Timetable's object was not found");

            if (timetable.ApplicationStatus == ApplicationStatus.New)
                timetable.ApplicationStatus = ApplicationStatus.Accepted;

            Database.Timetables.Update(timetable);
            Database.Save();
        }
    }
}