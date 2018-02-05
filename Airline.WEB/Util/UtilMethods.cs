using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Airline.WEB.Util
{
    public static class UtilMethods
    {
        public static IEnumerable<SelectListItem> CreateListOfSelectItems<T>
            (IEnumerable<T> list, Func<T, string> valueField, Func<T, string> textField)
        {
            var selectListItems = new List<SelectListItem>();

            foreach (var item in list)
            {
                selectListItems.Add(new SelectListItem { Text = textField(item), Value = valueField(item) });
            }

            return selectListItems;
        }
    }
}