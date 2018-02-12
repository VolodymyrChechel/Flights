using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;
using Airline.Common.Enums;

namespace Airline.BLL.Interfaces
{
    public interface ITimetableService
    {
        IEnumerable<TimetableDto> GetTimetables();
        IEnumerable<TimetableDto> GetSortedTimetables(SortOptions sortOption);
        IEnumerable<TimetableDto> GetSelectedTimetables(SelectionField selectionField, string selectKeyword);
        IEnumerable<TimetableDto> GetSearchedTimetables(string searchWord);
        TimetableDto GetTimetable(object key);
        void CreateTimetable(TimetableDto timetableDto);
        void EditTimetable(TimetableDto timetableDto);
        void DeleteTimetable(object key);
        void ApproveTimetable(object key);

    }
}