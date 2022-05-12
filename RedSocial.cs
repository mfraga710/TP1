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
            tags = new List<Tag>();
        }
        //OK
        public void registrarUsuario(string nombre, string apellido, string mail, int dni, string pass)
        {
            
            usuarios.Add(new Usuario(nombre, apellido, mail, dni, pass));
        }
        //OK
        public void modificaUsuario(Usuario usuarioModificado)
        {
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
        //HACER
        public void eliminarUsuario(Usuario u)
        {
            usuarios.Remove(u);
        }
        //OK
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
        //OK
        public void cerrarSesion(Forms.Home home,Login frm)
        {
            usuarioActual = null;
            home.Close();
            frm.Show();
        }
        //OK
        public void agregarAmigo(Usuario amigo)
        {      
            usuarioActual.amigos.Add(amigo);
            amigo.amigos.Add(usuarioActual);
        }
        //OK
        public void quitarAmigo(Usuario exAmigo)
        {
            usuarioActual.amigos.Remove(exAmigo);
            exAmigo.amigos.Remove(usuarioActual);
        }
        //OK
        public void postear(Post p, List<Tag> t)
        {
            foreach (Tag tag in t)
            {
                if (!tags.Contains(tag))
                {
                    tag.posts.Add(p);
                    p.tags.Add(tag);
                    tags.Add(tag);
                }
            }

            posts.Add(p);
            usuarioActual.misPosts.Add(p);
        }
        //HACER
        public void modificarPost(Post p)
        {
           //* foreach (Post p in p)
           //* posts.Remove(p);

        }
        //OK
        public void eliminarPost(Post p)
        {
            p.user.misPosts.Remove(p);
            posts.Remove(p);
        }
        //OK
        public void comentar(Post p, Comentario c) 
        {
            p.comentarios.Add(c);
            
        }
        //HACER
        public void modificarComentario(Post p, Comentario c)
        {
            /*
            foreach (Post post in posts)
            {
                foreach (Comentario coment in p.comentarios)
                {
                    if (coment.id == c.id)
                    {
                        coment.contenido = c.contenido;
                    }
                }
            }
            */

        }
        //HACER
        public void quitarComentario(Post p, Comentario c)
        {
            //(chequear si funciona)p.comentarios.Remove(c);
        }
        //HACER
        public void reaccionar(Post p, Reaccion r)
        {
            
        }
        //HACER
        public void modificarReacion(Post p, Reaccion r)
        {

        }
        //HACER
        public void quitarReacion(Post p, Reaccion r)
        {

        }
        //OK
        public Usuario mostrarDatos(Usuario u)
        {
          return u;
        }
        //OK
        public List<Post> mostrarPosts()
        {
            List<Post> p = new List<Post>();

            return p;
        }
        //OK
        public List<Post> mostrarPostsAmigos()
        {
            List<Post> p = new List<Post>();

            return p;
        }
        //HACER
        public List<Post> buscarPosts(String contenido, DateTime fecha, Tag t)
        {
            List<Post> p = new List<Post>();

            return p;
        }
    }
}
