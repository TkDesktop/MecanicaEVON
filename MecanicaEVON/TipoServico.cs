using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class TipoServico
    {
        public int id { get; set; }
        public string tipoServico { get; set; }


        public TipoServico()
        {
            id = 0;
            tipoServico = string.Empty;
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
                querySql = "select id, tipoServico \n";
                querySql += "from tblTipoServico \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (tipoServico != string.Empty)
                {
                    querySql += "where tipoServico like @tipoServico \n";
                    parametros.Add(new SqlParameter("@tipoServico", '%' + tipoServico + '%'));
                }
                querySql += "order by tipoServico ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    tipoServico = dt.Rows[0]["tipoServico"].ToString();
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
                    querySql = "insert into tblTipoServico \n";
                    querySql += "(tipoServico)\n";
                    querySql += "values \n";
                    querySql += "(@tipoServico)\n";
                }
                else
                {
                    querySql = "update tblTipoServico set \n";
                    querySql += "tipoServico = @tipoServico \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@tipoServico", tipoServico));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
