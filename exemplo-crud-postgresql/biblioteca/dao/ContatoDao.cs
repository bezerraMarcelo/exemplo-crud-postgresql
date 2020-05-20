using biblioteca.modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dao
{
    public class ContatoDao
    {
        private NpgsqlConnection conexao;

        public ContatoDao()
        {
            this.conexao = new FabricaConexoes().BuscarConexao();
        }

        public void Adicionar(Contato contato)
        {
            conexao.Open();
            try
            {
                string comando = "insert into contatos (nome, email, data_nascimento) values (@p1, @p2, @p3)";

                using (var cmd = new NpgsqlCommand(comando, conexao))
                {
                    cmd.Parameters.AddWithValue("p1", contato.Nome);
                    cmd.Parameters.AddWithValue("p2", contato.Email);
                    cmd.Parameters.AddWithValue("p3", contato.DataNascimento);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
