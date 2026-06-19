using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public decimal precoCusto { get; set; }
        public int quantidade { get; set; }
        public int idCategoria { get; set; }
        public int idFornecedor { get; set; }

        public Produto()
        {
            id = 0;
            nome = string.Empty;
            descricao = string.Empty;
            preco = 0;
            precoCusto = 0;
            quantidade = 0;
            idCategoria = 0;
            idFornecedor = 0;
        }
        DataTable dt = new DataTable();
        List<SqlParameter> parametros = new List<SqlParameter>();
        AcessoBD acesso = new AcessoBD();
        string querySql = string.Empty;


        public DataTable Consultar()
        {
            try
            {
                parametros.Clear();
                querySql = "select id, nome, descricao, preco, precoCusto, quantidade, idCategoria, idFornecedor \n";
                querySql += "from tblProduto \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (nome != string.Empty)
                {
                    querySql += "where nome like @nome \n";
                    parametros.Add(new SqlParameter("@nome", '%' + nome + '%'));
                }
                else if (idFornecedor != 0)
                {
                    querySql += "where idFornecedor = @idFornecedor \n";
                    parametros.Add(new SqlParameter("@idFornecedor", idFornecedor));
                }
                querySql += "order by nome ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    descricao = dt.Rows[0]["descricao"].ToString();
                    preco = Convert.ToInt32(dt.Rows[0]["preco"]);
                    precoCusto = Convert.ToInt32(dt.Rows[0]["precoCusto"]);
                    quantidade = Convert.ToInt32(dt.Rows[0]["quantidade"]);
                    idCategoria = Convert.ToInt32(dt.Rows[0]["idCategoria"]);
                    idFornecedor = Convert.ToInt32(dt.Rows[0]["idFornecedor"]);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Gravar()
        {
            try
            {
                parametros.Clear();
                if (id == 0)
                {
                    querySql = "insert into tblProduto \n";
                    querySql += "(nome, descricao, preco, precoCusto, quantidade, idCategoria, idFornecedor)\n";
                    querySql += "values \n";
                    querySql += "(@nome, @descricao, @preco, @precoCusto, @quantidade, @idCategoria, @idFornecedor)\n";
                }
                else
                {
                    querySql = "update tblModelo set \n";
                    querySql += "nome = @nome, \n";
                    querySql += "descricao = @descricao, \n";
                    querySql += "preco = @preco, \n";
                    querySql += "precoCusto = @precoCusto, \n";
                    querySql += "quantidade = @quantidade, \n";
                    querySql += "idCategoria = @idCategoria, \n";
                    querySql += "idFornecedor = @idFornecedor \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@nome", nome));
                parametros.Add(new SqlParameter("@descricao", descricao));
                parametros.Add(new SqlParameter("@preco", preco));
                parametros.Add(new SqlParameter("@precoCusto", precoCusto));
                parametros.Add(new SqlParameter("@quantidade", quantidade));
                parametros.Add(new SqlParameter("@idCategoria", idCategoria));
                parametros.Add(new SqlParameter("@idFornecedor", idFornecedor));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }




}

