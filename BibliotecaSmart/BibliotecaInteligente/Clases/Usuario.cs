using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInteligente.Clases
{
    public class Usuario
    {
        //propiedades de clase
        private int IDusuario;
        private string Nombre;
        private string Apellido;
        private int IDlibroUsuario;

        //Constructor de clase asignando propiedades
        public Usuario(int idusuario, string nombre, string apellido, int idlibrousuario = 0)
        {
            this.IDusuario = idusuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IDlibroUsuario = idlibrousuario;
        }

        //Constructor de clase vacio
        public Usuario ()
        {
        }

        /*
         ###################################################
        M E T O D O S  P A R A  O B T E N E R  V A L O R E S
        ####################################################
         */

        public int GetIDUsuario()
        {
            return this.IDusuario;
        }//Fin getIdUsuario

        public string GetNombreUsuario()
        {
            return this.Nombre;
        }//Fin getNombreUsuario

        public string GetApellidoUsuario()
        {
            return this.Apellido;
        }//Fin getApellidoUsuario

        public int GetLibroIDUsuario()
        {
            return this.IDlibroUsuario;
        }// FIn getLibroID

        /*
      ###################################################
     M E T O D O S  P A R A  A S I G N A R  V A L O R E S
     ####################################################
      */

        public void SetIDUsuario(int idusuario)
        {
            this.IDusuario = idusuario;
        }//Fin setIdusuario

        public void SetNombreUsuario(string nombre)
        {
            this.Nombre = nombre;
        }//Fin setNombreUsuario

        public void SetApellidoAutor(string apellido)
        {
            this.Apellido = apellido;
        }//Fin setApellidoAutor

        public void SetLibroIDUsuario (int idlibro)
        {
            this.IDlibroUsuario = idlibro;
        }//Fin serLibroIDUsuario

    } //Fin clase 

} //Fin namespace
