using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchApi.Models;
using SearchApi.RequestHelpers;

namespace SearchApi.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Post>>> SearchPosts([FromQuery] SearchParams searchParams)
        {
            var query = DB.PagedSearch<Post, Post>();

            query.Sort(x => x.Ascending(a => a.CreatedAt));

            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
            }

            query = searchParams.OrderBy switch
            {
                "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
                _ => query.Sort(x => x.Ascending(a => a.CreatedAt))
            };

            query = searchParams.FilterBy switch
            {
                "finished" => query.Sort(x => x.Descending(a => a.CreatedAt)),
                "endingSoon" => query.Sort(x => x.Descending(a => a.CreatedAt)),
                _ => query.Sort(x => x.Ascending(a => a.CreatedAt))
            };

            query.PageNumber(searchParams.PageNumber);
            query.PageSize(searchParams.PageSize);

            var result = await query.ExecuteAsync();

            return Ok(new
            {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });
        }
    }
}