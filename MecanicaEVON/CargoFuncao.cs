using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class CargoFuncao
    {
        public int id { get; set; }
        public string cargo { get; set; }
        public CargoFuncao()
        {
            id = 0;
            cargo = string.Empty;
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
                querySql = "select id, cargo \n";
                querySql += "from tblCargoFuncao \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (cargo != string.Empty)
                {
                    querySql += "where cargo like @cargo \n";
                    parametros.Add(new SqlParameter("@cargo", '%' + cargo + '%'));
                }
                querySql += "order by cargo ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    cargo = dt.Rows[0]["cargo"].ToString();
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
                    querySql = "insert into tblCargoFuncao \n";
                    querySql += "(cargo)\n";
                    querySql += "values \n";
                    querySql += "(@cargo)\n";
                }
                else
                {
                    querySql = "update tblCargoFuncao set \n";
                    querySql += "cargo = @cargo \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@cargo", cargo));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
