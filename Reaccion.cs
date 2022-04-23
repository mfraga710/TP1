using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Reaccion
    {
        public int id { get; set; }
        public string tipoReaccion { get; set; }
        public Post post { get;  set; }
        public Usuario usuario { get;  set; }
    }
}
