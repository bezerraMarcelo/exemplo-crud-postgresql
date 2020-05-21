using biblioteca.modelo;
using biblioteca.dao;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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

        public void Alterar(Contato contato)
        {
            conexao.Open();
            try
            {
                string comando = "update contatos set nome = @p1, email = @p2, data_nascimento = @p3 where id = @p4";

                using (var cmd = new NpgsqlCommand(comando, conexao))
                {
                    cmd.Parameters.AddWithValue("p1", contato.Nome);
                    cmd.Parameters.AddWithValue("p2", contato.Email);
                    cmd.Parameters.AddWithValue("p3", contato.DataNascimento);
                    cmd.Parameters.AddWithValue("p4", contato.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Contato> Ler()
        {
            List<Contato> lista = new List<Contato>();
            string comando = "select * from contatos";

            using (var cmd = new NpgsqlCommand(comando, conexao))
            {
                conexao.Open();
                try
                {
                    var leitura = cmd.ExecuteReader();
                    while (leitura.Read())
                    {
                        Contato contato = new Contato();
                        CultureInfo CurrentCulture = new CultureInfo("pt-BR");
                        
                        contato.Id = Int32.Parse(leitura["id"].ToString());
                        contato.Nome = leitura["nome"].ToString();
                        contato.Email = leitura["email"].ToString();
                        
                        if (leitura["data_nascimento"].ToString() != "")
                        {
                            contato.DataNascimento = Convert.ToDateTime(leitura["data_nascimento"].ToString(), CurrentCulture);
                        }
                                                
                        lista.Add(contato);
                    }
                }
                finally
                {
                    conexao.Close();
                }
            }
            return lista;
        }

        public void Deletar(Int32 id)
        {
            conexao.Open();
            try
            {
                string comando = "delete from contatos where id = @p1";

                using (var cmd = new NpgsqlCommand(comando, conexao))
                {
                    cmd.Parameters.AddWithValue("p1", id);
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
