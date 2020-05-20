using biblioteca.modelo;
using biblioteca.dao;
using System;

namespace TestarAdicionar
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato contato = new Contato();

            contato.Nome = "Rafael";
            contato.Email = "rafael@teste.com.br";
            contato.DataNascimento = Convert.ToDateTime("2017-05-30");

            ContatoDao dao = new ContatoDao();

            dao.Adicionar(contato);

            Console.Out.WriteLine("Gravado!");
        }
    }
}
