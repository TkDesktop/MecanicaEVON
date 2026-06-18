using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Categoria
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public Categoria()
        {
            id = 0;
            categoria = string.Empty;
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
                querySql = "select id, categoria \n";
                querySql += "from tblCategoriaProduto \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (categoria != string.Empty)
                {
                    querySql += "where categoria like @categoria \n";
                    parametros.Add(new SqlParameter("@categoria", '%' + categoria + '%'));
                }
                querySql += "order by categoria ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    categoria = dt.Rows[0]["categoria"].ToString();
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
                    querySql = "insert into tblcategoriaProduto \n";
                    querySql += "(categoria)\n";
                    querySql += "values \n";
                    querySql += "(@categoria)\n";
                }
                else
                {
                    querySql = "update tblcategoriaProduto set \n";
                    querySql += "categoria = @categoria \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@categoria", categoria));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
