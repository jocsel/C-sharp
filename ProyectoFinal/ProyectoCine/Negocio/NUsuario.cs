using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class NUsuario
    {

        public Entidad.EUsuario Login(string usuario, string password)
        {
            try
            {
                Datos.DLogin logear = new Datos.DLogin();
                return logear.Login(usuario, password);
            }

            catch (Exception ex) {

                throw ex;
            }

        } 
        /*public List<EUsuario> obtenerListaUsuarios()
        {
            try {

                DUsuarios datosUsuario = new DUsuarios();
                return datosUsuario.obtenerListaUsuario();
            }
            catch (Exception ex) {

                throw ex;
            }

        }

        public void Agregar(EUsuario agregarUsuario)
        {
            try {
                if (agregarUsuario.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese el Nombre y Apellido");
                if (agregarUsuario.Nombre_Usuario.Length == 0)
                    throw new ArgumentException("Ingresa el nombre del usuario");
                if (agregarUsuario.Contraseña.Length == 0)
                    throw new ArgumentException("Ingresa la contraseña");
                if (agregarUsuario.Tipo_De_Usuario.Length == 0)
                    throw new ArgumentException("Ingresa el tipo de usuario");

                DUsuarios gestionUsuario = new DUsuarios();
                gestionUsuario.Agregar(agregarUsuario);

            }
            catch (Exception ex) {

                throw ex;
            }

        }

        public void Modificar(EUsuario modificarUsuario)
        {
            try {
                if (modificarUsuario.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese el Nombre y Apellido");
                if (modificarUsuario.Nombre_Usuario.Length == 0)
                    throw new ArgumentException("Ingresa el usuario");
                if (modificarUsuario.Contraseña.Length == 0)
                    throw new ArgumentException("Ingresa la contraseña");
                if (modificarUsuario.Tipo_De_Usuario.Length == 0)
                    throw new ArgumentException("Ingresa el tipo de usuario");

                DUsuarios gestionUsuario = new DUsuarios();
                gestionUsuario.Modificar(modificarUsuario);
            }
            catch (Exception ex) {

                throw ex;   
            }

        }

        public void Eliminar(EUsuario eliminarUsuario)
        {
            try {
                DUsuarios gestionUsuario = new DUsuarios();
                gestionUsuario.Eliminar(eliminarUsuario);
            }

            catch (Exception ex) {
                throw ex;

            }
        }

        public DataTable logeo (EUsuario logeando)
        {
            try
            {
                if(logeando.Nombre_Usuario.Length==0)
                    throw new ArgumentException("Ingresa el nombre de usuario");
               if (logeando.Contraseña.Length == 0)
                   throw new ArgumentException("Ingresa la contrase;a de usuario");

                DUsuarios gestionUsuario = new DUsuarios();
                return gestionUsuario.log(logeando);

            }
            catch(Exception ex)
               {
                throw ex;
            }

        }*/
    }
}
