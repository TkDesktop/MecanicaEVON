using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Fornecedor
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string email { get; set; }
        public int idCidade { get; set; }


        public Fornecedor()
        {
            id = 0;
            nome = string.Empty;
            cnpj = string.Empty;
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
                querySql = "select id, nome, cnpj, email, idCidade \n";
                querySql += "from tblFornecedor \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (nome != string.Empty)
                {
                    querySql += "where nome like @nome \n";
                    parametros.Add(new SqlParameter("@nome", '%' + nome + '%'));
                }
                else if (cnpj != string.Empty)
                {
                    querySql += "where cnpj = @cnpj \n";
                    parametros.Add(new SqlParameter("@cnpj", cnpj));
                }
                querySql += "order by nome ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    cnpj = dt.Rows[0]["cnpj"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    
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
                    querySql = "insert into tblFornecedor \n";
                    querySql += "(nome, cnpj, email)\n";
                    querySql += "values \n";
                    querySql += "(@nome, @cnpj, @email) \n";
                }
                else
                {
                    querySql = "update tblFornecedor set \n";
                    querySql += "nome = @nome, \n";
                    querySql += "cnpj = @cnpj, \n";
                    querySql += "email = @email \n";

                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter ("@nome", nome));
                parametros.Add(new SqlParameter ("@cnpj", cnpj));
                parametros.Add(new SqlParameter ("@email", email));


                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

