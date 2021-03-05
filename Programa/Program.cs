using System;

namespace PersonasConsoleRegister
{
    public class Program
    {

        public static void Main(string[] args)
        {

            bool endProgram = false;
            int menuNumber = 0;
            if (args.Length > 0 && args[0].Equals("entrar"))
            {
                while (!endProgram)
                {
                    Console.WriteLine("Digite el numero de la accion que desea realizar \n");
                    Console.WriteLine("1- Consultar \n");
                    Console.WriteLine("2- Eliminar \n");
                    Console.WriteLine("3- Actualizar \n");
                    Console.WriteLine("4- Crear \n");
                    Console.WriteLine("5- Salir \n");

                    menuNumber = Convert.ToInt32(Console.ReadLine());
                    switch (menuNumber)
                    {
                        case 1:
                            PersonaDAO personaConsultDAO = new PersonaDAO();

                            Console.WriteLine("Ingrese el CURP de la persona a buscar\n");
                            string curp = Console.ReadLine();

                            Persona personaCheck = new Persona();
                            personaCheck = personaConsultDAO.GetPersonaByCURP(curp);

                            if (personaCheck != null)
                            {
                                Console.WriteLine("\n ------------------------------");
                                Console.WriteLine("Curp: " + personaCheck.Curp + " \n");
                                Console.WriteLine("Nombre:" + personaCheck.Nombre + " " + personaCheck.Apellido + " \n");
                                Console.WriteLine("Estatura:" + personaCheck.Estatura + " " + "Peso: " + personaCheck.Peso + " \n");
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("\n \n \n");
                            }
                            else
                            {
                                Console.WriteLine("Esa persona no existe, o ha ingresado mal el curp intente mas tarde \n");
                            }

                            menuNumber = 0;

                            break;

                        case 2:
                            Console.WriteLine("Ingrese el CURP de la persona a eliminar\n");

                            string curpDelete = Console.ReadLine();
                            PersonaDAO personaDeleteDao = new PersonaDAO();

                            if (personaDeleteDao.DeletePersonaAddress(curpDelete))
                            {
                                if (personaDeleteDao.DeletePersonaMails(curpDelete))
                                {
                                    if (personaDeleteDao.DeletePersonaByCURP(curpDelete))
                                    {
                                        Console.WriteLine("Borrado Exitosamente \n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ha Ocurrido un error inesperado \n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ha Ocurrido un error inesperado \n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ha Ocurrido un error inesperado \n");
                            }

                            menuNumber = 0;

                            break;
                        case 3:
                            PersonaDAO personaUpdateDAO = new PersonaDAO();

                            Console.WriteLine("Ingrese el CURP de la persona a buscar\n");
                            string updateCurp = Console.ReadLine();
                            Console.WriteLine("Digite el numero de la accion que desea realizar \n");
                            Console.WriteLine("1- Consultar \n");
                            Console.WriteLine("2- Eliminar \n");
                            Console.WriteLine("3- Actualizar \n");
                            Console.WriteLine("4- Crear \n");
                            Console.WriteLine("5- Salir \n");

                            menuNumber = 0;

                            break;
                        case 4:
                            Persona persona = new Persona();
                            PersonaDAO personaRegistDAO = new PersonaDAO();

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

                            bool saved = personaRegistDAO.SavePersona(persona);

                            if (saved == false)
                            {
                                Console.WriteLine("Ah Ocurrido un error de guardado intente de nuevo");
                            }
                            else
                            {
                                Console.WriteLine("Persona guardada con exito \n");
                            }

                            menuNumber = 0;
                            break;
                        case 5:
                            endProgram = true;
                            break;
                    }
                }
            }
        }
    }
}
