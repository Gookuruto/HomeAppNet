using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.DataFilters
{
    public class FilteredDataResult<T>
    {

        public List<T> FilteredList { get; set; }
        public int CurrentPage { get; set; }
        public int MaxPages { get; set; }

        public FilteredDataResult(List<T> filteredList, int currentPage = default,int maxPage = default)
        {
            FilteredList = filteredList;
            CurrentPage = currentPage;
            MaxPages = maxPage;
        }

    }
}
