using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEng
{
    public class Results
    {
        public string question { get; set; }

        public string correct_answer { get; set; }

        public List<string> incorrect_answers { get; set; }

    }
}
