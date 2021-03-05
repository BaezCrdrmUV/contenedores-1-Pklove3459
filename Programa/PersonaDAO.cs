using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PersonasConsoleRegister
{
    public class PersonaDAO
    {
        private Persona persona;
        private ConnecntionHandler connection;
        private MySqlConnection mySqlConnection;
        private MySqlCommand query;
        private MySqlDataReader reader;

        public PersonaDAO()
        {
            persona = null;
            connection = new ConnecntionHandler();
            mySqlConnection = null;
            query = null;
            reader = null;
        }

        public Persona GetPersonaByCURP(string curp)
        {
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "SELECT * FROM Persona WHERE CURP = @personCurp"
                };

                MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                {
                    Value = curp
                };

                query.Parameters.Add(PersonaCurp);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    persona = new Persona
                    {
                        Curp = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        Apellido= reader.GetString(2),
                        Estatura = reader.GetString(3),
                        Peso = reader.GetString(4)
                    };
                }
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
            return persona;
        }

        public bool SavePersona(Persona persona)
        {
            bool isSaved = false;
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "INSERT INTO Persona(CURP, Nombre, Apellido, Estatura, Peso) " +
                    "VALUES (@curp, @nombre, @apellido, @estatura, @peso)"
                };

                MySqlParameter curp = new MySqlParameter("@curp", MySqlDbType.VarChar, 45)
                {
                    Value = persona.Curp
                };

                MySqlParameter nombre = new MySqlParameter("@nombre", MySqlDbType.VarChar, 45)
                {
                    Value = persona.Nombre
                };

                MySqlParameter apellido = new MySqlParameter("@apellido", MySqlDbType.VarChar, 45)
                {
                    Value = persona.Apellido
                };

                MySqlParameter estatura = new MySqlParameter("@estatura", MySqlDbType.VarChar, 45)
                {
                    Value = persona.Estatura
                };

                MySqlParameter peso = new MySqlParameter("@peso", MySqlDbType.VarChar, 45)
                {
                    Value = persona.Peso
                };

                query.Parameters.Add(curp);
                query.Parameters.Add(nombre);
                query.Parameters.Add(apellido);
                query.Parameters.Add(estatura);
                query.Parameters.Add(peso);

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

        public bool DeletePersonaByCURP(string curp)
        {
            bool isSaved = false;
            if (DeletePersonaAddress(curp))
            {
                if (DeletePersonaMails(curp))
                {
                    try
                    {
                        mySqlConnection = connection.OpenConnection();
                        query = new MySqlCommand("", mySqlConnection)
                        {
                            CommandText = "DELETE FROM Persona WHERE CURP = @personCurp"
                        };


                        MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                        {
                            Value = curp
                        };

                        query.Parameters.Add(PersonaCurp);
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
                }
            }
            return isSaved;
        }

        public bool DeletePersonaMails(string curp)
        {
            bool isDeleted = false;
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "DELETE FROM Correoselectronicos WHERE CURP = @personCurp"
                };


                MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                {
                    Value = curp
                };

                query.Parameters.Add(PersonaCurp);
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

        public bool DeletePersonaAddress(string curp)
        {
            bool isDeleted = false;
            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "DELETE FROM Direcciones WHERE CURP = @personCurp"
                };


                MySqlParameter PersonaCurp = new MySqlParameter("@personCurp", MySqlDbType.VarChar, 45)
                {
                    Value = curp
                };

                query.Parameters.Add(PersonaCurp);
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
    }
}

