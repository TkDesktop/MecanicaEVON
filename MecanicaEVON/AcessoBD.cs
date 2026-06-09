using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecanicaEVON
{
    public class AcessoBD
    {
        SqlConnection conn;

        private void Conectar()
        {
            try
            {
                conn = new SqlConnection(Global.conexao);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Desconectar()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Consultar(string sql, List<SqlParameter> lista)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in lista)
                {
                    cmd.Parameters.Add(p);
                }
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void Executar(string sql, List<SqlParameter> lista)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in lista)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Executar(List<SqlParameter> lista, string sql)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in lista)
                {
                    cmd.Parameters.Add(p);
                }
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
