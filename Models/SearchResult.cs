using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDevHomework.Models
{
    public class SearchResult
    {
        public IEnumerable<LinkResult> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }

        public int MaxPage { get; set; }
    }

    public class LinkResult
    {
        public LinkResult(Link link)
        {
            Id = link.Id;
            FullUrl = link.FullUrl;
            ShortUrl = link.ShortUrl;
        }
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }

    }
}