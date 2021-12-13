using Desafio_console_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btLer_Click(object sender, EventArgs e)
        {
            Text t = new Text();
            t.gravarTxt();
            t.leTXT();
            MessageBox.Show("Inseridos " + t.cl + " Pessoas e " + t.cl + " Alunos ");
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {  
            Banco banco = new Banco();
            string sql = "select * from aluno";
            DataTable dt = new DataTable();
            dt = banco.executarConsultaG(sql);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco banco = new Banco();
            string sql = "select * from pessoa";
            DataTable dt = new DataTable();
            dt = banco.executarConsultaG(sql);

            dataGridView2.DataSource = dt;
        }
    }
}
    
