using System.Collections.Generic;

namespace SimbirSoftTask.Models
{
    public class CheckedSite
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Word> WordsInPage { get; set;}
    }
}
