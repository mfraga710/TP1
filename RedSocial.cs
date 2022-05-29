using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace TP1
{
     public class RedSocial
     {
        public List<Usuario> usuarios { get; set; }
        public List<Post> posts { get; set; }
        public List<Tag> tags { get; set; }
        public Usuario usuarioActual { get; set; }

        private DAL DB;
        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
            tags = new List<Tag>();
            DB = new DAL();
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            usuarios = DB.inicializarUsuarios();
            //posts = DB.inicializarPosts();
        }

        /*public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in usuarios)
                salida.Add(new List<string>() { u.id.ToString(), u.nombre, u.apellido, u.mail, u.dni.ToString(), u.pass, u.bloqueado.ToString(), u.isAdm.ToString() });
            return salida;
        }*/

        public void registrarUsuario(string nombre, string apellido, string mail, int dni, string pass )
        {
            var aux = DB.agregarUsuario(dni, nombre, apellido, mail, pass, 0, false, false);
            usuarios.Add(new Usuario(aux, nombre, apellido, mail, dni, pass));                 
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
            if (DB.eliminarUsuario(u.id) > 0) 
            {
                usuarios.Remove(u);
            }
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

        public void postear(Post p, List<Tag> newTags)
        {
            foreach (Tag tag in newTags)
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

        public void reaccionar(Post p, Reaccion r)
        {
            bool newReaction = true;
            foreach (Reaccion reaccion in p.reacciones)
            {
                if (reaccion.usuario.id == usuarioActual.id)
                {
                    newReaction = false;
                    modificarReacion(p, r);
                }
            }
            if(newReaction)
                p.reacciones.Add(r);
        }
        //HACER
        public void modificarReacion(Post p, Reaccion r)
        {
            foreach (Reaccion reaccion in p.reacciones)
            {
                if (reaccion.usuario.id == usuarioActual.id)
                {
                    reaccion.tipoReaccion = r.tipoReaccion;
                }
            }
        }
        //HACER
        public void quitarReacion(Post p, Reaccion r)
        {
            Reaccion rEliminar = null;
            foreach (Reaccion reaccion in p.reacciones)
            {
                if (reaccion.usuario.id == usuarioActual.id)
                {
                    rEliminar = reaccion;
                }
            }
            p.reacciones.Remove(rEliminar);
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
            List<Post> postsAmigos = new List<Post>();
            foreach (Usuario amigo in usuarioActual.amigos)
            {
                postsAmigos.AddRange(amigo.misPosts);
            }

            return postsAmigos;
        }
        //OK
        public List<Post> buscarPosts(String contenido, DateTime fechaDesde,DateTime fechaHasta, List<Tag> bTags)
        {
            List<Post> p = new List<Post>();
            string fDesde = fechaDesde.Date.ToString("dd/MM/yyyy");
            string hDesde = fechaHasta.Date.ToString("dd/MM/yyyy");
            bool tagAgregado = false;

            foreach (Post pPost in posts)
            {
                if (contenido != "" )
                {
                    if (pPost.contentido.Contains(contenido))
                    {
                        if (bTags.Count > 0)
                        {
                            if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                            {
                                foreach (Tag t in bTags)
                                {
                                    foreach (Tag tPost in pPost.tags)
                                    {
                                        if (t.palabra.Equals(tPost.palabra))
                                        {
                                            p.Add(pPost);
                                            tagAgregado = true;
                                            break;
                                        }
                                    }
                                    if (tagAgregado)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                            {
                                p.Add(pPost);
                            }
                        }
                    }                    
                }
                else
                  {
                    if (bTags.Count > 0)
                    {
                        if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                        {
                            foreach (Tag t in bTags)
                            {
                                foreach (Tag tPost in pPost.tags)
                                {
                                    if (t.palabra.Equals(tPost.palabra))
                                    {
                                        p.Add(pPost);
                                        tagAgregado = true;
                                        break;
                                    }
                                }
                                if (tagAgregado)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                        {
                            p.Add(pPost);
                        }
                    }
                }
            }   

            return p;
        }

        // IDENTIFICADOR DE COMENTARIO del post
        public Comentario searchComent(int id)
        {
            foreach (Post p in posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        return c;
                    }
                }
            }
            return null;
        }
        // IDENTIFICADOR DE POST
        public Post searchPost(int idPost)
        {
            foreach (Post p in posts)
            {
                if (idPost == p.id)
                {
                    return p;
                }
            }
            return null;
        }
        // IDENTIFICADOR DE USUARIO
        public Usuario searchUser(int idUser)
        {
            foreach (Usuario u in usuarios)
            {
                if (idUser == u.id)
                {
                    return u;
                }
            }
            return null;
        }
        
        
    }


}
