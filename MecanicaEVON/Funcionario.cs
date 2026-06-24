using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Funcionario
    {
        public int id {  get; set; }
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public DateTime dataAdmissao { get; set; }
        public int idCargo { get; set; }
        public int idEspecialidade { get; set; }

        public Funcionario()
        {
            id = 0;
            nomeCompleto = string.Empty;
            cpf = string.Empty;
            dataAdmissao = DateTime.MinValue;
            idCargo = 0;
            idEspecialidade = 0;
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
                querySql = "select id, nomeCompleto, cpf, dataAdmissao, idCargo, idEspecialidade \n";
                querySql += "from tblFuncionario \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (nomeCompleto != string.Empty)
                {
                    querySql += "where nomeCompleto like @nomeCompleto \n";
                    parametros.Add(new SqlParameter("@nome", '%' + nomeCompleto + '%'));
                }
                else if (idCargo  != 0)
                {
                    querySql += "where idCargo = @idCargo";
                    parametros.Add(new SqlParameter("@idCargo", idCargo));                 
                }
                else if (idEspecialidade != 0)
                {
                    querySql += "where idEspecialidade = @idEspecialidade";
                    parametros.Add(new SqlParameter("@idEspecialidade", idEspecialidade));
                }
                    querySql += "order by nomeCompleto ";
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nomeCompleto = dt.Rows[0]["nomeCompleto"].ToString();
                    cpf = dt.Rows[0]["cpf"].ToString();
                    dataAdmissao = Convert.ToDateTime(dt.Rows[0]["dataAdmissao"]);
                    idCargo = Convert.ToInt32(dt.Rows[0]["idCargo"]);
                    idEspecialidade = Convert.ToInt32(dt.Rows[0]["idEspecialidade"]);
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
                    querySql = "insert into tblFuncionario \n";
                    querySql += "(nomeCompleto,cpf,dataAdmissao,idCargo, idEspecialidade)\n";
                    querySql += "values \n";
                    querySql += "(@nomeCompleto,@cpf,@dataAdmissao,@idCargo, @idEspecialidade)\n";
                }
                else
                {
                    querySql = "update tblFuncionario set \n";
                    querySql += "nomeCompleto = @nomeCompleto, \n";
                    querySql += "cpf = @cpf, \n";
                    querySql += "dataAdmissao = @dataAdmissao, \n";
                    querySql += "idCargo = @idCargo, \n";
                    querySql += "idEspecialidade = @idEspecialidade, \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@nomeCompleto", nomeCompleto));
                parametros.Add(new SqlParameter("@cpf", cpf));
                parametros.Add(new SqlParameter("@dataAdmissao", dataAdmissao));
                parametros.Add(new SqlParameter("@idCargo", idCargo));
                parametros.Add(new SqlParameter("@idEspecialidade", idEspecialidade));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
