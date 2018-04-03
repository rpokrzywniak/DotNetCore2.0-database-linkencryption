using System;
using System.Collections.Generic;
using System.Linq;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private readonly LinkDbContext _links;
        private readonly IHashDecoder _hashDecoder;
        private readonly IHashEncoder _hashEncoder;

        public LinkRepository(IHashDecoder hashDecoder, IHashEncoder hashEncoder, LinkDbContext context)
        {
            _links = context;
            _hashDecoder = hashDecoder;
            _hashEncoder = hashEncoder;
        }

        public List<Link> GetLinks()
        {
            return _links.Links.ToList();
        }

        public Link AddLink(Link link)
        {
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            // no hash collision check
            // can generate same hash for different links
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _links.Links.Add(link);
            _links.SaveChanges();
            return link;
        }

        public void DeleteLink(int linkId)
        {
            var itemToRemove = _links.Links.SingleOrDefault(element => element.Id == linkId);
            _links.Links.Remove(itemToRemove);
            _links.SaveChanges();
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _links.Links.SingleOrDefault(link => link.Id == id).FullUrl;
        }

        public (IEnumerable<Link>, int) Get(string search, int skip)
        {
            var linksFilteredByFullUrl = search != null ? _links.Links
            .Where(x => x.FullUrl.ToLower()
            .Contains(search)) : _links.Links;
            var linksCount = linksFilteredByFullUrl.Count();

            var paginatedLink = linksFilteredByFullUrl
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(20);

            return (paginatedLink, linksCount);
        }
        public Link Get(int id)
        {
            return _links.Links.Find(id);
        }

    }
}