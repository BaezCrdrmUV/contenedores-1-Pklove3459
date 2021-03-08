using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasConsoleRegister
{
    class DireccionesDAO
    {

        Direcciones direcciones;
        private ConnecntionHandler connection;
        private MySqlConnection mySqlConnection;
        private MySqlCommand query;
        private MySqlDataReader reader;
        private List<Direcciones> listaDirecciones;

        public DireccionesDAO()
        {
            direcciones = null;
            connection = new ConnecntionHandler();
            mySqlConnection = null;
            query = null;
            reader = null;
            listaDirecciones = null;
        }


        public List<Direcciones> GetDireccionesByCurp(string curp)
        {
            try
            {
                listaDirecciones = new List<Direcciones>();
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "SELECT * FROM Direcciones WHERE CURP = @personCurp"
                };

                MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                {
                    Value = curp
                };

                query.Parameters.Add(PersonaCurp);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    direcciones = new Direcciones
                    {
                        IdDirecciones = reader.GetInt32(0),
                        Curp = reader.GetString(1),
                        Direccion = reader.GetString(2)

                    };
                }

                listaDirecciones.Add(direcciones);
            }
            catch (MySqlException ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                connection.CloseConnection();
            }
            return listaDirecciones;
        }

        public bool DeleteDirecciones(string direccion)
        {
            bool isDeleted = false;

            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "DELETE FROM Direcciones WHERE direcciones = @personaDireccion"
                };


                MySqlParameter PersonaDireccion = new MySqlParameter("@personaDireccion", MySqlDbType.VarChar, 45)
                {
                    Value = direccion
                };

                query.Parameters.Add(PersonaDireccion);
                query.ExecuteNonQuery();
                isDeleted = true;

            }
            catch (MySqlException ex)
            {
                throw;
            }
            finally
            {
                connection.CloseConnection();
            }

            return isDeleted;
        }

        public bool SaveDireccion(Direcciones direcciones)
        {
            bool isSaved = false;
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "INSERT INTO Direcciones(Curp, direcciones) " +
                    "VALUES (@curp, @direcciones)"
                };

                MySqlParameter curp = new MySqlParameter("@curp", MySqlDbType.VarChar, 45)
                {
                    Value = direcciones.Curp
                };

                MySqlParameter direccion = new MySqlParameter("@direcciones", MySqlDbType.VarChar, 45)
                {
                    Value = direcciones.Direccion
                };

                query.Parameters.Add(curp);
                query.Parameters.Add(direccion);

                query.ExecuteNonQuery();

                isSaved = true;
            }
            catch (MySqlException ex)
            {
                throw;
            }
            finally
            {
                connection.CloseConnection();
            }
            return isSaved;
        }

    }
}
