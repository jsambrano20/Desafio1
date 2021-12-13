using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_console_
{
    class Banco
    {
        private string stringConexao = "Data Source=localhost; Initial Catalog=desafio; User ID=desafio; password=Brasil@2451; Language=Portuguese;";
        private SqlConnection cn;

        private void conexao()//vincular a string com cn e iniciar o CN
        {
            cn = new SqlConnection(stringConexao);
        }

        public SqlConnection abrirConexao()
        {
            try
            {
                conexao();
                cn.Open();

                return cn;
                //tenta fazer algo 

            }
            catch (Exception ex)
            {
                return null;
                //faz algo se der erro
            }
        }
        public void fecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public DataTable executarConsultaG(string sql)
        {
            try
            {

                abrirConexao();

                SqlCommand command = new SqlCommand(sql, cn);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);//adapter preenche o datable com os dados do command

                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }
    }
}
