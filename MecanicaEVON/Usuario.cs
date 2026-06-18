using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string nome { get; set; }
        public string senhaHash { get; set; }
        public bool ativo { get; set; }
        public string perfil {  get; set; }

        public Usuario()
        {
            id = 0;
            login = string.Empty;
            nome = string.Empty;
            senhaHash = string.Empty;
            ativo = false;
            perfil = string.Empty;
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
                querySql = "select id, login, nome, senhaHash, ativo, perfil \n";
                querySql += "from tblUsuario \n";
                if (id != 0)
                {
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (login != string.Empty)
                {
                    querySql += "where login = @login \n";
                    parametros.Add(new SqlParameter("@login", login));
                }
                else if (nome != string.Empty)
                {
                    querySql += "where nome like @nome \n";
                    parametros.Add(new SqlParameter("@nome", '%' + nome + '%'));
                }
                querySql += "order by nome ";

                dt = acesso.Consultar(querySql, parametros);

                if (id != 0 || (login != string.Empty && dt.Rows.Count > 0))
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    login = dt.Rows[0]["login"].ToString();
                    nome = dt.Rows[0]["nome"].ToString();
                    senhaHash = dt.Rows[0]["senhaHash"].ToString();
                    ativo = Convert.ToBoolean(dt.Rows[0]["ativo"]);
                    perfil = dt.Rows[0]["perfil"].ToString();
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
                    querySql = "insert into tblUsuario \n";
                    querySql += "(login, nome, senhaHash, ativo, perfil)\n";
                    querySql += "values \n";
                    querySql += "(@login, @nome, @senhaHash, @ativo, @perfil)\n";
                }
                else
                {
                    querySql = "update tblUsuario set \n";
                    querySql += "login    = @login, \n";
                    querySql += "nome     = @nome, \n";
                    querySql += "senhaHash = @senhaHash, \n";
                    querySql += "ativo    = @ativo, \n";
                    querySql += "perfil   = @perfil \n";
                    querySql += "where id = @id\n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@login", login));
                parametros.Add(new SqlParameter("@nome", nome));
                parametros.Add(new SqlParameter("@senhaHash", senhaHash));
                parametros.Add(new SqlParameter("@ativo", ativo));
                parametros.Add(new SqlParameter("@perfil", perfil));

                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
