using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadraoRepositorio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            container.RegisterSingleton<IDB, MSSQL>();
            container.Register<IPessoaRepositorio, PessoaRepositorio>();
            var _REP = container.GetInstance<IPessoaRepositorio>();
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            var cpf = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            var telefone = Console.ReadLine();
            _REP.Cadastrar(new Pessoa {
                CPF = cpf,
                Nome = nome,
                Telefone = telefone
            });
            Console.Clear();
            foreach (var pessoa in _REP.Listar())
            {
                Console.WriteLine($"Id: {pessoa.Id} | Nome: {pessoa.Nome} | CPF: {pessoa.CPF} | Telefone: {pessoa.Telefone}");
            }
            Console.ReadKey();
        }
    }
}
