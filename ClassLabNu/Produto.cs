using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLabNu
{
    public class Produto
    {
        // atributos da classe
        private int id;
        private string descricao;
        private string unidade;
        private string codBar;
        private double valor;
        private double desconto;
        private bool descontinuado;

        // propriedades
        public int Id { get { return id; } }
        public string Descricao { get { return descricao; } }
        public string Unidade { get { return unidade; } }
        public string CodBar { get { return codBar; } }
        public double Valor { get { return valor; } }
        public double Desconto { get { return desconto; } }
        public bool Descontinuado { get { return descontinuado; } }

        // construtores
        public Produto()
        {
        }

        public Produto(string descricao, string unidade, string codBar, double valor, double desconto)
        {
            this.descricao = descricao;
            this.unidade = unidade;
            this.codBar = codBar;
            this.valor = valor;
            this.desconto = desconto;
        }
        public Produto(string _descricao, string unidade, string codBar, double valor)
        {
            descricao = _descricao;
            this.unidade = unidade;
            this.codBar = codBar;
            this.valor = valor;
            desconto = 0;
            descontinuado = false;
        }
        public Produto(int id, string descricao, string unidade, string codBar, double valor, double desconto, bool descontinuado)
        {
            this.id = id;
            this.descricao = descricao;
            this.unidade = unidade;
            this.codBar = codBar;
            this.valor = valor;
            this.desconto = desconto;
            this.descontinuado = descontinuado;
        }

        // métodos da Classe
        public void Inserir()
        {
            MySqlCommand cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produtos_inserir";
            cmd.Parameters.AddWithValue("_descricao", descricao);
            cmd.Parameters.AddWithValue("_unidade", unidade);
            cmd.Parameters.AddWithValue("_codbar", codBar);
            cmd.Parameters.AddWithValue("_valor", valor);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public Produto BuscarPorId(int _id)
        {
            Produto produto = new Produto();
            // conecta banco realiza consulta por Id do produto
            return produto;
        }
        public Produto BuscarPorCodBar(string _codBar)
        {
            Produto produto = new Produto();
            // conecta banco e realiza consulta por código de barras do produtos
            return produto;
        }
        public List<Produto> BuscarPorDescricao(string _descricao)
        {
            List<Produto> produtos = new List<Produto>();
            // conecta banco e realiza consulta por parte da descriação dos produtos
            return produtos;
        }
        public static List<Produto> ListarTodos(string descriParte = null)
        {
            List<Produto> produtos = new List<Produto>();
            // conecta banco e realiza consulta retornando todos os produtos
            MySqlCommand cmd = Banco.Abrir();
            if (descriParte == null)
            {// lista os produtos ativos em ordem alfabética
                cmd.CommandText = "select * from produtos where descontinuado = 0 order by 2";
            }
            else
            { // lista os produtos ativos por uma parte da descrição e em ordem alfabética 
                cmd.CommandText = "select * from produtos where descontinuado = 0 and descricao like '%" + descriParte + "%' order by 2";
            }
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                produtos.Add(new Produto(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetDouble(4),
                    dr.GetDouble(5),
                    dr.GetBoolean(6)
                    ));
            }
            cmd.Connection.Close();
            return produtos;
        }
        public bool Alterar()
        {
            return true;
        }
        

    }// fim da classe produto
}

