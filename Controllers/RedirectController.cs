using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Interfaces;

namespace WebDevHomework.Controllers
{
    public class RedirectController : Controller
    {
        private readonly ILinkReader _linkReader;

        public RedirectController(ILinkReader linkReader)
        {
            _linkReader = linkReader;
        }

        [HttpGet("/{shortUrl}")]
        public IActionResult RedirectToUrl(string shortUrl)
        {
                var fullUrl = _linkReader.GetFullLink(shortUrl);
                return Redirect($"http://{fullUrl}");
        }
    }
}