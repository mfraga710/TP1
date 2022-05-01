using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
     class RedSocial
    {
        private List<Usuario> usuarios;
        private List<Post> posts { get; set; }
        private List<Tag> tags { get; set; }
        private Usuario usuarioActual { get; set; }
        usuarios = new list<Usuario>();

        public void RegistrarUsuario(string user, string pass)
        {
            usuarios.Add(new Usuario(user, pass));

        }

        public void ModificaUsuario(Usuario u)
        {
        
        }
        public void EliminarUsuario(Usuario u)
        {

        }
        public bool IniciarSesion(string usuario, string contraseña)
        {
            bool flag = false;
            int intentos = 0;

             foreach (Usuario usuario in usuarios)
                {
                    if (usuario.email.Equals(user) && usuario.password.Equals(pass))
                        flag = true;    
                }
             else { intentos++;}
             return flag;
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
