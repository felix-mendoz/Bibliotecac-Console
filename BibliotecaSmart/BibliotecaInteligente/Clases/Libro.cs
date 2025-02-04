using System;
using System.Collections.Generic;

namespace BibliotecaInteligente.Clases
{
    /// Representa un libro dentro de la biblioteca.
    class Libro
    {
        
        public int IDLibro { get; set; } // Propiedad que para almacenar el ID único del libro.

        // get/set Se utilizan en las propiedades para definir métodos
        // de acceso y modificación de un atributo dentro de una clase.
        public string Titulo { get; set; }

        //Género del libro (...)
        public string Genero { get; set; }

        
        public DateTime FechaPublicacion { get; set; } //Fecha de publicación del libro

        //Estado del libro aqui en este public.
        public bool Estado { get; set; } = true;

        //Autor del libro, representado como un objeto de la clase Autor
        public Autor Autor { get; set; }

        //Contador estático para generar IDs únicos automáticamente. Lo puse en privado mendoza. 
        private static int contadorID = 1;

        public Libro(string titulo, string genero, DateTime fecha, Autor autor)
        {
            IDLibro = contadorID++;
            Titulo = titulo;               // Aqui estoy creando el objeto de la clase. 
            Genero = genero;
            FechaPublicacion = fecha;
            Autor = autor;
        }

    }
}
