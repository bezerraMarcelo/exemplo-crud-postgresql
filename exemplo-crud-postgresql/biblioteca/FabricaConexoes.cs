using System;
using Npgsql;

namespace biblioteca
{
    public class FabricaConexoes
    {
        public NpgsqlConnection BuscarConexao()
        {
            try
            {
                string stringConexao = "server=localhost;port=5432;user id=postgres;password=root;database=Cliente";
                return new NpgsqlConnection(stringConexao);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("Erro ao conectar ao banco de dados " + e.Message);
            } 
        }
    }
}
