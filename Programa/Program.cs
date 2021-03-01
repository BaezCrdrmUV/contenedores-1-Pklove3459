using System;

namespace PersonasConsoleRegister
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            int menuNumber = 0;
            int accionRealizada = 0;

            while(menuNumber == 0)
            {
                Console.WriteLine("Digite el numero de la accion que desea realizar \n");
                Console.WriteLine("1- Consultar \n");
                Console.WriteLine("2- Eliminar \n");
                Console.WriteLine("3- Actualizar \n");
                Console.WriteLine("4- Crear \n");
                Console.WriteLine("5- Salir \n");

                accionRealizada = Convert.ToInt32(Console.ReadLine());

                switch (accionRealizada)
                {
                    case 1:
                        menuNumber = 1;
                        break;
                    case 2:
                        menuNumber = 2;
                        break;
                    case 3:
                        menuNumber = 3;
                        break;
                    case 4:
                        menuNumber = 4;
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }

            switch (menuNumber)
            {
                case 4:
                    Persona persona = new Persona();
                    PersonaDAO personaDAO = new PersonaDAO();

                    Console.WriteLine("Ingrese el CURP de la persona a registrar");
                    persona.Curp = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese el Nombre de la persona a registrar");
                    persona.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el Apellido de la persona a registrar");
                    persona.Apellido = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese el Estatura de la persona a registrar");
                    persona.Estatura = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese el Peso de la persona a registrar");
                    persona.Peso = Console.ReadLine();

                    bool saved = personaDAO.SavePersona(persona);

                    if(saved == false)
                    {
                        Console.WriteLine("Ah Ocurrido un error de guardado intente de nuevo");
                    }
                    else
                    {
                        Console.WriteLine("Persona guardada con exito");
                    }

                    menuNumber = 0;
                    break;
            }
        }
    }
}
