using System;
using System.Collections.Generic;

namespace PersonasConsoleRegister
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool endProgram = false;
            int menuNumber = 0;
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
                        CorreoselectronicosDAO correosConsultDAO = new CorreoselectronicosDAO();
                        DireccionesDAO direccionesConsultDAO = new DireccionesDAO();


                        Console.WriteLine("Ingrese el CURP de la persona a buscar\n");
                        string curp = Console.ReadLine();

                        Persona personaCheck = new Persona();
                        personaCheck = personaConsultDAO.GetPersonaByCURP(curp);

                        List<Correoselectronicos> listaCorreos = new List<Correoselectronicos>();
                        listaCorreos = correosConsultDAO.GetCorreoselectronicosByCurp(curp);

                        List<Direcciones> listaDireccion = new List<Direcciones>();
                        listaDireccion = direccionesConsultDAO.GetDireccionesByCurp(curp);

                        if (personaCheck != null)
                        {
                            Console.WriteLine("\n ------------------------------");
                            Console.WriteLine("Curp: " + personaCheck.Curp + " \n");
                            Console.WriteLine("Nombre:" + personaCheck.Nombre + " " + personaCheck.Apellido + " \n");
                            Console.WriteLine("Estatura:" + personaCheck.Estatura + " " + "Peso: " + personaCheck.Peso + " \n");
                            Console.WriteLine("--------------------------------\n");

                            foreach (Direcciones direccion in listaDireccion)
                            {
                                if (direccion != null)
                                {
                                    Console.WriteLine("Direccion: " + direccion.Direccion);
                                }
                            }

                            Console.WriteLine("\n ------------------------------");

                            foreach (Correoselectronicos correoselectronicosos in listaCorreos)
                            {
                                if (correoselectronicosos !=null)
                                {
                                    Console.WriteLine("Correo: " + correoselectronicosos.Correo);
                                }
                            }

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
                        Persona personaUpdate = new Persona();
                        Direcciones direccionesUpdate = new Direcciones();
                        Correoselectronicos correoselectronicosUpdate = new Correoselectronicos();

                        PersonaDAO personaUpdateDAO = new PersonaDAO();
                        DireccionesDAO direccionesUpdateDAO = new DireccionesDAO();
                        CorreoselectronicosDAO correoselectronicosUpdateDAO = new CorreoselectronicosDAO();

                        int action = 0;

                        Console.WriteLine("Ingrese el CURP de la persona a actualizar\n");
                        string updateCurp = Console.ReadLine();
                        personaUpdate = personaUpdateDAO.GetPersonaByCURP(updateCurp);

                        if (personaUpdate != null)
                        {

                            Console.WriteLine("Digite el numero de la accion que desea realizar \n");
                            Console.WriteLine("1- AgregarCorreo \n");
                            Console.WriteLine("2- AgregarDomicilio \n");
                            Console.WriteLine("3- Actualizar Datos Personales \n");
                            
                            action = Convert.ToInt32(Console.ReadLine());

                            switch (action)
                            {
                                case 1:
                                    Console.WriteLine("Ingrese el correo a agregar");
                                    correoselectronicosUpdate.Correo = Console.ReadLine();
                                    correoselectronicosUpdate.Curp = updateCurp;
                                    correoselectronicosUpdateDAO.SaveCorreosElectronico(correoselectronicosUpdate);
                                    break;
                                case 2:
                                    Console.WriteLine("Ingrese el domicilio a agregar");
                                    direccionesUpdate.Direccion = Console.ReadLine();
                                    direccionesUpdate.Curp = updateCurp;
                                    direccionesUpdateDAO.SaveDireccion(direccionesUpdate);
                                    break;
                                case 3:
                                    Console.WriteLine("Ingrese el nuevo Nombre de la persona");
                                    personaUpdate.Nombre = Console.ReadLine();

                                    Console.WriteLine("Ingrese el nuevo Apellido de la persona");
                                    personaUpdate.Apellido = Console.ReadLine();

                                    Console.WriteLine("Ingrese el nuevo Estatura de la persona");
                                    personaUpdate.Estatura = Console.ReadLine();

                                    Console.WriteLine("Ingrese el nuevo Peso de la persona");
                                    personaUpdate.Peso = Console.ReadLine();

                                    personaUpdateDAO.UpdatePersona(personaUpdate);
                                    break;
                            }
                            Console.WriteLine("Accion realizada");
                        }
                        else
                        {
                            Console.WriteLine("Esa persona no existe, o ha ingresado mal el curp intente mas tarde \n");
                        }

                        menuNumber = 0;

                        break;
                    case 4:
                        Persona persona = new Persona();
                        Direcciones direcciones = new Direcciones();
                        Correoselectronicos correoselectronicos = new Correoselectronicos();

                        PersonaDAO personaRegistDAO = new PersonaDAO();
                        DireccionesDAO direccionesRegistroDAO = new DireccionesDAO();
                        CorreoselectronicosDAO correoselectronicosRegistroDAO = new CorreoselectronicosDAO();

                        Console.WriteLine("Ingrese el CURP de la persona a registrar");
                        persona.Curp = Console.ReadLine();
                        correoselectronicos.Curp = persona.Curp;
                        direcciones.Curp = persona.Curp;

                        Console.WriteLine("Ingrese el Nombre de la persona a registrar");
                        persona.Nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el Apellido de la persona a registrar");
                        persona.Apellido = Console.ReadLine();

                        Console.WriteLine("Ingrese el Estatura de la persona a registrar");
                        persona.Estatura = Console.ReadLine();

                        Console.WriteLine("Ingrese el Peso de la persona a registrar");
                        persona.Peso = Console.ReadLine();

                        Console.WriteLine("Ingrese un correo para la persona a registrar");
                        correoselectronicos.Correo = Console.ReadLine();

                        Console.WriteLine("Ingrese una direccion para la persona a registrar");
                        direcciones.Direccion = Console.ReadLine();

                        bool saved = personaRegistDAO.SavePersona(persona);
                        direccionesRegistroDAO.SaveDireccion(direcciones);
                        correoselectronicosRegistroDAO.SaveCorreosElectronico(correoselectronicos);


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
