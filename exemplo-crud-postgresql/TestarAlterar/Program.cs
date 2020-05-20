using biblioteca.dao;
using biblioteca.modelo;
using System;

namespace TestarAlterar
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato contato = new Contato();

            contato.Id = 3;
            contato.Nome = "Marcelo Bezerra";
            contato.Email = "teste@teste.com.br";
            contato.DataNascimento = Convert.ToDateTime("1980-01-01");

            ContatoDao dao = new ContatoDao();

            dao.Alterar(contato);

            Console.Out.WriteLine("Alterado!");
        }
    }
}
