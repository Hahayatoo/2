using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtPreco.Clear();
            cmbCategoria.SelectedIndex = -1;
        }

        // ---------- CREATE (Cadastrar) - Parte 2 ----------
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto objProduto = new Produto();
                objProduto.Nome = txtNomeProduto.Text;
                objProduto.Preco = double.Parse(txtPreco.Text);
                objProduto.Categoria = cmbCategoria.Text;

                Conexao banco = new Conexao();
                MySqlConnection conexaoAberta = banco.conectarBD();

                string sql = "INSERT INTO produtos (nome, preco, categoria) VALUES (@nome, @preco, @categoria)";

                MySqlCommand comando = new MySqlCommand(sql, conexaoAberta);
                comando.Parameters.AddWithValue("@nome", objProduto.Nome);
                comando.Parameters.AddWithValue("@preco", objProduto.Preco);
                comando.Parameters.AddWithValue("@categoria", objProduto.Categoria);

                comando.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");

                LimparCampos();
                conexaoAberta.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
    }
}
