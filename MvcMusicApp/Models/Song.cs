using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicApp.Models
{
    public class Song
    {
        public int Songid { get; set; }
        public string name { get; set; }
        public int length { get; set; }
    }
}