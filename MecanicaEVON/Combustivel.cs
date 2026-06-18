using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Combustivel
    {
        public int id { get; set; }
        public string combustivel { get; set; }
        public Combustivel()
        {
            id = 0;
            combustivel = string.Empty;
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
                querySql = "select id, combustivel \n";
                querySql += "from tblCombustivel \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (combustivel != string.Empty)
                {
                    querySql += "where combustivel like @combustivel \n";
                    parametros.Add(new SqlParameter("@combustivel", '%' + combustivel + '%'));
                }
                querySql += "order by combustivel ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    combustivel = dt.Rows[0]["combustivel"].ToString();
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
                    querySql = "insert into tblCombustivel \n";
                    querySql += "(combustivel)\n";
                    querySql += "values \n";
                    querySql += "(@combustivel)\n";
                }
                else
                {
                    querySql = "update tblCombustivel set \n";
                    querySql += "combustivel = @combustivel \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@combustivel", combustivel));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
