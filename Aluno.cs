using Desafio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_console_
{
    class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public string Cod_curso { get; set; }
        public string Nome_curso { get; set; }

        public Aluno()
        {

        }

        public Aluno(string matricula, string codigo, string nomecurso, string nome, string telefone, string cidade, string rg, string cpf)
            
        {
            Matricula = matricula;
            Cod_curso = codigo;
            Nome_curso = nomecurso;

        }
        public bool gravarAluno()
        {
            Banco banco = new Banco();
            SqlConnection cn = banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into aluno values (@nome, @telefone, @cidade, @rg, @cpf, @matricula, @cod_curso, @nome_curso );";
            command.Parameters.Add("@nome", SqlDbType.VarChar);
            command.Parameters.Add("@telefone", SqlDbType.VarChar);
            command.Parameters.Add("@cidade", SqlDbType.VarChar);
            command.Parameters.Add("@rg", SqlDbType.VarChar);
            command.Parameters.Add("@cpf", SqlDbType.VarChar);
            command.Parameters.Add("@matricula", SqlDbType.VarChar);
            command.Parameters.Add("@cod_curso", SqlDbType.VarChar);
            command.Parameters.Add("@nome_curso", SqlDbType.VarChar);
            command.Parameters[0].Value = Nome;
            command.Parameters[1].Value = Telefone;
            command.Parameters[2].Value = Cidade;
            command.Parameters[3].Value = RG;
            command.Parameters[4].Value = CPF;
            command.Parameters[5].Value = Matricula;
            command.Parameters[6].Value = Cod_curso;
            command.Parameters[7].Value = Nome_curso;

            try
            {
                command.ExecuteNonQuery();
                tran.Commit();
                return true;

            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                banco.fecharConexao();
            }

        }


    }

}

