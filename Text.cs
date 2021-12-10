using Desafio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_console_
{
    class Text
    {
        public int cl = 0;

        public bool leTXT()
        {
            try
            {

                StreamReader sr = new StreamReader("C:\\temp\\desafio.txt");
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    linha = sr.ReadLine();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Instanciaarquivo()
        {
            Pessoa pessoa = new Pessoa();

            Aluno aluno;
            Aluno alunx;

            
            try
            {

                StreamReader sr = new StreamReader("C:\\temp\\desafio.txt");
                string l1 = sr.ReadLine();

                while (l1 != null)
                {
                    cl++;
                    string[] l = l1.Split("-");
                    string letras = l[0];

                    if (letras == "X")
                    {
                        continue;

                    }
                    if (letras == "Z")
                    {
                        if (pessoa != null)
                        {
                            pessoa.gravarPessoa();
                        }
                        pessoa = new Pessoa();

                        pessoa.Nome = l[1];
                        pessoa.Telefone = l[2];
                        pessoa.Cidade = l[3];
                        pessoa.RG = l[4];
                        pessoa.CPF = l[5];

                        if (cl == 12 && pessoa != null)
                        {
                            pessoa.gravarPessoa();

                        }

                    }
                    else if (letras == "Y")
                    {
                        aluno = new Aluno();
                        alunx = new Aluno();
                        aluno.Nome = pessoa.Nome;
                        aluno.Telefone = pessoa.Telefone;
                        aluno.Cidade = pessoa.Cidade;
                        aluno.RG = pessoa.RG;
                        aluno.CPF = pessoa.CPF;
                        alunx.Matricula = l[1];
                        alunx.Cod_curso = l[2];
                        alunx.Nome_curso = l[3];

                        aluno.Matricula = alunx.Matricula;
                        aluno.Cod_curso = alunx.Cod_curso;
                        aluno.Nome_curso = alunx.Nome_curso;

                        alunx.gravarAluno();
                        pessoa = null;
                    }

                    l1 = sr.ReadLine();

                }
                return true;

            }
            catch (Exception e)
            {
                
                return false;
            }
        }
    }
}
