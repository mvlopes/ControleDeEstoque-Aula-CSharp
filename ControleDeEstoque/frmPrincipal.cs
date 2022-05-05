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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            Model model = new Model();
            List<dtoVenda> lista = model.GetVenda();
            this.dataGridViewPrincipal.DataSource = lista;
            this.dataGridViewPrincipal.Refresh();
            this.dataGridViewPrincipal.Columns["idproduto"].Visible = false;
            this.dataGridViewPrincipal.Columns["id"].Visible = false;
            this.dataGridViewPrincipal.Columns["valorcusto"].Visible = false;
        }

        
        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            frmUsuario f = new frmUsuario();
            this.Hide();
            f.Show();
        }

        private void btnProduto_Click_1(object sender, EventArgs e)
        {
            frmProduto f = new frmProduto();
            this.Hide();
            f.Show();
        }

        private void btnEntrada_Click_1(object sender, EventArgs e)
        {
            frmEntrada f = new frmEntrada();
            this.Hide();
            f.Show();
        }

        private void btnSaida_Click_1(object sender, EventArgs e)
        {
            frmSaida f = new frmSaida();
            this.Hide();
            f.Show();
        }
    }
}
