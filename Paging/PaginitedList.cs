using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaProjectFinalProject.Paging
{
    public class PaginitedList<T> :List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public PaginitedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage
        {
            get
            {
                return this.PageIndex > 1;
            }
        }
        public bool HasNextPage
        {
            get
            {
                return this.PageIndex < TotalPages;
            }
        }
        public static PaginitedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginitedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
