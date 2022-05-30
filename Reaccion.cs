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

        static int idCont = 0;
        public const string ME_GUSTA = "Me gusta";
        public const string NO_ME_GUSTA = "No me gusta";


        public Reaccion(int id, string tipoReaccion, Post post, Usuario user)
        {
            this.id = id;
            this.tipoReaccion = tipoReaccion;
            this.post = post;
            this.usuario = user;

        }
        public Reaccion(string tipoReaccion, Post post, Usuario user)
        {
            idCont++;
            this.tipoReaccion = tipoReaccion;
            this.post = post;
            this.usuario = user;

        }

    }
}
