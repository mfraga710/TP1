using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Tag
    {
        public int id { get; set; }
        public string palabra { get; set; }
        public List<Post> posts { get; set; }

        static int idTag = 0;
        public Tag(string palabra)
        {
            id = idTag++;
            this.palabra = palabra;
            posts = new List<Post>();
        }
        public Tag(int id,string palabra, List<Post> posts)
        {
            this.id = id;
            this.palabra = palabra;
            this.posts = posts;
        }
    }
}
