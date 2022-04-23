using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Comentario
    {
        public int id { get; set; }
        public Post post { get; set; }
        public Usuario usuario { get; set; }
        public string contenido { get; set; }
        public DateTime fecha { get; set; }
    }
}
