using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface ITimetableService
    {
        IEnumerable<TimetableDto> GetTimetables();
        TimetableDto GetTimetable(object key);
        void CreateTimetable(TimetableDto timetableDto);
        void EditTimetable(TimetableDto timetableDto);
        void DeleteTimetable(object key);

    }
}