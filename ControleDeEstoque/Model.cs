using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    public class Model
    {
        internal void setUsuario(dtoUsuario u)
        {
            Context db = new Context();
            db.usuario.Add(u);
            db.SaveChanges();
        }

        internal void setProduto(dtoProduto u)
        {
            Context db = new Context();
            db.produto.Add(u);
            db.SaveChanges();
        }

        internal void setVenda(dtoVenda u)
        {
            Context db = new Context();
            db.venda.Add(u);
            db.SaveChanges();
        }

        internal List<dtoUsuario> GetUsuarios()
        {
            Context db = new Context();
            
            List<dtoUsuario> retorno = db.usuario.ToList();

            return new List<dtoUsuario>(retorno);
        }

        internal List<dtoProduto> GetProdutos()
        {
            Context db = new Context();

            List<dtoProduto> retorno = db.produto.ToList();

            return new List<dtoProduto>(retorno);
        }

        internal List<dtoVenda> GetVenda()
        {
            Context db = new Context();

            List<dtoVenda> retorno = db.venda.ToList();

            return new List<dtoVenda>(retorno);
        }

        internal dtoUsuario GetUsuariosId(int id)
        {
            Context db = new Context();

            var resultado1 = db.usuario.Where(u => u.id == id).FirstOrDefault();

            return resultado1;
        }

        internal dtoProduto GetProdutosId(int id)
        {
            Context db = new Context();

            var resultado = db.produto.Where(u => u.id == id).FirstOrDefault();

            return resultado;
        }

        internal dtoVenda GetVendaId(int id)
        {
            Context db = new Context();

            var resultado = db.venda.Where(u => u.idproduto == id).FirstOrDefault();

            return resultado;
        }

        internal dtoVenda GetVendaIdV(int id)
        {
            Context db = new Context();

            var resultado = db.venda.Where(u => u.id == id).FirstOrDefault();

            return resultado;
        }

        internal void EditUsuario(dtoUsuario u)
        {
            Context db = new Context();
            dtoUsuario e = db.usuario.FirstOrDefault(p => p.id == u.id);
            e.nome = u.nome;
            e.login = u.login;
            e.senha = u.senha;

            db.SaveChanges();
        }

        internal void EditVenda(dtoVenda u)
        {
            Context db = new Context();
            dtoVenda e = db.venda.FirstOrDefault(p => p.id == u.id);
            e.valorvenda = u.valorvenda;
            e.quantidade = u.quantidade;

            db.SaveChanges();
        }

        internal void EditQtdProduto(dtoProduto u)
        {
            Context db = new Context();
            dtoProduto e = db.produto.FirstOrDefault(p => p.id == u.id);
            e.quantidade = u.quantidade;

            db.SaveChanges();
        }

        internal void EditProduto(dtoProduto u)
        {
            Context db = new Context();
            dtoProduto e = db.produto.FirstOrDefault(p => p.id == u.id);
            e.nome = u.nome;
            e.quantidade = u.quantidade;
            e.marca = u.marca;
            e.preco = u.preco;

            db.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            Context db = new Context();
            dtoUsuario u = db.usuario.FirstOrDefault(p => p.id == id);
            db.usuario.Remove(u);
            db.SaveChanges();
        }

        public void DeletarProduto(int id)
        {
            Context db = new Context();
            dtoProduto u = db.produto.FirstOrDefault(p => p.id == id);
            db.produto.Remove(u);
            db.SaveChanges();
        }

        public void DeletarVenda(int id)
        {
            Context db = new Context();
            dtoVenda u = db.venda.FirstOrDefault(p => p.id == id);
            db.venda.Remove(u);
            db.SaveChanges();
        }
    }
}
