using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    public class LinkApiController : Controller
    {
        private readonly ILinkRepository repository;
        private int itemPerPage = 10;

        public LinkApiController(ILinkRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        // GET api/stops/{id}
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        //GET api/stops/?search={string}&page={int}
        [HttpGet("search")]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = repository
                    .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            return Ok(result);
        }

        // DELETE api/stops/{id}
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            repository.DeleteLink(id);
            return Ok();
        }

        //POST api/stops
        [HttpPost("create")]
        public IActionResult Post([FromBody]CreateLinkRequest createLink)
        {
            return Ok(repository.AddLink(createLink.GetLink()));
        }

        //POST api/stops
        /*[HttpPut]
        public IActionResult Put([FromBody]Link link)
        {
            return Ok(repository.Update(link));
        }*/
    }
}