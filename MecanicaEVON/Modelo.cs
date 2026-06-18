using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Modelo
    {
        public int id {  get; set; }
        public string modelo { get; set; }
        public int idMarca { get; set; }

        public Modelo()
        {
            id = 0;
            modelo = string.Empty;
            idMarca = 0;
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
                querySql = "select id, modelo, idMarca \n";
                querySql += "from tblModelo \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (modelo != string.Empty)
                {
                    querySql += "where modelo like @modelo \n";
                    parametros.Add(new SqlParameter("@modelo", '%' + modelo + '%'));
                }
                else if (idMarca != 0)
                {
                    querySql += "where idMarca = @idMarca \n";
                    parametros.Add(new SqlParameter("@idMarca", idMarca));
                }
                querySql += "order by modelo ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    modelo = dt.Rows[0]["modelo"].ToString();
                    idMarca = Convert.ToInt32(dt.Rows[0]["idMarca"]);
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
                    querySql = "insert into tblModelo \n";
                    querySql += "(modelo, idMarca)\n";
                    querySql += "values \n";
                    querySql += "(@modelo, @idMarca)\n";
                }
                else
                {
                    querySql = "update tblModelo set \n";
                    querySql += "modelo = @modelo, \n";
                    querySql += "idMarca = @idMarca \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@modelo", modelo));
                parametros.Add(new SqlParameter("@idMarca", idMarca));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
