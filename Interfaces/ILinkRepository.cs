using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
        public interface ILinkRepository
        {
            List<Link> GetLinks();
            Link AddLink(Link link);
            void DeleteLink(int linkId);
            string GetFullLink(string shortLink);
            (IEnumerable<Link>, int) Get(string search, int skip);
            Link Get(int Id);
    }
}
