using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Telefone
    {
        public int id {  get; set; }
        public string numero { get; set; }
        public int idTipoTelefone { get; set; }
        public int idCliente { get; set; }
        public int idFornecedor { get; set; }

        public Telefone()
        {
            id = 0;
            numero = string.Empty;
            idTipoTelefone = 0;
            idCliente = 0;
            idFornecedor = 0;
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
                querySql = "select id, numero, idTipoTelefone, idCliente, idFornecedor \n";
                querySql += "from tblTelefone \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (numero != string.Empty)
                {
                    querySql += "where numero like @numero \n";
                    parametros.Add(new SqlParameter("@numero", '%' + numero + '%'));
                }
                else if (idCliente != 0)
                {
                    querySql += "where idCliente = @idCliente \n";
                    parametros.Add(new SqlParameter("@idCliente", idCliente));
                }
                else if (idFornecedor != 0)
                {
                    querySql += "where idFornecedor = @idFornecedor \n";
                    parametros.Add(new SqlParameter("@idFornecedor", idFornecedor));
                }
                querySql += "order by numero ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0 || idCliente != 0 || idFornecedor != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    numero = dt.Rows[0]["numero"].ToString();
                    idTipoTelefone = Convert.ToInt32(dt.Rows[0]["idTipoTelefone"]);
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
                    querySql = "insert into tblTelefone \n";
                    querySql += "(numero, idTipoTelefone, idCliente, idFornecedor)\n";
                    querySql += "values \n";
                    querySql += "(@numero, @idTipoTelefone, @idCliente, @idFornecedor)\n";
                }
                else
                {
                    querySql = "update tblTelefone set \n";
                    querySql += "numero = @numero, \n";
                    querySql += "idTipoTelefone = @idTipoTelefone, \n";
                    querySql += "idCliente = @idCliente, \n";
                    querySql += "idFornecedor = @idFornecedor \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@numero", numero));
                parametros.Add(new SqlParameter("@idTipoTelefone", idTipoTelefone));
                parametros.Add(new SqlParameter("@idCliente", idCliente));
                parametros.Add(new SqlParameter("@idFornecedor", idFornecedor));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

