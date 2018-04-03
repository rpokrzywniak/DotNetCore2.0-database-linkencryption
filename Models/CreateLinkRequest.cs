namespace WebDevHomework.Models
{
    public class CreateLinkRequest
    {
        public string FullUrl { get; set; }

        public Link GetLink()
        {
            var link = new Link
            {
                FullUrl = this.FullUrl,
            };

            return link;
        }
    }
}