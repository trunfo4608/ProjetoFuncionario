using projetoAula04.Entities;
using projetoAula04.Enums;
using projetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula04.Controllers
{
    public class FuncionarioController
    {

        public void CadastrarFuncionario()
        {

            try
            {

                Console.WriteLine("\nCadastro de funcionario");

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();
                Console.Write("\nNome do funcionario............: ");
                funcionario.Nome = Console.ReadLine();
                Console.Write("\nCpf do funcionario..............: ");
                funcionario.Cpf = Console.ReadLine();
                Console.Write("\nMatricula do funcionario.........: ");
                funcionario.Matricula = Console.ReadLine();
                Console.Write("\nDt.Admissao do funcionario.......: ");
                funcionario.DataAdmissao =DateTime.Parse(Console.ReadLine());
                Console.Write("\nTp.Contratacao [1]Estagio / [2]Clt / [3]Terceirizado.......: ");
                funcionario.TipoContratacao =(TipoContratacao) int.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nCadastrado com sucesso !");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação: " +e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("\nErro ao cadastrar: " +e.Message);
            }
        }

        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\nAtualizacao de funcionario");

                Console.Write("Id do funcionario.......:");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if(funcionario != null)
                {        

                    Console.Write("\nNome do funcionario............: ");
                    funcionario.Nome = Console.ReadLine();
                    Console.Write("\nCpf do funcionario..............: ");
                    funcionario.Cpf = Console.ReadLine();
                    Console.Write("\nMatricula do funcionario.........: ");
                    funcionario.Matricula = Console.ReadLine();
                    Console.Write("\nDt.Admissao do funcionario.......: ");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());
                    Console.Write("\nTp.Contratacao [1]Estagio / [2]Clt / [3]Terceirizado.......: ");
                    funcionario.TipoContratacao = (TipoContratacao)int.Parse(Console.ReadLine());

                    funcionarioRepository.Update(funcionario);

                    Console.WriteLine("\nFuncionario atualizado com sucesso !");
                }
                else
                {
                    Console.WriteLine("\nFuncionario nao encontrado !");
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação: " + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("\nErro ao cadastrar: " + e.Message);
            }

        }

        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\nExclusao Funcionario");

                Console.Write("Id do funcionario.......:");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);
                

                if(funcionario != null) {

                    funcionarioRepository.Delete(funcionario);
                    Console.WriteLine("\nFuncionario excluido com sucesso !");
                }
                else
                {
                    Console.WriteLine("\nFuncionario nao encontrado !");
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação: " + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("\nErro ao cadastrar: " + e.Message);
            }
        }


        public void ConsultarFuncionario()
        {

            try
            {
                Console.WriteLine("\nConsulta de funcionario");
                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("Id funcionario....: " + item.Id);
                    Console.WriteLine("Nome..............: " + item.Nome);
                    Console.WriteLine("Matricula.........: " + item.Matricula);
                    Console.WriteLine("Tp.Contratacao....: " + item.TipoContratacao);
                    Console.WriteLine("Dt.Admissao.......: " + item.DataAdmissao);
                    Console.WriteLine("....");
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("\nFalha na pesquisa !");
                Console.WriteLine("Erro: " +e.Message);
            }
        }
    }
}
