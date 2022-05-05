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
    public partial class frmSaida : Form
    {
        public frmSaida()
        {
            InitializeComponent();
            CarregarGrid();

            textBoxNomeProduto.Enabled = false;
            textBoxValorProduto.Enabled = false;
            textBoxQuantidadeRestante.Enabled = false;
        }

        private void CarregarGrid()
        {
            Model model = new Model();
            List<dtoVenda> lista = model.GetVenda();

            this.dataGridViewSaida.DataSource = lista;
            this.dataGridViewSaida.Refresh();
        }

        private void clear()
        {
            textBoxIDProduto.Text = string.Empty;
            textBoxQuantidadeRetirada.Text = string.Empty;

            textBoxNomeProduto.Text = string.Empty;
            textBoxValorProduto.Text = string.Empty;
            textBoxQuantidadeRestante.Text = string.Empty;
        }

        //Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxIDProduto.Text != String.Empty)
            {
                Model model = new Model();
                int id = int.Parse(textBoxIDProduto.Text);
                dtoVenda v = model.GetVendaIdV(id);
                dtoVenda u = new dtoVenda();

                if (v != null)
                    if (textBoxQuantidadeRetirada.Text != String.Empty && textBoxIDProduto.Text != String.Empty)
                    {
                        if (v.quantidade - int.Parse(textBoxQuantidadeRetirada.Text) <= 0)
                        {
                            if (v.quantidade - int.Parse(textBoxQuantidadeRetirada.Text) == 0)
                            {
                                //deleta
                                model.DeletarVenda(id);
                                clear();
                                CarregarGrid();
                                error.Text = String.Empty;
                            }
                            else
                            {
                                error.Text = "Quantidade indisponivel!";
                            }

                        }
                        else
                        {
                            //Edita
                            u = v;
                            u.quantidade = v.quantidade - int.Parse(textBoxQuantidadeRetirada.Text);

                            model.EditVenda(u);
                            searchV();
                            CarregarGrid();
                            error.Text = String.Empty;
                        }
                    }
                    else
                    {
                        error.Text = "Nenhuma venda selecionada!";
                    }
                else
                    error.Text = "Nenhuma venda selecionada!";
            }
            else
            {
                error.Text = "Nenhuma venda selecionada!";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void searchV()
        {
            Model model = new Model();
            if (textBoxIDProduto.Text != String.Empty)
            {
                int id = int.Parse(textBoxIDProduto.Text);
                dtoVenda v = model.GetVendaIdV(id);

                if (v != null)
                {
                    textBoxNomeProduto.Text = v.nome;
                    textBoxValorProduto.Text = v.valorvenda.ToString();
                    textBoxQuantidadeRestante.Text = v.quantidade.ToString();
                }
                else
                {
                    clear();
                }

            }
            else
            {
                clear();
            }

        }

        private void searchProd(object sender, EventArgs e)
        {
            searchV();
        }

        private void selectVenda(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewSaida.CurrentRow.Cells[0].Value;

            Model model = new Model();
            dtoVenda u = model.GetVendaIdV(id);
            textBoxIDProduto.Text = u.id.ToString();
            textBoxNomeProduto.Text = u.nome;
            textBoxQuantidadeRestante.Text = u.quantidade.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.Show();
        }
    }
}
