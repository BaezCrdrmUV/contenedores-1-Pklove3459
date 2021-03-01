using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasConsoleRegister
{
    public class Direcciones
    {
        private int idDirecciones;
        private string curp;
        private string direcciones;

        public Direcciones() { }

        public int IdDirecciones
        {
            get => idDirecciones;
            set => idDirecciones = value;
        }
        public string Curp
        {
            get => curp;
            set => curp = value;
        }
        public string Direccion
        {
            get => direcciones;
            set => direcciones = value;
        }
    }
}
