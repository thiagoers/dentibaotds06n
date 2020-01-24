using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Integrando_BD
{
    class Conexao
    {
        private String dadosCon = @"SERVER=LAB604-16;DATABASE=dentibao; INTEGRATED SECURITY = TRUE;";
        private SqlConnection sqlCon;

        public void conectar()
        {
            sqlCon = new SqlConnection(dadosCon);

            try
            {
                sqlCon.Open();
                Console.WriteLine("Conectado!");
            }
            catch (SqlException sqlE)
            {
                Console.WriteLine("Erro: " + sqlE);
            }
        }

        public void desconectar()
        {
            sqlCon.Close();
        }

        public int executar(String sql)
        {
            SqlCommand sqlc = new SqlCommand(sql, sqlCon);
            return sqlc.ExecuteNonQuery();
        }

        public SqlDataReader exeConsulta(String sql)
        {
            SqlCommand sqlc = new SqlCommand(sql, sqlCon);
            return sqlc.ExecuteReader();
        }
    }
}
