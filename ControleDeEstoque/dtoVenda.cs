﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque
{
    [Table("venda", Schema = "public")]
    class dtoVenda
    {
        [Key]
        public int id { get; set; }
        public int idproduto { get; set; }
        public string nome { get; set; }
        public decimal valorcusto { get; set; }
        public decimal valorvenda { get; set; }
        public int quantidade { get; set; }
    }
}
