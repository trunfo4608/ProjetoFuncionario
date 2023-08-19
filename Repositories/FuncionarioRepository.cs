using Dapper;
using projetoAula04.Entities;
using projetoAula04.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula04.Repositories
{
    public class FuncionarioRepository
    {

        public void Create(Funcionario funcionario)
        {
      
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {

                var query = @"
                           INSERT INTO FUNCIONARIO(ID,NOME,CPF,MATRICULA,DATAADMISSAO,TIPOCONTRATACAO)
                           VALUES(@ID,@NOME,@CPF,@MATRICULA,@DATAADMISSAO,@TIPOCONTRATACAO) 
                         ";

                connection.Execute(query, new
                {
                    @ID = funcionario.Id,
                    @NOME = funcionario.Nome,
                    @CPF = funcionario.Cpf,
                    @MATRICULA = funcionario.Matricula,
                    @DATAADMISSAO = funcionario.DataAdmissao,
                    @TIPOCONTRATACAO = (int)funcionario.TipoContratacao
                });
            }

        }


        public void Update(Funcionario funcionario)
        {

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
               var query = @"
                           UPDATE FUNCIONARIO 
                           SET
                             NOME = @NOME,
                             CPF = @CPF,
                             DATAADMISSAO = @DATAADMISSAO
                             TIPOCONTRATACAO = @TIPOCONTRATACAO
                           WHERE ID =@ID
                          ";

                connection.Execute(query, new
                {
                    @NOME = funcionario.Nome,
                    @CPF = funcionario.Cpf,
                    @MATRICULA =funcionario.Matricula,
                    @DATAADMISSAO = funcionario.DataAdmissao,
                    @TIPOCONTRATACAO = funcionario.TipoContratacao,
                    @ID = funcionario.Id
                });
            }
        }


        public void Delete(Funcionario funcionario)
        {

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                var query = "DELETE FROM FUNCIONARIO WHERE ID =@ID";

                connection.Execute(query, new
                {
                    @ID = funcionario.Id
                });

            }

        }


        public List<Funcionario> GetAll()
        {
          

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString())) {

                var query = @"
                             SELECT ID,NOME,CPF,MATRICULA,DATAADMISSAO,TIPOCONTRATACAO
                             FROM FUNCIONARIO
                             ORDER BY NOME ASC 
                         ";
                return connection.Query<Funcionario>(query).ToList();
            }
        }


        public Funcionario GetById(Guid id)
        {
            var query = @"
                          SELECT ID,NOME,CPF,MATRICULA,DATAADMISSAO,TIPOCONTRATACAO
                          FROM FUNCIONARIO
                          WHERE ID =@ID
                         ";
            using(var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Funcionario>(query, new { @ID = id }).FirstOrDefault();
            }
        }
    }
}
