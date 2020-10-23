using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.DataFilters
{
    public class PageFilter
    {

        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public string? SearchString { get; set; }
        public string? SortPropName { get; set; }
        public bool SortDescending { get; set; }

        public PageFilter(int pageNumber, int itemsPerPage, string? sortPropName = null, bool sortDescending = false,string? searchString = null)
        {
            PageNumber = pageNumber;
            ItemsPerPage = itemsPerPage;
            SortPropName = sortPropName;
            SortDescending = sortDescending;
            SearchString = searchString;
        }
    }
}
