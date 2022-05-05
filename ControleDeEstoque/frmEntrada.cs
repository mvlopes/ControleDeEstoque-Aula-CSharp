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
    public partial class frmEntrada : Form
    {
        public frmEntrada()
        {
            InitializeComponent();
            CarregarGrid();

            textBoxNomeProduto.Enabled = false;
            textBoxValorCusto.Enabled = false;
            textBoxQuantidadeEstoque.Enabled = false;
        }

        private void CarregarGrid()
        {
            Model model = new Model();
            List<dtoProduto> lista = model.GetProdutos();
            this.dataGridViewEntrada.DataSource = lista;
            this.dataGridViewEntrada.Refresh();
        }

        private void clear()
        {
            textBoxNomeProduto.Text = string.Empty;
            textBoxValorCusto.Text = string.Empty;
            textBoxQuantidadeEstoque.Text = string.Empty;
        }

        private void clearAll()
        {
            textBoxIDProduto.Text = string.Empty;
            textBoxNomeProduto.Text = string.Empty;
            textBoxValorCusto.Text = string.Empty;
            textBoxQuantidadeEstoque.Text = string.Empty;
            textBoxValorVenda.Text = string.Empty;
            textBoxQuantidadeEntrada.Text = string.Empty;
        }

        private void clearInput()
        {
            textBoxQuantidadeEntrada.Text = string.Empty;
            textBoxValorVenda.Text = string.Empty;
        }

        //Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxIDProduto.Text != string.Empty)
            {
                Model model = new Model();
                dtoVenda u = new dtoVenda();

                int id = int.Parse(textBoxIDProduto.Text);
                dtoVenda a = model.GetVendaId(id);
                dtoProduto p = model.GetProdutosId(id);

                if (a != null)
                {
                    u = a;
                }

                if (textBoxValorVenda.Text != string.Empty && textBoxQuantidadeEntrada.Text != string.Empty)
                {
                    u.valorvenda = decimal.Parse(textBoxValorVenda.Text);
                    p.quantidade = p.quantidade - int.Parse(textBoxQuantidadeEntrada.Text);


                    if (a != null)
                    {
                        if (p.quantidade > int.Parse(textBoxQuantidadeEntrada.Text))
                        {
                            u.quantidade = a.quantidade + int.Parse(textBoxQuantidadeEntrada.Text);
                            model.EditVenda(u);
                            model.EditQtdProduto(p);
                            clearInput();
                            searchP();
                            CarregarGrid();
                        }
                        else
                        {
                            erro.Text = "Quantidade de entrada maior que o limite!";
                        }
                    }
                    else
                    {
                        if (p != null)
                        {
                            if (p.quantidade > int.Parse(textBoxQuantidadeEntrada.Text))
                            {
                                u.nome = p.nome;
                                u.quantidade = int.Parse(textBoxQuantidadeEntrada.Text);
                                u.idproduto = int.Parse(textBoxIDProduto.Text);
                                model.setVenda(u);
                                model.EditQtdProduto(p);
                                clearInput();
                                searchP();
                                CarregarGrid();
                            }
                            else
                            {
                                erro.Text = "Quantidade de entrada maior que o limite!";
                            }

                        }
                        else
                        {
                            erro.Text = "Nenhum produto selecionado!";
                        }

                    }
                }
                else
                {
                    erro.Text = "Preencha os campos vazios!";
                }
            }
            else
            {
                erro.Text = "Nenhum produto selecionado!";
            }

        }

        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void searchP()
        {
            Model model = new Model();
            if (textBoxIDProduto.Text != String.Empty)
            {
                int id = int.Parse(textBoxIDProduto.Text);
                dtoProduto u = model.GetProdutosId(id);
                dtoVenda v = model.GetVendaId(id);
                if (u != null)
                {
                    textBoxNomeProduto.Text = u.nome;
                    textBoxValorCusto.Text = u.preco.ToString();
                    textBoxQuantidadeEstoque.Text = u.quantidade.ToString();

                    if (v != null)
                    {
                        textBoxValorVenda.Text = v.valorvenda.ToString();
                    }
                    else
                    {
                        textBoxValorVenda.Text = string.Empty;
                    }
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

        //Procurar
        private void searchProduct(object sender, EventArgs e)
        {
            searchP();
        }

        private void selectProduct(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewEntrada.CurrentRow.Cells[0].Value;

            Model model = new Model();
            dtoProduto u = model.GetProdutosId(id);
            textBoxIDProduto.Text = u.id.ToString();
            textBoxNomeProduto.Text = u.nome;
            textBoxValorCusto.Text = u.preco.ToString();
            textBoxQuantidadeEstoque.Text = u.quantidade.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.Show();
        }
    }
}
