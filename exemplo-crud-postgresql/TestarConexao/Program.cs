using System;
using biblioteca;
using Npgsql;

namespace TestarConexao
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection conexao = new FabricaConexoes().BuscarConexao();
            conexao.Open();
            Console.WriteLine("Conexão aberta!");
            conexao.Close();
        }
    }
}
