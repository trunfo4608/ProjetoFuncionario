using projetoAula04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projetoAula04.Entities
{
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private TipoContratacao _tipoContratacao;


        public Guid Id {
            set {

                if (value == Guid.Empty)
                    throw new ArgumentException("Id funcionário não pode ser vazio !");

                _id = value; 
            }


            get { return _id; }
        }

        public string Nome {
            set { 
                
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome funcionário não pode ser vazio !");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Preencha um nome válido de 8 a 100 caracteres.");

                _nome = value; 
            }


            get { return _nome; }
        }

        public string Cpf {
            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Cpf funcionário não pode ser vazio !");

                var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um Cpf no formato: '999.999.999-99'");


                _cpf = value;
            
            }
            get { return _cpf; }
        }

        public string Matricula {
            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Matricula funcionário não pode ser vazio !");


                var regex = new Regex("^[A-Z0-9]{6,10}");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe uma matrícula válida com no mín. 6 e no máx. 10 dígitos !");


                _matricula = value; 
            
            }
            get { return _matricula; }
        }

        public DateTime DataAdmissao {
            set { 
                
                
                if(value == null)
                    throw new ArgumentException("Matricula funcionário não pode ser vazio !");


                _dataAdmissao = value; 
            
            }

            get { return _dataAdmissao; }
        }


        public TipoContratacao TipoContratacao {

            set {

                if(value == null)
                    throw new ArgumentException("Contratação funcionário não pode ser vazio !");

                
                _tipoContratacao = value;
            }

            get { return _tipoContratacao; }
        }
    }
}
