using System;
using System.Collections.Generic;
using System.Text;



namespace TP1
{
     public class RedSocial
     {
        public List<Usuario> usuarios { get; set; }
        public List<Post> posts { get; set; }
        public List<Tag> tags { get; set; }
        public Usuario usuarioActual { get; set; }

        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
        }
        
        public void registrarUsuario(string nombre, string apellido, string mail, int dni, string pass)
        {
            usuarios.Add(new Usuario(nombre, apellido, mail, dni, pass));
        }


        public void modificaUsuario(Usuario usuarioModificado)
        {
            
            // volver a ver por que el id de usuario no se deberia modificar!!!!!!!!!!!!

            Usuario usuarioAremover = null;

            foreach(Usuario user in usuarios)
            {
                if (user.id.Equals(usuarioModificado))
	            {
                     usuarioAremover = user;                    
	            }
            }
                usuarios.Remove(usuarioAremover);
                usuarios.Add(usuarioModificado);
        }

        public void eliminarUsuario(Usuario u)
        {
            usuarios.Remove(u);
        }

        public bool iniciarSesion(string usuario, string pass)
        {
            bool flag = false;
            int intentos = 0;
            
            foreach (Usuario user in usuarios)
            {
                if (user.email.Equals(usuario) && user.password.Equals(pass)) 
                {
                    user.intentosFallidos = 0;
                    usuarioActual = user;
                    flag = true;
                }
                else { intentos++; }
            }
             return flag;
        }

        public void cerrarSesion()
        {
            
        }
        public void agregarAmigo(Usuario amigo)
        {
            usuarioActual.amigos.Add(amigo);        
        }
        public void quitarAmigo(Usuario exAmigo)
        {

        }
        public void postear(Post p, List<Tag> t)
        {
            posts.Add(p);
            usuarioActual.misPosts.Add(p);
            //foreach (Tag tag in t)
            //{
            //    foreach (Tag tagLocal in tags)
            //    {
            //        if (!tags.Contains(tag))
            //        {
            //            tags.Add(tag);
            //        }
            //    }
            //}
        }
        public void modificarPost(Post p)
        {

        }
        public void eliminarPost(Post p)
        {

        }
        public void comentar(Post p, Comentario c) 
        {
            p.comentarios.Add(c);
        }
        public void modificarComentario(Post p, Comentario c)
        {

        }
        public void quitarComentario(Post p, Comentario c)
        {
            //(chequear si funciona)p.comentarios.Remove(c);
        }
        public void reaccionar(Post p, Reaccion r)
        {
            
        }
        public void modificarReacion(Post p, Reaccion r)
        {

        }
        public void quitarReacion(Post p, Reaccion r)
        {

        }
        public Usuario mostrarDatos(Usuario u)
        {
            return u;
        }
        public List<Post> mostrarPosts()
        {
            List<Post> p = new List<Post>();

            return p;
        }

        public List<Post> mostrarPostsAmigos()
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
