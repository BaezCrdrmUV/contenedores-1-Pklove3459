using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasConsoleRegister
{
    public class Correoselectronicos
    {
        private int idCorreosElectronico;
        private string curp;
        private string correo;

        public Correoselectronicos() { }

        public int IdCorreosElectronico
        {
            get => idCorreosElectronico;
            set => idCorreosElectronico = value;
        }
        public string Curp
        {
            get => curp;
            set => curp = value;
        }
        public string Correo
        {
            get => correo;
            set => correo = value;
        }
    }
}
