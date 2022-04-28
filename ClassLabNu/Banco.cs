using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLabNu
{
    public static class Banco
    {
        // propriedade de conexão - string
        public static string StrConexao { get; set; }

        // método 'Abrir' conexão
        public static MySqlCommand Abrir()
        {
            MySqlCommand cmd = new MySqlCommand();
            StrConexao = @"sever=127.0.0.1;database=comercialdb0191;user id=root;password=;port=3306";
            MySqlConnection cn = new MySqlConnection(StrConexao);
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                throw;
            }

            cmd.Connection = cn;
            return cmd;
        }
    }
}
