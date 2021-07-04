using HtmlAgilityPack;
using SimbirSoftTask.Data;
using SimbirSoftTask.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimbirSoftTask.Services
{
    /// <summary>
    /// Сервис для чтения содержимого файла
    /// </summary>
    public class HtmlPagesService : IHtmlPagesService
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;
        private readonly ICheckedSiteService _checkedSiteService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fileService"></param>
        public HtmlPagesService(IFileService fileService, ICheckedSiteService checkedSiteService)
        {
            _fileService = fileService;
            _checkedSiteService = checkedSiteService;
        }

        /// <summary>
        /// Получить информацию о количестве уникальных слов на странице по URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<FileWordsDto> GetWordsCountsByUrl(string url)
        {
            var path = _fileService.LoadSiteContent(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(path);

            var text = htmlDoc.DocumentNode.InnerText;


            var words = text.Split(' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t');

            var wordsCount = new Dictionary<string, int>();
            
            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                    continue;

                if (!wordsCount.ContainsKey(word))
                           wordsCount.Add(word, 1);

                else
                    wordsCount[word] += 1;
            }

            _fileService.RemoveFile(path);

            var dto = new FileWordsDto()
            {
                URL = url,
                Words = CreateWordDtos(wordsCount)
            };
            await _checkedSiteService.AddSite(dto);
            return dto;
        }

        private List<WordDto> CreateWordDtos(Dictionary<string, int> wordsCount)
        {
            var words = new List<WordDto>();
            foreach (var w in wordsCount)
            {
                words.Add(new WordDto {Name = w.Key, Count = w.Value });
            }
            return words;
        }
    }
}
