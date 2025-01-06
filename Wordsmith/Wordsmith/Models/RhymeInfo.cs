using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordsmith.Models
{
    public class RhymeInfo
    {
        public string? word { get; set; }
        public int freq { get; set; }
        public int score { get; set; }
        public string? flags { get; set; }
        public string? syllables { get; set; }
    }
}
