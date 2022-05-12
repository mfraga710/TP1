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
        static int mg = 0;
        static int nmg = 0;
        public Reaccion(string tipoReaccion, Post post, Usuario user)
        {
            this.id = idCont++;
            this.tipoReaccion = tipoReaccion;
            this.post = post;
            this.usuario = user;
            if (tipoReaccion == "Me gusta")
            {
                mg++;
            }
            else
            {
                nmg++;
            }

        }

    }
}
