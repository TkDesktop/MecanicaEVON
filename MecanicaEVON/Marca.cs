using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Marca
    {
        public int id { get; set; }
        public string marca { get; set; }


        public Marca()
        {
            id = 0;
            marca = string.Empty;
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
                querySql = "select id, marca \n";
                querySql += "from tblMarca \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (marca != string.Empty)
                {
                    querySql += "where marca like @marca \n";
                    parametros.Add(new SqlParameter("@marca", '%' + marca + '%'));
                }
                querySql += "order by marca ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    marca = dt.Rows[0]["marca"].ToString();
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
                    querySql = "insert into tblMarca \n";
                    querySql += "(marca)\n";
                    querySql += "values \n";
                    querySql += "(@marca)\n";
                }
                else
                {
                    querySql = "update tblMarca set \n";
                    querySql += "marca = @marca \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@marca", marca));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
