namespace SimbirSoftTask.Services
{
    /// <summary>
    /// Сервис для загрузки файлов
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Загрузить страничку по url
        /// </summary>
        /// <param name="url"> адрес страницы </param>
        /// <returns> Путь к загруженному файлу </returns>
        string LoadSiteContent(string url);

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="path"> Путь к файлу </param>
        void RemoveFile(string path);
    }
}
