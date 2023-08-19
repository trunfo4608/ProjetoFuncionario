using projetoAula04.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula04
{
    class Program
    {
        static void Main(string[] args)
        {      

            Console.WriteLine("[1]Cadastrar Funcionario");
            Console.WriteLine("[2]Atualizar Funcionario");
            Console.WriteLine("[3]Excluir Funcionario");
            Console.WriteLine("[4]Consultar Funcionario");
            Console.WriteLine("[5]Sair do programa");

            Console.Write("\nInforme a opcao: ");
            var opcao = int.Parse(Console.ReadLine());

            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case 1:funcionarioController.CadastrarFuncionario();break;
                case 2: funcionarioController.AtualizarFuncionario(); break;
                case 3: funcionarioController.ExcluirFuncionario(); break;
                case 4: funcionarioController.ConsultarFuncionario(); break;
            }

            Console.Write("\nDeseja continuar[S]/[N]: ");
            var continuar = Console.ReadLine();

            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("\n Fim do programa");
            }

            Console.ReadLine();
        }
    }
}
