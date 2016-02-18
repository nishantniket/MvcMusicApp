using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicApp.Models
{
    public class Album
    {
        public Album()
        {
            this.songs = new HashSet<Song>();
        }
        public int Albumid {get;set;}
        public string name { get; set;}
        public virtual ICollection<Song> songs { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}