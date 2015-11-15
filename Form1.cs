using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace testeDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*A variável strcon é o connection string que copiamos anteriormente enquanto criávamos o banco de dados, 
             * essa variável poderia ser utilizada para todos os botões do programa, 
             * mas irei repeti-la várias vezes para fixar a idéia dos passos que precisamos seguir para fazer a conexão
             * com o banco, Obs.: note que o caminho do seu banco precisa estar com “\\” se não estiver coloque */ 
            string strcon = "Data Source=localhost;initial catalog=banco;User Id=alan;Password=123456"; 
            SqlConnection conexao = new SqlConnection(strcon); /* conexao irá conectar o C# ao banco de dados */ 
            SqlCommand cmd = new SqlCommand("SELECT * FROM aluno", conexao); /*cmd possui mais de um parâmetro, neste caso coloquei o comando SQL "SELECT * FROM tabela" que irá selecionar tudo(*) de tabela, o segundo parâmetro indica onde o banco está conectado,ou seja se estamos selecionando informações do banco precisamos dizer onde ele está localizado */ 
            
            try
            {        
                conexao.Open(); // abre a conexão com o banco 
                cmd.ExecuteNonQuery(); // executa cmd 
                /*Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, agora os passos seguintes irão exibir as informações para que o usuário possa vê-las */ 
                SqlDataAdapter da = new SqlDataAdapter(); 
                /* da, adapta o banco de dados ao nosso projeto */ 
                DataSet ds = new DataSet(); 
                da.SelectCommand = cmd; // adapta cmd ao projeto 
                da.Fill(ds); // preenche todas as informações dentro do 
                dataGridView1.DataSource = ds; //Datagridview recebe ds já preenchido 
                dataGridView1.DataMember = ds.Tables[0].TableName; /*Agora Datagridview exibe o banco de dados*/ 
            }
            catch (Exception ex) 
            { 
               MessageBox.Show("Erro "+ex.Message); 
               throw; 
            } 
            
            finally
            { 
                conexao.Close(); /* Se tudo ocorrer bem fecha a conexão com o banco da dados, sempre é bom fechar a conexão após executar até o final o que nos interessa, isso pode evitar problemas futuros */ 
            } 
        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            string strcon = "Data Source=localhost;initial catalog=banco;User Id=alan;Password=123456"; 
            SqlConnection conexao = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("INSERT INTO aluno(nome,matricula, nota) VALUES('" + textBox1.Text + "'," + textBox2.Text + "," + textBox3.Text+ ")", conexao); 
            try { 
                conexao.Open(); 
                cmd.ExecuteNonQuery();
            } catch (Exception ex) 
            { 
                MessageBox.Show("Erro " + ex.Message);
                throw; 
            } 
            finally { 
                conexao.Close(); 
            } 


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strcon = "Data Source=localhost;initial catalog=banco;User Id=alan;Password=123456";
            SqlConnection conexao = new SqlConnection(strcon); /* conexao irá conectar o C# ao banco de dados */
            SqlCommand cmd = new SqlCommand("DELETE FROM aluno WHERE matricula=" + textBox4.Text + " ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strcon = "Data Source=localhost;initial catalog=banco;User Id=alan;Password=123456";
            SqlConnection conexao = new SqlConnection(strcon); /* conexao irá conectar o C# ao banco de dados */
            SqlCommand cmd = new SqlCommand("UPDATE aluno SET nota=" + textBox6.Text + "WHERE matricula=" + textBox5.Text + " ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally
            {
                conexao.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
