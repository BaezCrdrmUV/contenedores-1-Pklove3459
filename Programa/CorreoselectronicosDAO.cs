using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasConsoleRegister
{
    public class CorreoselectronicosDAO
    {
        Correoselectronicos correoselectronicos;
        private ConnecntionHandler connection;
        private MySqlConnection mySqlConnection;
        private MySqlCommand query;
        private MySqlDataReader reader;
        private List<Correoselectronicos> listaCorreos;

        public CorreoselectronicosDAO()
        {
            correoselectronicos = null;
            connection = new ConnecntionHandler();
            mySqlConnection = null;
            query = null;
            reader = null;
            listaCorreos = null;
        }


        /*public List<Correoselectronicos> GetCorreoselectronicosByCurp(string curp)
        {
            try
            {
                listaCorreos = new List<Correoselectronicos>();
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "SELECT * FROM Correoselectronicos WHERE CURP = @personCurp"
                };

                MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                {
                    Value = curp
                };

                query.Parameters.Add(PersonaCurp);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    correoselectronicos = new Correoselectronicos
                    {
                        Correo = reader.GetString(0),

                    };
                }
            }
            catch
            {

            }
        }
        */
    }
}
