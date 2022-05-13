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

        public void registrarUsuario(string nombre, string apellido, string mail, int dni, string pass)
        {
            
            usuarios.Add(new Usuario(nombre, apellido, mail, dni, pass));
        }

        public void modificaUsuario(Usuario usuarioModificado)
        {
            if (usuarioModificado != null)
            {
                foreach (Usuario user in usuarios)
                {
                    if (user.id == usuarioModificado.id)
                    {
                        user.nombre = usuarioModificado.nombre;
                        user.apellido = usuarioModificado.apellido;
                        user.email = usuarioModificado.email;
                        user.dni = usuarioModificado.dni;
                    }
                }
            }
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

        public void cerrarSesion(Forms.Home home,Login frm)
        {
            usuarioActual = null;
            home.Close();
            frm.Show();
        }

        public void agregarAmigo(Usuario amigo)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.id == usuarioActual.id)
                {
                    u.amigos.Add(amigo);
                    amigo.amigos.Add(u);
                }
            }
        }

        public void quitarAmigo(Usuario exAmigo)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.id == usuarioActual.id)
                {
                    u.amigos.Remove(exAmigo);
                    exAmigo.amigos.Remove(u);
                }
            }
        }

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

        public void modificarPost(Post p)
        {
            if (p != null)
            {
                foreach (Post post in posts)
                {
                    if (post.id == p.id)
                    {
                        post.contentido = p.contentido;
                    }
                }
            }
        }

        public void eliminarPost(Post p)
        {
            p.user.misPosts.Remove(p);
            posts.Remove(p);
        }

        public void comentar(Post p, Comentario c) 
        {
            p.comentarios.Add(c);
            
        }

        public void modificarComentario(Post p, Comentario c)
        {
            if(p != null && c != null)
            {
                foreach (Comentario coment in p.comentarios)
                {
                    if (coment.id == c.id)
                    {
                        coment.contenido = c.contenido;
                    }
                }
            }
        }

        public void quitarComentario(Post p, Comentario c)
        {
            if(p != null && c != null)
                p.comentarios.Remove(c);
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

        public Usuario mostrarDatos(Usuario u)
        {
          return u;
        }

        public List<Post> mostrarPosts()
        {
          return usuarioActual.misPosts;
        }
        //OK
        public List<Post> mostrarPostsAmigos()
        {
            

            return null;
        }
        //HACER
        public List<Post> buscarPosts(String contenido, DateTime fecha, Tag t)
        {
            List<Post> p = new List<Post>();

            return p;
        }
    }
}
