using System;
using System.Collections.Generic;

namespace ResponseWrapper
{
    /// <summary>
    /// Pagination Result wrapper class of type <typeparamref name="T"/> which inherit <see cref="Result"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedResult<T> : Result
    {
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; }

        public PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            Messages = messages;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        /// <summary>
        /// Paginated Result method used when request failed and expects list of custom <paramref name="messages"/> indicating those failures.
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        /// <summary>
        /// Paginated Result method used when request succeeded.
        /// </summary>
        /// <param name="data">Data to be paged</param>
        /// <param name="count">Count of Data objects</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size for elements to be displyed.</param>
        /// <returns></returns>
        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
