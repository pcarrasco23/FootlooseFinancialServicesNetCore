using System.Collections.Generic;

namespace FootlooseFS.Models
{
    public class SearchParameters
    {
        public int PageNumber { get; set; }
        public int NumberRecordsPerPage { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public Dictionary<string, string> SearchCriteria { get; set; }
    }
}