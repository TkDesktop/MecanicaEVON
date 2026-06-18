using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public static class Global
    {
        public static string conexao;
        public static int id;
        public static string nome;
        public static string login;
        public static string banco;
        public static string servidor;
        public static string perfil;

        public static void MontarStringConexao()
        {
            banco = ConfigurationManager.AppSettings["banco"];
            servidor = ConfigurationManager.AppSettings["servidor"];

            conexao = $"Data Source={servidor};Initial Catalog={banco};Integrated Security=true;";
        }
        public static string EncriptPassword(string senha)
        {
            Byte[] original;
            Byte[] criptografado;
            MD5 md5 = new MD5CryptoServiceProvider();
            original = ASCIIEncoding.Default.GetBytes(senha);
            criptografado = md5.ComputeHash(original);

            return Regex.Replace(BitConverter.ToString(criptografado), "-", "").ToLower();
        }

        public static DataTable ConsultarMarca()
        {
            try
            {
                DataTable dt = new DataTable();
                string querySql = "select id, marca from tblMarca";
                dt = (new AcessoBD()).Consultar(querySql, new List<SqlParameter>());
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ConsultaModelos(int idMarca)
        {
            try
            {
                List<SqlParameter> lista = new List<SqlParameter>();
                DataTable dt = new DataTable();
                string querySql = "select id, modelo from tblModelo where idMarca = @idMarca";
                lista.Add(new SqlParameter("@idMarca", idMarca));
                dt = (new AcessoBD()).Consultar(querySql, lista);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
