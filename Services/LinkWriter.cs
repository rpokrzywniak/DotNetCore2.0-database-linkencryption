using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkWriter : ILinkWriter
    {
        private readonly ILinkRepository _linkRepository;

        public LinkWriter(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        public void AddLink(Link link)
        {
            _linkRepository.AddLink(link);
        }

        public void DeleteLink(int linkId)
        {
            _linkRepository.DeleteLink(linkId);
        }
    }
}