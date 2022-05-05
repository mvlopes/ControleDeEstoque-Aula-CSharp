using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
            CarregarGrid();

            textBoxIDProduto.Enabled = false;
            textBoxNomeProduto.Enabled = false;
            textBoxQuantidade.Enabled = false;
            textBoxMarca.Enabled = false;
            textBoxPreco.Enabled = false;

            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void CarregarGrid()
        {
            Model model = new Model();
            List<dtoProduto> lista = model.GetProdutos();
            this.dataGridViewProduto.DataSource = lista;
            this.dataGridViewProduto.Refresh();
        }

        private void clean()
        {
            textBoxIDProduto.Enabled = false;
            textBoxNomeProduto.Enabled = false;
            textBoxQuantidade.Enabled = false;
            textBoxMarca.Enabled = false;
            textBoxPreco.Enabled = false;

            textBoxIDProduto.Text = string.Empty;
            textBoxNomeProduto.Text = string.Empty;
            textBoxQuantidade.Text = string.Empty;
            textBoxMarca.Text = string.Empty;
            textBoxPreco.Text = string.Empty;

            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;

            error.Text = string.Empty;
        }

        //Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            clean();
            textBoxIDProduto.Enabled = false;
            textBoxIDProduto.Text = string.Empty;
            textBoxNomeProduto.Enabled = true;
            textBoxQuantidade.Enabled = true;
            textBoxMarca.Enabled = true;
            textBoxPreco.Enabled = true;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        //Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            dtoProduto u = new dtoProduto();
            u.nome = textBoxNomeProduto.Text;
            u.quantidade = int.Parse(textBoxQuantidade.Text);
            u.marca = textBoxMarca.Text;
            u.preco = decimal.Parse(textBoxPreco.Text);

            if (textBoxIDProduto.Text == String.Empty)
            {
                model.setProduto(u);
            }
            else
            {
                u.id = int.Parse(textBoxIDProduto.Text);
                model.EditProduto(u);
            }

            CarregarGrid();
            clean();
        }

        //Deletar
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            model.DeletarProduto(int.Parse(textBoxIDProduto.Text));
            clean();
            CarregarGrid();
        }

        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void errorMsg(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewProduto.CurrentRow.Cells[0].Value;

            Model model = new Model();
            dtoProduto u = model.GetProdutosId(id);

            dtoVenda v = model.GetVendaId(id);

            if (v != null)
            {
                btnExcluir.Enabled = false;
                error.Text = "Venda pendente de produto!";
            }
            else
            {
                btnExcluir.Enabled = true;
            }

            textBoxNomeProduto.Enabled = true;
            textBoxQuantidade.Enabled = true;
            textBoxMarca.Enabled = true;
            textBoxPreco.Enabled = true;

            textBoxIDProduto.Text = u.id.ToString();
            textBoxNomeProduto.Text = u.nome;
            textBoxQuantidade.Text = u.quantidade.ToString();
            textBoxMarca.Text = u.marca;
            textBoxPreco.Text = u.preco.ToString();

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.Show();
        }

    }
}
