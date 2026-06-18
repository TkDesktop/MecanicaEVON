using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MecanicaEVON
{
    public class Especialidade
    {
        public int id {  get; set; }
        public string especialidade { get; set; }


        public Especialidade()
        {
            id = 0;
            especialidade = string.Empty;
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
                querySql = "select id, especialidade \n";
                querySql += "from tblEspecialidade \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (especialidade != string.Empty)
                {
                    querySql += "where especialidade like @especialidade \n";
                    parametros.Add(new SqlParameter("@especialidade", '%' + especialidade + '%'));
                }
                querySql += "order by especialidade ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    especialidade = dt.Rows[0]["especialidade"].ToString();
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
                    querySql = "insert into tblEspecialidade \n";
                    querySql += "(especialidade)\n";
                    querySql += "values \n";
                    querySql += "(@especialidade)\n";
                }
                else
                {
                    querySql = "update tblEspecialidade set \n";
                    querySql += "especialidade = @especialidade \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@especialidade", especialidade));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
