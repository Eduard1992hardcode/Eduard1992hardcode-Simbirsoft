using Microsoft.AspNetCore.Mvc;
using SimbirSoftTask.Dto;
using SimbirSoftTask.Services;
using System.Threading.Tasks;

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
        public async Task<FileWordsDto> GetWordsCountsByUrl(string url)
        {
            var dto = await _pageService.GetWordsCountsByUrl(url);

            return dto;
        }
    }
}
