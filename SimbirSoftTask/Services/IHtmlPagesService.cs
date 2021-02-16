using SimbirSoftTask.Dto;

namespace SimbirSoftTask.Services
{
    /// <summary>
    /// Сервис для чтения содержимого файла
    /// </summary>
    public interface IHtmlPagesService
    {
        /// <summary>
        /// Получить информацию о количестве уникальных слов на странице по URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        FileWordsDto GetWordsCountsByUrl(string url);
    }
}
