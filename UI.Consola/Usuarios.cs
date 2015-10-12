using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        Business.Logic.PersonaLogic UsuarioNegocio { get; set; }

        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.PersonaLogic();
        }

        public void Menu()
        {
            bool seguir = true;

            while (seguir)
            {
                Console.WriteLine("1– Listado General");
                Console.WriteLine("2– Consulta");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                Console.Write("Opcion: ");

                ConsoleKeyInfo opc = Console.ReadKey();

                switch (opc.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ListadoGeneral();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Consultar();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Agregar();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Modificar();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Eliminar();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        seguir = false;
                        break;
                    default:
                        Console.WriteLine("Error de entrada");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Persona usr in UsuarioNegocio.GetAll() )
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Persona usr)
        {

            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            // \t dentro de un string representa un TAB
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario: ");
                int id = int.Parse(Console.ReadLine());
                Business.Entities.Persona usuario = UsuarioNegocio.GetOne(id);
                Console.Write("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("\nIngrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("\nIngrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("\nIngrese clave: ");
                //usuario.Clave = Console.ReadLine();
                Console.Write("\nIngrese email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("\nIngrese habilitacion de usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Business.Entities.Persona usuario = new Business.Entities.Persona();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("\nIngrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("\nIngrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("\nIngrese clave: ");
            //usuario.Clave = Console.ReadLine();
            Console.Write("\nIngrese email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("\nIngrese habilitacion de usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
