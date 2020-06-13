using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vega2.Models;

namespace Vega2.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Sorter<T>(this IQueryable<T> query, IQueryObjects queryobj, 
            Dictionary<string, Expression<Func<T, object>>> colsmap)//'this' type varialbles have to be first
        {
            //default sorting is by id {done by EF}
            if (String.IsNullOrWhiteSpace(queryobj.SortBy)||!colsmap.ContainsKey(queryobj.SortBy))
                return query;

            if (queryobj.IsAsce == true)
                query = query.OrderBy(colsmap[queryobj.SortBy]);
            //eg. if sprtby=make then expression=>colsmap[make]==>colsmap[v=>v.model.make.name]
            else
                query = query.OrderByDescending(colsmap[queryobj.SortBy]);
            return query;


            /*
                in sorter function the type of function/return type is IQueryable
                and the paramters are generic with a 'this' type varialble
                Due to these reasons any IQeryable variable will be able to directly call Sorter static method
             */
        }

        public static IQueryable<T> ApplyPager<T>(this IQueryable<T> query, IQueryObjects queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;
            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}
