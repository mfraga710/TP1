using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Usuario
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public List<Usuario> amigos {get;set;}
        public List<Post> misPosts { get; set; }
        public List<Comentario> misComentarios { get; set; }
        public List<Reaccion> misReacciones { get; set; }
    }
}
