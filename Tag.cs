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
    }
}
