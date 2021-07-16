using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoodAnalyser
{ 
    class MoodAnalyse
    {
        string message;
        public MoodAnalyse(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            if (message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
    }
}
