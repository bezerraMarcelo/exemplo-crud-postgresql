using biblioteca.dao;
using System;

namespace TestarDeletar
{
    class Program
    {
        static void Main(string[] args)
        {
            ContatoDao dao = new ContatoDao();

            dao.Deletar(1);

            Console.Out.WriteLine("Deletado!");

            Console.ReadKey();
        }
    }
}
