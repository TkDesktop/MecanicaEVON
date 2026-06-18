using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Status
    {
        public int id { get; set; }
        public string status { get; set; }


        public Status()
        {
            id = 0;
            status = string.Empty;
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
                querySql = "select id, status \n";
                querySql += "from tblStatusOS \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (status != string.Empty)
                {
                    querySql += "where status like @status \n";
                    parametros.Add(new SqlParameter("@status", '%' + status + '%'));
                }
                querySql += "order by status ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    status = dt.Rows[0]["Status"].ToString();
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
                    querySql = "insert into tblStatusOS \n";
                    querySql += "(status)\n";
                    querySql += "values \n";
                    querySql += "(@status)\n";
                }
                else
                {
                    querySql = "update tblStatusOS set \n";
                    querySql += "status = @status \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@status", status));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
