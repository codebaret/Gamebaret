using AutoMapper;
using AutoMapper.QueryableExtensions;
using Games.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Helpers
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get { return 8; } }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IQueryable<T> Results { get; set; }

        public PagedResult()
        {
        }
        
    }

    public static class Paginate
    {
        public static PagedResult<U> GetPaged<T, U>(this IQueryable<T> query, int page, IAutoMapper _mapper) where U : class
        {
            var result = new PagedResult<U>();
            result.CurrentPage = page;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / result.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * result.PageSize;
            var r = query.Skip(skip).Take(result.PageSize);
            result.Results = _mapper.Map<T, U>(r);
            return result;
        }
    }

    
}
