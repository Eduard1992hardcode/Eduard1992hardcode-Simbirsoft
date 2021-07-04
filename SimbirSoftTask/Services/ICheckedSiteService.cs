using SimbirSoftTask.Dto;
using SimbirSoftTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirSoftTask.Services
{
    public interface ICheckedSiteService
    {
        Task<CheckedSite> GetSite(string url);
        Task AddSite(FileWordsDto wordsDto);  
    }
}
