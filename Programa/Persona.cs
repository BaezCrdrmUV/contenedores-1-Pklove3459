using System;

namespace PersonasConsoleRegister
{
    public class Persona
    {
        private string curp;
        private string nombre;
        private string apellido;
        private string estatura;
        private string peso;

        public Persona() { }

        public string Curp
        {
            get => curp;
            set => curp = value;
        }

        public String Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public String Apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public String Estatura
        {
            get => estatura;
            set => estatura= value;
        }

        public String Peso
        {
            get => peso;
            set => peso = value;
        }
    }
}