using biblioteca.dao;
using biblioteca.modelo;
using System;
using System.Collections.Generic;

namespace TestarLer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contato> contatos;

            ContatoDao dao = new ContatoDao();

            contatos = dao.Ler();

            foreach (Contato contato in contatos)
            {
                Console.Out.WriteLine("Nome :" + contato.Nome + " - Data de nascimento :" + contato.DataNascimento.ToString());
            }
        }
    }
}
