using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TourneyJSON
    {
        public List<List<string>> teams { get; set; }
        public List<List<List<int?>>> results { get; set; }

        public TourneyJSON()
        {
            teams = new List<List<string>>();
            results = new List<List<List<int?>>>();    
        }
    }
}