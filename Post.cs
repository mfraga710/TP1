using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Post
    {
        public int id { get; set; }
        public Usuario user { get; set; }
        public string contentido { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Reaccion> reacciones { get; set; }
        public List<Tag> tags { get; set; }
        public DateTime fecha { get; set; }
    }
}
