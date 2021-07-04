using System;
using System.IO;
using System.Net;
using System.Text;

namespace SimbirSoftTask.Services
{
    /// <summary>
    /// Сервис для загрузки файлов
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Загрузить страничку по url
        /// </summary>
        /// <param name="url"> адрес страницы </param>
        /// <returns> Путь к загруженному файлу </returns>
        public string LoadSiteContent(string url)
        {
            var client = new WebClient() { Encoding = Encoding.UTF8 };
            var path = Path.GetTempPath() + Guid.NewGuid().ToString();

            try
            {
                client.DownloadFile(url, path);
                return path;
            }
            catch (Exception)
            {

                return "";
            }
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="path"> Путь к файлу </param>
        public void RemoveFile(string path)
        {
            if(File.Exists(path))
                File.Delete(path);
        }
    }
}
