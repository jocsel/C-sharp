using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class NUsuario
    {
        public List<EUsuario> obtenerListaUsuarios()
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
    }
}
