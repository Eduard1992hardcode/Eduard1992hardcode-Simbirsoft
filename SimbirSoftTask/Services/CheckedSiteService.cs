using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using SimbirSoftTask.Data;
using SimbirSoftTask.Dto;
using SimbirSoftTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirSoftTask.Services
{
    public class CheckedSiteService : ICheckedSiteService
    {
        private readonly DataContext _context;

        public CheckedSiteService(DataContext context)
        {
            _context = context;
        }

        public async Task AddSite(FileWordsDto wordsDto)
        {
            
            var site = await _context.CheckedSites
                .Include(w => w.WordsInPage)
                .FirstOrDefaultAsync(s => s.Url == wordsDto.URL)
                ?? new CheckedSite()
                {
                    Url = wordsDto.URL
                };

            if (site.WordsInPage?.Any() ?? false)
                 _context.Words.RemoveRange(site.WordsInPage);

            site.WordsInPage = CreateWords(wordsDto.Words);
            if (site.Id == default)
                await _context.CheckedSites.AddAsync(site);
            await _context.SaveChangesAsync();
        }

        public async Task<CheckedSite> GetSite(string url)
        {
            return await _context.CheckedSites.FirstOrDefaultAsync(s => s.Url == url);
        }

        private List<Word> CreateWords(List<WordDto> wordDtos)
        {
            var words = new List<Word>();
            foreach (var w in wordDtos)
            {
                words.Add(new Word { Name = w.Name, Count = w.Count });
            }
            return words;
        }
    }
}
