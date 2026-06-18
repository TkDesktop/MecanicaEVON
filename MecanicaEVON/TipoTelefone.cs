using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class TipoTelefone
    {
        public int id { get; set; }
        public string tipoTelefone { get; set; }
        public TipoTelefone()
        {
            id = 0;
            tipoTelefone = string.Empty;
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
                querySql = "select id, tipoTelefone \n";
                querySql += "from tblTipoTelefone \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (tipoTelefone != string.Empty)
                {
                    querySql += "where tipoTelefone like @tipoTelefone \n";
                    parametros.Add(new SqlParameter("@tipoTelefone", '%' + tipoTelefone + '%'));
                }
                querySql += "order by tipoTelefone ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    tipoTelefone = dt.Rows[0]["tipoTelefone"].ToString();
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
                    querySql = "insert into tblTipoTelefone \n";
                    querySql += "(tipoTelefone)\n";
                    querySql += "values \n";
                    querySql += "(@tipoTelefone)\n";
                }
                else
                {
                    querySql = "update tblTipoTelefone set \n";
                    querySql += "tipoTelefone = @tipoTelefone \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@tipoTelefone", tipoTelefone));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
