using HtmlAgilityPack;
using SimbirSoftTask.Dto;
using System;
using System.Collections.Generic;

namespace SimbirSoftTask.Services
{
    /// <summary>
    /// Сервис для чтения содержимого файла
    /// </summary>
    public class HtmlPagesService : IHtmlPagesService
    {
        private readonly IFileService _fileService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fileService"></param>
        public HtmlPagesService(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Получить информацию о количестве уникальных слов на странице по URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public FileWordsDto GetWordsCountsByUrl(string url)
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

            return new FileWordsDto()
            {
                URL = url,
                Words = wordsCount
            };
        }
    }
}
