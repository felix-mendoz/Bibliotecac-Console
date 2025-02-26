﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BibliotecaInteligente.Clases;

namespace BibliotecaInteligente
{
    class Program
    {
        static int opcionSeleccionada = 0; // Opción seleccionada en el menú
        // Opciones del menú
        static string[] opciones = { "1. Ver Libros", "2. Agregar Libro", "3. Ver Usuarios", "4. Ver Autores", "5. Ver Libros Prestados","6. Agregar usuario","7. Prestar libro","8.Devolver libro","9. Salir" };

        static void Main(string[] args)
        {
            //Listas de objetos
            List<Autor> Autores = new List<Autor>();
            List<Usuario> Usuarios = new List<Usuario>();
            List<Libro> Libros = new List<Libro>();

            //Tamaño de la consola
            Console.SetWindowSize(140,35);
            // Configuración de colores de fondo y texto
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Cuadro(46, 92, 1, 10);
            Titulos(69, 2);
            // Bucle principal del menú
            while (true)
            {
                MostrarMenu(); // Muestra el menú
                var key = Console.ReadKey().Key; // Captura la tecla presionada
                ManejarInput(key, Autores, Usuarios,Libros); // Maneja la entrada del usuario
            }
            Console.ReadKey();
            Limpiar(69, 100, 12, 25);
            Console.ReadKey();
        } //Fin metodo de ejecucion principal

        // Método para mostrar el menú principal
        static void MostrarMenu()
        {
            Console.Clear(); // Limpia la consola
            Cuadro(0, 139, 0, 34); // Dibuja un cuadro alrededor del menú
            Console.SetCursorPosition(50, 1); // Establece la posición del cursor\
            Console.WriteLine("** Biblioteca Inteligente JF BiblioMundo **"); // Título del menú
            Console.WriteLine("║                                                    ║"); // Espacio en blanco
            Console.SetCursorPosition(0, 2); // Establece la posición del cursor

            Console.WriteLine("╔════════════════════════════════════════════════════╗"); // Línea superior del cuadro
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("║                                                    ║"); // Espacio en blanco

            // Muestra las opciones del menú
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.SetCursorPosition(10, 5 + i); // Posición para cada opción
                if (i == opcionSeleccionada) // Resalta la opción seleccionada
                {
                    Console.BackgroundColor = ConsoleColor.White; // Cambia el fondo
                    Console.ForegroundColor = ConsoleColor.Black; // Cambia el texto
                }
                Console.WriteLine($"║       {opciones[i]}       ║"); // Muestra la opción
                Console.BackgroundColor = ConsoleColor.Black; // Restaura los colores
                Console.ForegroundColor = ConsoleColor.White; // Restaura el texto
            }

            Console.SetCursorPosition(0, 5 + opciones.Length);
            Console.WriteLine("║                                                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝"); // Línea inferior del cuadro
            Console.SetCursorPosition(10, 7 + opciones.Length);
            Console.WriteLine("Seleccione una opción y presione Enter..."); // Instrucción para el usuario
            Console.WriteLine("║                                                    "); // Espacio en blanco
            Console.WriteLine("║                                                    "); // Espacio en blanco
            Console.WriteLine("                         F1 Ayuda     ↑↓ Mover Barra     → ← Mover Menues     Enter Validar     Esc Salir o 9");
            Console.WriteLine("║                                                    "); // Espacio en blanco
            Console.WriteLine("                                  Version 1.0 / By: Josian Rafael y Felix Mendoza S.A    ");
        }//FIn MostrarMenu

        // Método para manejar la entrada del usuario
        static void ManejarInput(ConsoleKey key, List<Autor> Autores,List<Usuario> Usuarios, List<Libro> Libros)
        {
            if (key == ConsoleKey.DownArrow) // Si presiona flecha abajo
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opciones.Length; // Mueve la selección hacia abajo
            }
            else if (key == ConsoleKey.UpArrow) // Si presiona flecha arriba
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opciones.Length) % opciones.Length; // Mueve la selección hacia arriba
            }
            else if (key == ConsoleKey.Enter) // Si presiona Enter
            {
                EjecutarOpcion(Autores,Usuarios,Libros);
                Console.WriteLine($"\nOpción seleccionada: {opciones[opcionSeleccionada]}"); // Muestra la opción seleccionada
                // Aquí no se ejecuta ninguna función
            }
        } //Fin manejar input


        public static void Cuadro(int x1, int x2, int y1, int y2)
        {
            //Creacion de las lineas Horizontales
            for (int x = x1; x <= x2; x++)
            {
                Console.SetCursorPosition(x, y1); Console.Write("="); //Alt+205
                Console.SetCursorPosition(x, y2); Console.Write("="); //Alt+205
            }
            //Creacion de las lineas Verticales
            for (int y = y1; y <= y2; y++)
            {
                Console.SetCursorPosition(x1, y); Console.Write("‖"); //Alt+186
                Console.SetCursorPosition(x2, y); Console.Write("‖"); //Alt+186
            }

            Console.SetCursorPosition(x1, y1); Console.Write("╔"); // Alt+201
            Console.SetCursorPosition(x1, y1); Console.Write("╗"); // Alt+187
            Console.SetCursorPosition(x1, y1); Console.Write("╚"); // Alt+200
            Console.SetCursorPosition(x1, y1); Console.Write("╝"); // Alt+188

        }//Fin del metodo cuadros

        public static void Titulos (int x1, int y1) 
        {
            string[] Titulos = { "Integrantes: ", "Félix Junior Mendoza Almanzar 2023-0886", "Josian Rafael Viñas Rosa 2023-0871"};
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            int contar = 0;
            foreach (string titulo in Titulos)
            {
                Console.SetCursorPosition(x1-(titulo.Length / 2), (y1 + contar)); Console.Write(titulo);
                contar+=2;
            }//Fin foreach
                
            Console.ResetColor();
            string texto = "Presione enter";
            Console.SetCursorPosition(x1 - (texto.Length / 2), contar+2); Console.Write(texto); Console.ReadKey();
        } //Fin metodo titulos

                /*
        ################################################
            P R O C E D I M I E N T I O S
        ################################################
         */

        //Método para agregar un nuevo libro..
        static void AgregarLibro(List<Autor> Autores,List<Libro> Libros)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("          ** AGREGAR UN NUEVO LIBRO **        ");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();

            Console.Write("** Ingrese el título del libro: ");
            string titulo = Console.ReadLine();

            Console.Write("** Ingrese el género del libro: ");
            string genero = Console.ReadLine();

            Console.Write("** Ingrese la fecha de publicación (YYYY-MM-DD): ");
            DateTime fechaPublicacion;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaPublicacion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!! Fecha inválida. Inténtelo nuevamente en el formato (YYYY-MM-DD).");
                Console.ResetColor();
                Console.Write("** Ingrese la fecha de publicación: ");
            }
            Autores.Add(AgregarAutor(69, 12, 20, 14, Autores));
            int Acceder = Autores.Count - 1;
            // Agrega el nuevo libro a la biblioteca
            Libros.Add(new Libro(titulo, genero, fechaPublicacion,Autores[Acceder]));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n** Libro agregado exitosamente. **");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();
        } //Fin metodo agregar libro

        // Método para mostrar los libros disponibles..
        static void MostrarLibros(List<Libro> Libros,int x,int y)
        {

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            string t1 = "| ID |";
            int posicionID = (x + t1.Length);
            Console.SetCursorPosition(x, y); Console.Write(t1);

            string t2 = "       Titulo      |";
            int PosicionTitulo = (posicionID + t2.Length);
            Console.SetCursorPosition(posicionID, y); Console.Write(t2);

            string t3 = "      Genero       |";
            int PosicionGenero = PosicionTitulo + t3.Length;
            Console.SetCursorPosition(PosicionTitulo, y); Console.Write(t3);

            string t4 = "      Fecha Publicación       |";
            int PosicionFecha = PosicionGenero + t4.Length;
            Console.SetCursorPosition(PosicionGenero, y); Console.Write(t4);

            string t5 = "      Autor del libro         |";
            int PosicionAutor = PosicionFecha + t5.Length;
            Console.SetCursorPosition(PosicionFecha, y); Console.Write(t5);
            
            string t6 = "   Estado   |";
            int PosicionEstado = PosicionAutor + t6.Length;
            Console.SetCursorPosition(PosicionAutor, y); Console.Write(t6);

            Console.ResetColor();
            if (Libros.Count > 0)
            {
                int Contador = y + 1;
                foreach (Libro valor in Libros)
                {
                    int CentralizarxID = posicionID - (t1.Length/2) - (valor.IDLibro.ToString().Length / 2);
                    int CentralizarxTitulo = PosicionTitulo - (t2.Length / 2) - (valor.Titulo.Length / 2);
                    int CentralizarxGenero = PosicionGenero - (t3.Length / 2) - (valor.Genero.Length / 2);
                    int CentralizarFecha =  PosicionFecha - (t4.Length / 2) - (valor.FechaPublicacion.ToString().Length / 2);
                    string AutorNameCompleto = $"{valor.Autor.GetNombreAutor()} {valor.Autor.GetApellidoAutor()}";
                    int CentralizarAutor = PosicionAutor- (t5.Length / 2) - (AutorNameCompleto.Length / 2);
                    Console.SetCursorPosition(CentralizarxID, Contador); Console.Write(valor.IDLibro);
                    Console.SetCursorPosition(CentralizarxTitulo, Contador); Console.Write(valor.Titulo);
                    Console.SetCursorPosition(CentralizarxGenero, Contador); Console.Write(valor.Genero);
                    Console.SetCursorPosition(CentralizarFecha, Contador); Console.Write(valor.FechaPublicacion);
                    Console.SetCursorPosition(CentralizarAutor, Contador); Console.Write("{0} {1}",valor.Autor.GetNombreAutor(),valor.Autor.GetApellidoAutor());
                    string Estado;

                    if (valor.Estado)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Estado = "Disponible";
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.White;
                        Estado = "Rentado";
                    }
                    int CentralizarEstado = PosicionEstado - (t6.Length / 2) - (Estado.Length / 2);
                    Console.SetCursorPosition(CentralizarEstado, Contador); Console.Write(Estado);
                    Console.ResetColor();
                    Contador++;
                }
            }
        }//Fin metodo mostrar libros

        public static void AgregarUsuario(int x, int y, int x2, int y2, List<Usuario> Usuarios)
        {
            int idusuario = Usuarios.Count + 1;
            string Nombre;
            string Apellido;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y); Console.Write("Agregando Nuevo Usuario");
            Console.ResetColor();
            Console.SetCursorPosition(x2, y2); Console.Write("Escriba el Nombre del Usuario: ");
            Nombre = Console.ReadLine();
            Console.SetCursorPosition(x2, y2 + 1); Console.Write("Escriba el Apellido del Usuario: ");
            Apellido = Console.ReadLine();
            Usuarios.Add(new Usuario(idusuario,Nombre,Apellido));
        } //Fin agregar usuario

        public static void ConsultarUsuarios(int x, int y, List<Usuario> Usuarios)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            string t1 = "| ID |";
            int posicionID = (x + t1.Length);
            Console.SetCursorPosition(x, y); Console.Write(t1);

            string t2 = "     Nombres     |";
            int PosicionNombre = (posicionID + t2.Length);
            Console.SetCursorPosition(posicionID, y); Console.Write(t2);

            string t3 = "      Apellidos       |";
            int PosicionApellido = (PosicionNombre + t3.Length);
            Console.SetCursorPosition(PosicionNombre, y); Console.Write(t3);

            string t4 = " ID Libro |";
            int PosicionIDLibro = PosicionApellido + t4.Length;
            Console.SetCursorPosition(PosicionApellido, y); Console.Write(t4);

            Console.ResetColor();

            if (Usuarios.Count > 0)
            {
                int Contador = y + 1;
                foreach (Usuario valor in Usuarios)
                {
                    string mostrar;
                    if (valor.GetLibroIDUsuario() == 0)
                    {
                        mostrar = "N/A";
                    }
                    else
                    {
                        mostrar = Convert.ToString(valor.GetLibroIDUsuario());
                    }

                    //En caso de querer centralizarlos
                    //int CentralizarxID = posicionID - (t1.Length / 2) - (valor.GetIDUsuario().ToString().Length / 2);
                    //int CentralizarxNombre = PosicionNombre - (t2.Length / 2) - (valor.GetNombreUsuario().Length / 2);
                    //int CentralizarxApellido = PosicionApellido - (t3.Length / 2) - (valor.GetApellidoUsuario().Length / 2);
                    int CentralizarxIdLibro = PosicionIDLibro - (t4.Length / 2) - (mostrar.Length / 2);

                    Console.SetCursorPosition(posicionID-(t1.Length/ 2), Contador); Console.Write(valor.GetIDUsuario());
                    Console.SetCursorPosition(posicionID, Contador); Console.Write(valor.GetNombreUsuario());
                    Console.SetCursorPosition(PosicionNombre, Contador); Console.Write(valor.GetApellidoUsuario());
                    Console.SetCursorPosition(CentralizarxIdLibro, Contador); Console.Write(mostrar);
                    
                    Contador++;
                }
            }
        } //Fin consultar usuario

        public static Autor AgregarAutor(int x, int y,int x2, int y2, List<Autor> Autores)
        {
            int idAutor = Autores.Count + 1;
            string Nombre;
            string Apellido;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y); Console.Write("Agregando Nuevo autor");
            Console.ResetColor();
            Console.SetCursorPosition(x2, y2); Console.Write("Escriba el Nombre del Autor: ");
            Nombre = Console.ReadLine();
            Console.SetCursorPosition(x2, y2+1); Console.Write("Escriba el Apellido del Autor: ");
            Apellido = Console.ReadLine();
            return new Autor(idAutor, Nombre, Apellido);
        } //Fin agregar autor

        public static void ConsultarAutores (int x, int y, List<Autor> Autores)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            string t1 = "| ID |";
            int posicionID = (x + t1.Length);
            Console.SetCursorPosition(x, y); Console.Write(t1);

            string t2 = "     Nombres     |";
            int PosicionNombre = (posicionID + t2.Length);
            Console.SetCursorPosition(posicionID, y); Console.Write(t2);

            string t3 = "      Apellidos       |";
            int PosicionApellido = PosicionNombre + t3.Length;
            Console.SetCursorPosition(PosicionNombre, y); Console.Write(t3);

            Console.ResetColor();

            if (Autores.Count > 0)
            {
                int Contador = y+1;
                foreach(Autor valor in Autores) 
                {
                    Console.SetCursorPosition(posicionID - (t1.Length / 2), Contador); Console.Write(valor.GetIDAutor());
                    Console.SetCursorPosition(posicionID, Contador); Console.Write(valor.GetNombreAutor());
                    Console.SetCursorPosition(PosicionNombre, Contador); Console.Write(valor.GetApellidoAutor());
                    Contador++;
                }
            }
        } //Fin consultar autores

        // Método para ejecutar la opción seleccionada en el menú
        static void EjecutarOpcion(List<Autor> Autores, List<Usuario> Usuarios, List<Libro> Libros)
        {
            Console.Clear(); // Limpia la consola
            switch (opcionSeleccionada) // Según la opción seleccionada
            {
                case 0: // Opción 1: Ver Libros
                    Console.WriteLine("📚 Libros Disponibles:");
                    MostrarLibros(Libros,12,4);
                    break;
                case 1: // Opción 2: Agregar Libro
                    AgregarLibro(Autores,Libros);
                    break;
                case 2: // Opción 3: Ver Usuarios
                    ConsultarUsuarios(69,4,Usuarios);
                    break;
                case 3: // Opción 4: Ver Autores
                    ConsultarAutores(69, 4, Autores);
                    break;
                case 4: // Opción 5: Ver Libros Prestados
                    VerlibrosPrestados(Libros, Usuarios, 12, 4);
                    break;
                case 5: // Opción 6: Agregar usuario
                    AgregarUsuario(69, 12, 20, 14, Usuarios);
                    break;
                case 6: // Opción 6: Prestar libro
                    PrestarLibro(Usuarios, Libros);
                    break;
                case 7: // Opción 7: Devolver libro
                    DevolverLibro(Usuarios, Libros);
                    break;
                case 8: // Opción 7: Salir
                    Environment.Exit(0); // Sale del programa
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para regresar al menú..."); // Mensaje para regresar al menú
            Console.ReadKey(); // Espera a que el usuario presione una tecla
        }//Fin ejecutar opcion

        public static void PrestarLibro(List<Usuario> Usuarios, List<Libro> Libros)
        {
            int IDUsuario;
            int IDLibro;

            // Validación para ID de usuario
            while (true)
            {
                Console.Write("Escriba el Id del usuario: ");
                string inputUsuario = Console.ReadLine();
                if (int.TryParse(inputUsuario, out IDUsuario))
                {
                    break; // Salir del bucle si se ingresó un número entero
                }
                Console.WriteLine("Por favor, ingrese un número válido para el ID del usuario.");
            }

            // Validación para ID de libro
            while (true)
            {
                Console.Write("Escriba el id del libro: ");
                string inputLibro = Console.ReadLine();
                if (int.TryParse(inputLibro, out IDLibro))
                {
                    break; // Salir del bucle si se ingresó un número entero
                }
                Console.WriteLine("Por favor, ingrese un número válido para el ID del libro.");
            }

            bool usuarioEncontrado = false; // Variable para comprobar si se encontró el usuario

            // Buscamos el usuario
            foreach (Usuario usuario in Usuarios)
            {
                // Si el usuario existe
                if (IDUsuario == usuario.GetIDUsuario())
                {
                    usuarioEncontrado = true; // Marcamos que el usuario fue encontrado

                    // Si el usuario no tiene un libro rentado
                    if (usuario.GetLibroIDUsuario() == 0)
                    {
                        bool libroEncontrado = false; // Variable para verificar si se encontró el libro

                        foreach (Libro libro in Libros)
                        {
                            if (IDLibro == libro.IDLibro)
                            {
                                libroEncontrado = true;
                                // Prestar libro
                                usuario.SetLibroIDUsuario(IDLibro);
                                libro.Estado = false;
                                Console.WriteLine("Libro prestado exitosamente");
                                break;
                            }
                        }

                        if (!libroEncontrado)
                        {
                            Console.WriteLine("Libro no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El usuario ya tomó un libro prestado.");
                    }

                    break; // Salimos del foreach ya que encontramos el usuario
                }
            }

            // Si después del bucle el usuario no fue encontrado
            if (!usuarioEncontrado)
            {
                Console.WriteLine("Usuario no encontrado");
            }
        }

        public static void DevolverLibro(List<Usuario> Usuarios, List<Libro> Libros)
        {
            int IDUsuario;
            int IDLibro;

            // Validación para ID de usuario
            while (true)
            {
                Console.Write("Escriba el Id del usuario: ");
                string inputUsuario = Console.ReadLine();
                if (int.TryParse(inputUsuario, out IDUsuario))
                {
                    break; // Salir del bucle si se ingresó un número entero
                }
                Console.WriteLine("Por favor, ingrese un número válido para el ID del usuario.");
            }

            // Validación para ID de libro
            while (true)
            {
                Console.Write("Escriba el id del libro: ");
                string inputLibro = Console.ReadLine();
                if (int.TryParse(inputLibro, out IDLibro))
                {
                    break; // Salir del bucle si se ingresó un número entero
                }
                Console.WriteLine("Por favor, ingrese un número válido para el ID del libro.");
            }

            bool usuarioEncontrado = false; // Variable para comprobar si se encontró el usuario

            // Buscamos el usuario
            foreach (Usuario usuario in Usuarios)
            {
                // Si el usuario existe
                if (IDUsuario == usuario.GetIDUsuario())
                {
                    usuarioEncontrado = true; // Marcamos que el usuario fue encontrado

                    // Si el usuario tiene un libro rentado
                    if (usuario.GetLibroIDUsuario() != 0)
                    {
                        bool libroEncontrado = false; // Variable para verificar si se encontró el libro

                        foreach (Libro libro in Libros)
                        {
                            if (IDLibro == libro.IDLibro)
                            {
                                libroEncontrado = true;
                                if (!libro.Estado)
                                {
                                    // Devolver libro
                                    usuario.SetLibroIDUsuario(0);
                                    libro.Estado = true;
                                    Console.WriteLine("Devuelta exitosa");
                                }
                                else
                                {
                                    Console.WriteLine("Este libro no está prestado");
                                }
                                break;
                            }
                        }

                        if (!libroEncontrado)
                        {
                            Console.WriteLine("Libro no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El usuario no tiene un libro que devolver.");
                    }

                    break; // Salimos del foreach ya que encontramos el usuario
                }
            }

            // Si después del bucle el usuario no fue encontrado
            if (!usuarioEncontrado)
            {
                Console.WriteLine("Usuario no encontrado");
            }
        }

        public static void VerlibrosPrestados(List<Libro> Libros, List<Usuario> Usuarios, int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            int ContarLibrosPrestados = 0;

            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.GetLibroIDUsuario() != 0)
                {
                    ContarLibrosPrestados++;
                }
            }

            if (ContarLibrosPrestados > 0)
            {
                string t1 = "| ID Libro |";
                int posicionID = (x + t1.Length);
                Console.SetCursorPosition(x, y); Console.Write(t1);

                string t2 = "       Titulo      |";
                int PosicionTitulo = (posicionID + t2.Length);
                Console.SetCursorPosition(posicionID, y); Console.Write(t2);

                string t3 = "      Genero       |";
                int PosicionGenero = PosicionTitulo + t3.Length;
                Console.SetCursorPosition(PosicionTitulo, y); Console.Write(t3);

                string t4 = "      Autor del libro         |";
                int PosicionAutor = PosicionGenero + t4.Length;
                Console.SetCursorPosition(PosicionGenero, y); Console.Write(t4);

                string t5 = "       Prestado a       |";
                int PosicionPrestadoA = PosicionAutor + t5.Length;
                Console.SetCursorPosition(PosicionAutor, y); Console.Write(t5);

                string t6 = " Con ID |";
                int PosicionIDUsuario = PosicionPrestadoA + t6.Length;
                Console.SetCursorPosition(PosicionPrestadoA, y); Console.Write(t6);

                Console.ResetColor();
                if (Libros.Count > 0)
                {
                    int Contador = y + 1;
                    foreach (Usuario valor in Usuarios)
                    {
                        int CentralizarxID = posicionID - (t1.Length / 2) - (valor.GetLibroIDUsuario().ToString().Length / 2);
                        string TituloLibro = "";
                        string GeneroLibro = "";
                        string AutorNombreLibro = "";
                        string UsuarioNombreCompleto = $"{valor.GetNombreUsuario()} {valor.GetApellidoUsuario()}";
                        foreach (Libro Libro in Libros)
                        {
                            if (valor.GetLibroIDUsuario() == Libro.IDLibro)
                            {
                                TituloLibro = Libro.Titulo;
                                GeneroLibro = Libro.Genero;
                                AutorNombreLibro = $"{Libro.Autor.GetNombreAutor()} {Libro.Autor.GetApellidoAutor()}";
                                break;
                            }
                        }

                        int CentralizarxTitulo = PosicionTitulo - (t2.Length / 2) - (TituloLibro.Length / 2);
                        int CentralizarxGenero = PosicionGenero - (t3.Length / 2) - (GeneroLibro.Length / 2);
                        int CentralizarAutor = PosicionAutor - (t4.Length / 2) - (AutorNombreLibro.Length / 2);
                        int CentralizarNombreUsuario = PosicionPrestadoA - (t5.Length / 2) - (UsuarioNombreCompleto.Length / 2);
                        int CentralizarIDUsuario = PosicionIDUsuario - (t6.Length / 2) - (valor.GetIDUsuario().ToString().Length / 2);

                        Console.SetCursorPosition(CentralizarxID, Contador); Console.Write(valor.GetLibroIDUsuario());
                        Console.SetCursorPosition(CentralizarxTitulo, Contador); Console.Write(TituloLibro);
                        Console.SetCursorPosition(CentralizarxGenero, Contador); Console.Write(GeneroLibro);
                        Console.SetCursorPosition(CentralizarAutor, Contador); Console.Write(AutorNombreLibro);
                        Console.SetCursorPosition(CentralizarNombreUsuario, Contador); Console.Write(UsuarioNombreCompleto);
                        Console.SetCursorPosition(CentralizarIDUsuario, Contador); Console.Write(valor.GetIDUsuario());
                    }
                }


            }
            else 
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No hay libros prestados");
                Console.ResetColor();
            } //Fin si hay libros prestados
        } //Fin metodo
        public static void Limpiar(int x1, int x2,  int y1, int y2)
        {
            for (int x = x1; x<=x2; x++)
            {
                for (int y = y1; y <= y2; y++) 
                {
                    Console.SetCursorPosition(x, y); Console.Write(" ");
                }
            }
        }

    } //Fin clase
} // Fin namespace
