using System.Collections.Generic;

namespace SimbirSoftTask.Dto
{
    /// <summary>
    /// ДТО передачи информации о количестве уникальных слов ф HTML файле
    /// </summary>
    public class FileWordsDto
    {
        /// <summary>
        /// Адрес сайта
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Слова и их количество
        /// </summary>
        public Dictionary<string, int> Words { get; set; }
    }
}
