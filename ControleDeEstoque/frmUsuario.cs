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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            CarregarGrid();

            textBoxID.Enabled = false;
            textBoxNome.Enabled = false;
            textBoxLogin.Enabled = false;
            textBoxSenha.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            
        }

        private void CarregarGrid()
        {
            Model model = new Model();
            List<dtoUsuario> lista = model.GetUsuarios();
            this.dataGridViewUsuario.DataSource = lista;
            this.dataGridViewUsuario.Refresh();
        }

        private void Clean()
        {
            textBoxNome.Enabled = false;
            textBoxLogin.Enabled = false;
            textBoxSenha.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;

            textBoxID.Text = string.Empty;
            textBoxNome.Text = string.Empty;
            textBoxLogin.Text = string.Empty;
            textBoxSenha.Text = string.Empty;            
        }

        //Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            textBoxNome.Enabled = true;
            textBoxLogin.Enabled = true;
            textBoxSenha.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalvar.Enabled = true;
        }

        //Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            dtoUsuario u = new dtoUsuario();
            u.nome = textBoxNome.Text;
            u.login = textBoxLogin.Text;
            u.senha = textBoxSenha.Text;

            if (textBoxID.Text == string.Empty)
            {
                model.setUsuario(u);
            }
            else
            {
                u.id = int.Parse(textBoxID.Text);
                model.EditUsuario(u);
            }


            CarregarGrid();
            Clean();
        }

        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        //Deletar
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text != string.Empty)
            {
                Model model = new Model();
                model.DeletarUsuario(int.Parse(textBoxID.Text));
                Clean();
                CarregarGrid();
            }
        }

        private void dataGridViewUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewUsuario.CurrentRow.Cells[0].Value;

            Model model = new Model();
            dtoUsuario u = model.GetUsuariosId(id);
            textBoxID.Text = u.id.ToString();
            textBoxNome.Text = u.nome;
            textBoxLogin.Text = u.login;

            textBoxNome.Enabled = true;
            textBoxLogin.Enabled = true;
            textBoxSenha.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNovo.Enabled = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.Show();
        }
    }
    }
