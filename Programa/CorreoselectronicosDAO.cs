﻿using MySql.Data.MySqlClient;
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


        public List<Correoselectronicos> GetCorreoselectronicosByCurp(string curp)
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
                        IdCorreosElectronico = reader.GetInt32(0),
                        Curp = reader.GetString(1),
                        Correo = reader.GetString(2)

                    };
                }

                listaCorreos.Add(correoselectronicos);
            }
            catch(MySqlException ex)
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
            return listaCorreos;
        }

        public bool DeleteCorreoElectronico(string correo)
        {
            bool isDeleted = false;

            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "DELETE FROM Correoselectronicos WHERE correo = @personaCorreo"
                };


                MySqlParameter PersonaCorreo = new MySqlParameter("@personaCorreo", MySqlDbType.VarChar, 45)
                {
                    Value = correo
                };

                query.Parameters.Add(PersonaCorreo);
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

        public bool SaveCorreosElectronico(Correoselectronicos correos)
        {
            bool isSaved = false;
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "INSERT INTO Correoselectronicos(Curp, correo) " +
                    "VALUES (@curp, @correo)"
                };

                MySqlParameter curp = new MySqlParameter("@curp", MySqlDbType.VarChar, 45)
                {
                    Value = correos.Curp
                };

                MySqlParameter correo = new MySqlParameter("@correo", MySqlDbType.VarChar, 45)
                {
                    Value = correos.Correo
                };

                query.Parameters.Add(curp);
                query.Parameters.Add(correo);

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
