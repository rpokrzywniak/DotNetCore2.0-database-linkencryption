using System.Collections.Generic;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkReader : ILinkReader
    {
        private readonly ILinkRepository _linkRepository;

        public LinkReader(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public string GetFullLink(string shortLink)
        {
            return _linkRepository.GetFullLink(shortLink);
        }

        public List<Link> GetLinks()
        {
            return _linkRepository.GetLinks();
        }
    }
}