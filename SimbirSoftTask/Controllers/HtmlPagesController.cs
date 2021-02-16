using Microsoft.AspNetCore.Mvc;
using SimbirSoftTask.Dto;
using SimbirSoftTask.Services;

namespace SimbirSoftTask.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class HtmlPagesController : ControllerBase
    {
        private readonly IHtmlPagesService _pageService;

        public HtmlPagesController(IHtmlPagesService pageService)
        {
            _pageService = pageService;
        }

        [HttpPost("count-of-words")]
        public FileWordsDto GetWordsCountsByUrl(string url)
        {
            var dto = _pageService.GetWordsCountsByUrl(url);

            return dto;
        }
    }
}
