using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class RedSocial
    {
        private List<Usuario> usuario{ get; set; }
        private List<Post> posts { get; set; }
        private List<Tag> tags { get; set; }
        private Usuario usuarioActual { get; set; }

        public void RegistrarUsuario(Usuario u)
        {
            usuario.Add(u);
        }
        public void ModificaUsuario(Usuario u)
        {
            /*TODO*/
        }
        public void EliminarUsuario(Usuario u)
        {

        }
        public bool IniciarSesion(string usuario, string contrasenia)
        {
            bool boleanoloco = false;
            int intentos = 0;

            if (boleanoloco = true)
            {
                //TODO
            }
            return true;
        }
        public void CerrarSesion()
        {
            
        }
        public void AgregarAmigo(Usuario amigo)
        {

        }
        public void QuitarAmigo(Usuario exAmigo)
        {

        }
        public void Postear(Post p, List<Tag> t)
        {
                        
        }
        public void ModificarPost(Post p)
        {

        }
        public void EliminarPost(Post p)
        {

        }
        public void Comentar(Post p, Comentario c) 
        {

        }
        public void ModificarComentario(Post p, Comentario c)
        {

        }
        public void QuitarComentario(Post p, Comentario c)
        {

        }
        public void Reaccionar(Post p, Reaccion r)
        {
            
        }
        public void ModificarReacion(Post p, Reaccion r)
        {

        }
        public void QuitarReacion(Post p, Reaccion r)
        {

        }
        public Usuario MostrarDatos(Usuario u)
        {
            return u;
        }
        public List<Post> MostrarPosts()
        {
            List<Post> p = new List<Post>();

            return p;
        }

        public List<Post> MostrarPostsAmigos()
        {
            List<Post> p = new List<Post>();

            return p;
        }
        public List<Post> buscarPosts(String contenido, DateTime fecha, Tag t)
        {
            List<Post> p = new List<Post>();

            return p;
        }
    }
}
