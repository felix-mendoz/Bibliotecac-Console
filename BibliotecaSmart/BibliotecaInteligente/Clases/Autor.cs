using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInteligente.Clases
{
    public class Autor
    {   
        //propiedades de clase
        private int IDAutor;
        private string Nombre;
        private string Apellido;

        //Constructor de clase asignando propiedades
        public Autor(int idautor, string nombre, string apellido) 
        {
            this.IDAutor = idautor;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        //Constructor de clase vacio
        public Autor() 
        {
        }

        /*
         ###################################################
        M E T O D O S  P A R A  O B T E N E R  V A L O R E S
        ####################################################
         */

        public int GetIDAutor()
        {
            return this.IDAutor;
        }//Fin getIdAutor

        public string GetNombreAutor()
        {
            return this.Nombre;
        }//Fin getNombreAutor

        public string GetApellidoAutor()
        {
            return this.Apellido;
        }//Fin getApellidoAutor

            /*
          ###################################################
         M E T O D O S  P A R A  A S I G N A R  V A L O R E S
         ####################################################
          */

        public void SetIDAutor(int idautor)
        {
            this.IDAutor = idautor;
        }//Fin setIdAutor

        public void SetNombreAutor(string nombre)
        {
            this.Nombre = nombre;
        }//Fin setNombreAutor

        public void SetApellidoAutor(string apellido)
        {
            this.Apellido = apellido;
        }//Fin setApellidoAutor

    } //Fin clase

} //Fin nombres de espacio
