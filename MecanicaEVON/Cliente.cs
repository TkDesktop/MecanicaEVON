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
    public class Cliente
    {
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string email { get; set; }

        public Cliente()
        {
            id = 0;
            nomeCompleto = string.Empty;
            cpf = string.Empty;
            dataNascimento = DateTime.Now;
            email = string.Empty;
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
                querySql = "select id, nomeCompleto, cpf, dataNascimento, email \n";
                querySql += "from tblCliente \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (nomeCompleto != string.Empty)
                {
                    querySql += "where nomeCompleto like @nomeCompleto \n";
                    parametros.Add(new SqlParameter("@nomeCompleto", '%' + nomeCompleto + '%'));
                }
                else if (cpf != string.Empty)
                {
                    querySql += "where cpf like @cpf \n";
                    parametros.Add(new SqlParameter("@cpf", '%' + cpf + '%'));
                }
                    querySql += "order by id ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0 || (cpf != string.Empty && dt.Rows.Count > 0))
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nomeCompleto = dt.Rows[0]["nomeCompleto"].ToString();
                    cpf = dt.Rows[0]["cpf"].ToString();
                    dataNascimento = Convert.ToDateTime(dt.Rows[0]["dataNascimento"]);
                    email = dt.Rows[0]["email"].ToString();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
