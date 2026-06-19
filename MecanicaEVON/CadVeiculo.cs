using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class CadVeiculo
    {
        public int id {  get; set; }
        public string placa { get; set; }
        public string ano { get; set; }
        public string cpf { get; set; }
        public int idModelo { get; set; }
        public int idCombustivel { get; set; }
        public int idCliente { get; set; }
        public int idMarca { get; set; }

        public CadVeiculo()
        {
            id = 0;
            placa = string.Empty;
            ano = string.Empty;
            idModelo = 0;
            idCombustivel = 0;
            idCliente = 0;
            idMarca = 0;
        }
        DataTable dt = new DataTable();
        List<SqlParameter> parametros = new List<SqlParameter>();
        AcessoBD acesso = new AcessoBD();
        string querySql = string.Empty;

        public DataTable Consultar(string nome = "")
        {
            try
            {
                parametros.Clear();
                querySql = " select v.id, v.placa, v.ano,ma.id idMarca, m.modelo, ma.marca, c.combustivel, cli.nomeCompleto, cli.id idCliente, m.id idModelo, c.id idCombustivel,cli.cpf  \n";
                querySql += "from tblVeiculo v \n";
                querySql += "INNER JOIN tblModelo m ON v.idModelo = m.id \n";
                querySql += "INNER JOIN tblMarca ma ON m.idMarca = ma.id \n";
                querySql += "INNER JOIN tblCombustivel c ON v.idCombustivel = c.id \n";
                querySql += "INNER JOIN tblCliente cli ON v.idCliente = cli.id \n";

                if (id != 0 )
                {
                    querySql += "where v.id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                else if (placa != string.Empty)
                {
                    querySql += "where placa like @placa \n";
                    querySql += "order by placa \n";
                    parametros.Add(new SqlParameter("@placa", '%' + placa + '%'));
                }
                else if (cpf != string.Empty)
                {
                    querySql += "where cli.cpf like @cpf \n";
                    querySql += "order by cli.nomeCompleto";
                    parametros.Add(new SqlParameter("@cpf", '%' + cpf + '%'));

                }
                else if (nome != string.Empty)
                {
                    querySql += "where cli.nomeCompleto = @nomeCompleto \n";
                    querySql += "order by nomeCompleto \n";
                    parametros.Add(new SqlParameter("@nomeCompleto", nome));
                }
                dt = acesso.Consultar(querySql, parametros);
                if (id != 0 && dt.Rows.Count > 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    placa = dt.Rows[0]["placa"].ToString();
                    ano = dt.Rows[0]["ano"].ToString();
                    idModelo = Convert.ToInt32(dt.Rows[0]["idModelo"]);
                    idCombustivel = Convert.ToInt32(dt.Rows[0]["idCombustivel"]);
                    idCliente = Convert.ToInt32(dt.Rows[0]["idCliente"]);
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
                    querySql = "insert into tblVeiculo \n";
                    querySql += "(placa, ano, idModelo, idCombustivel, idCliente)\n";
                    querySql += "values \n";
                    querySql += "(@placa, @ano, @idModelo, @idCombustivel, @idCliente)\n";
                }
                else
                {
                    querySql = "update tblVeiculo set \n";
                    querySql += "placa = @placa, \n";
                    querySql += "ano = @ano, \n";
                    querySql += "idModelo = @idModelo, \n";
                    querySql += "idCombustivel = @idCombustivel, \n";
                    querySql += "idCliente = @idCliente \n";
                    querySql += "where id = @id \n";
                    parametros.Add(new SqlParameter("@id", id));
                }
                parametros.Add(new SqlParameter("@placa", placa));
                parametros.Add(new SqlParameter("@ano", ano));
                parametros.Add(new SqlParameter("@idModelo", idModelo));
                parametros.Add(new SqlParameter("@idCombustivel", idCombustivel));
                parametros.Add(new SqlParameter("@idCliente", idCliente));
                acesso.Executar(querySql, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
