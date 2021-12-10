using Desafio_console_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, string telefone, string cidade, string rg, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            Cidade = cidade;
            RG = rg;
            CPF = cpf;
        }

        public bool gravarPessoa()
        {
            Banco banco = new Banco();
            SqlConnection cn = banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into pessoa values (@nome, @telefone, @cidade, @rg, @cpf);";
            command.Parameters.Add("@nome", SqlDbType.VarChar);
            command.Parameters.Add("@telefone", SqlDbType.VarChar);
            command.Parameters.Add("@cidade", SqlDbType.VarChar);
            command.Parameters.Add("@rg", SqlDbType.VarChar);
            command.Parameters.Add("@cpf", SqlDbType.VarChar);
            command.Parameters[0].Value = Nome;
            command.Parameters[1].Value = Telefone;
            command.Parameters[2].Value = Cidade;
            command.Parameters[3].Value = RG;
            command.Parameters[4].Value = CPF;

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

