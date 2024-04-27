using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class DAOLivro
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public long[] codigo;
        public string[] titulo;
        public string[] autor;
        public string[] editora;
        public string[] genero;
        public string[] isbn;
        public string[] preco;
        public string[] situacao;
        public int i;
        public int contador;
        public string msg;
        //Construtor
        public DAOLivro()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=livrariaTI20N;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Abrir a conexão
                Console.WriteLine("Conectado!");//Teste
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
                conexao.Close();//Fechar a conexão com o banco
            }
        }//fim do construtor

        public void Inserir(long codigo, string titulo, string autor, string editora,
                           string genero, string isbn,
                           int preco, string posicao)
        {
            try
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                //Declarei as variáveis e preparei o comando
                dados = $"('{codigo}','{titulo}','{autor}','{editora}','{genero}'," +
                        $"'{preco}','{situacao}','{posicao}')";
                comando = $"Insert into pessoa values {dados}";
                //Engatilhar a inserção do banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();//Ctrl + Enter
                                                              //Mostrar na tela
                Console.WriteLine(resultado + " linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
            }
        }//fim do método

        public void PreencherVetor()
        {
            string query = "select * from pessoa";//Coletar os dados do banco

            //Instanciar
            codigo = new long[100];
            titulo = new string[100];
            autor = new string[100];
            editora = new string[100];
            genero = new string[100];
            isbn = new string[100];
            situacao = new string[100];

            //Preencher
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                autor[i] = "";
                editora[i] = "";
                genero[i] = "";
                isbn[i] = "";
                situacao[i] = "";           
            }//fim do for

            //Preparar o comando do select
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt64(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + "";
                autor[i] = leitura["autor"] + "";
                editora[i] = leitura["editora"] + "";
                //Convertendo para o padrão de dia/mes/ano
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
              
                genero[i] = leitura["genero"] + "";
                isbn[i] = leitura["isbn"] + "";
                situacao[i] = leitura["situacao"] + "";      
                i++;
                contador++;
            }//fim do while
            leitura.Close();//Fecha a conexão com o banco
        }//fim do método

        public string ConsultarTudo()
        {
            PreencherVetor();//Preenche os vetores
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += "\nCodigo: " + codigo[i] +
                       ", titulo: " + titulo[i] +
                       ", autor: " + autor[i] +
                       ", editora: " + editora[i] +
                       ", genero: " + genero[i] +
                       ", isbn: " + isbn[i] +
            
                       ", situação: " + situacao[i];
            }//fim do for

            return msg;
        }//fim do método


        public string ConsultarIndividual(long codCPF)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (titulo[i] == codtitulo)
                {
                    msg = "CPF: " + CPF[i] +
                          ", nome: " + nome[i] +
                          ", telefone: " + telefone[i] +
                          ", endereco: " + endereco[i] +
                          ", nascimento: " + dtNascimento[i] +
                          ", login: " + login[i] +
                          ", senha: " + senha[i] +
                          ", situacao: " + situacao[i] +
                          ", cargo: " + posicao[i];

                    return msg;
                }//fim do if 
            }//fim do for

            return "Codigo Informado não é valido!!";
        }//fim da consultarindividual

        public string Atualizar(long codCPF, string campo, string novoDado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + novoDado + "' where CPF = '" + codCPF + "'";
                //Exceutar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "linha afetada: ";
            }
            catch (Exception ex)
            {
                return "Algo deu errado!!\n\n\n" + ex;
            }
        }

        public string Atualizar(long codCPF, string campo, DateTime novoDado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + novoDado + "' where CPF = '" + codCPF + "'";
                //Exceutar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "linha afetada: ";
            }
            catch (Exception ex)
            {
                return "Algo deu errado!!\n\n\n" + ex;
            }
        }

        public string Excluir(long codCPF)
        {
            try
            {
                string query = "update pessoa set situacao = ' Inativo ' where CPF = '" + codCPF + "'";
                //Exceutar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "linha afetada: ";
            }
            catch (Exception ex)
            {
                return "Algo deu errado!!\n\n\n" + ex;
            }
        }


    }
}  
