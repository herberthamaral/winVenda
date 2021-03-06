﻿/*Neste código ainda não é feito o tratamento de erros, e a classe de banco de dados 
 * será uma classe estática, conceito que será visto nas próximas aulas.
 * 

/*Importante ler também a respeito dos tipos predefinidos (pág 68-93)
 */

/*Para começar é preciso incluir os seguintes namespaces: */

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;


//A definição de namespaces pode ser encontrada no livro C#- Guia 
//de Consulta Rápida na pág. 91-93.
namespace winVenda
{
    //Definição de classe e objeto pág 32,33 e 34
    //Definição de modificadores de acesso
    public class Cliente
    {
        private int codigo;
        //Tipo string definido na pág 11
        private string nome;
        private string endereco;
        private string telefone;

        //Definição de propriedades na pág. 47
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }

        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }

        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }

        }

      

        public void Salvar()
        {

            string sql = "INSERT INTO clientes VALUES(null, " + "@nome" + "," +
                        "@endereco" + ", " + "@telefone" + ");";
            MySqlCommand commS = new MySqlCommand (sql, Conn.mConn);
            // adiciona-se o parametro, indicando o nome e o tipo
            commS.Parameters.Add("@nome", MySqlDbType.VarChar);
            // atribui-se o respectivo valor
            commS.Parameters["@nome"].Value = nome;

            commS.Parameters.Add("@endereco", MySqlDbType.VarChar);
            commS.Parameters["@endereco"].Value = endereco;

            commS.Parameters.Add("@telefone", MySqlDbType.VarChar);
            commS.Parameters["@telefone"].Value = telefone;

            Conn.ExecuteNonQuery(commS);

        }

        public ArrayList listar()
        {
            ArrayList arr = new ArrayList();
            string sql = "SELECT * FROM Clientes;";
            MySqlCommand commS = new MySqlCommand
                (sql, Conn.mConn);
            MySqlDataReader mReader = Conn.ExecuteQuery(commS);
            while (mReader.Read() != false)
            {
                Cliente c = new Cliente();
                c.Codigo = int.Parse(mReader.GetValue(0).ToString());
                c.Nome = mReader.GetValue(1).ToString();
                c.Endereco = mReader.GetValue(2).ToString();
                c.Telefone = mReader.GetValue(3).ToString();
                arr.Add(c);
            }
            Conn.mConn.Close();
            return arr;

        }
        public ArrayList listar(string _n)
        {
            ArrayList arr = new ArrayList();
            string sql = "SELECT * FROM Clientes where nome like " +
                "@nome";
            MySqlCommand commS = new MySqlCommand
                (sql, Conn.mConn);
            // adiciona-se o parametro, indicando o nome e o tipo
            commS.Parameters.Add("@nome", MySqlDbType.VarChar);

            // atribui-se o respectivo valor
            commS.Parameters["@nome"].Value = _n;
            MySqlDataReader mReader = Conn.ExecuteQuery(commS);
            while (mReader.Read() != false)
            {
                Cliente c = new Cliente();
                c.Codigo = int.Parse(mReader.GetValue(0).ToString());
                c.Nome = mReader.GetValue(1).ToString();
                c.Endereco = mReader.GetValue(2).ToString();
                c.Telefone = mReader.GetValue(3).ToString();
                arr.Add(c);
            }
            Conn.mConn.Close();
            return arr;
        }

        public void Editar(int codigo)
        {

            string sql = "Update clientes  set nome = " + "@nome" + ", endereco = " +
                "@endereco" + ", telefone = " + "@telefone" + " where codigo = " +
                "@codigo";
            MySqlCommand commS = new MySqlCommand(sql, Conn.mConn);

            commS.Parameters.Add("@nome", MySqlDbType.VarChar);
            // atribui-se o respectivo valor
            commS.Parameters["@nome"].Value = nome;

            commS.Parameters.Add("@endereco", MySqlDbType.VarChar);
            commS.Parameters["@endereco"].Value = endereco;

            commS.Parameters.Add("@telefone", MySqlDbType.VarChar);
            commS.Parameters["@telefone"].Value = telefone;

            commS.Parameters.Add("@codigo", MySqlDbType.Int32);
            commS.Parameters["@codigo"].Value = codigo;
            Conn.ExecuteNonQuery(commS);

        }
        public void Deletar(int cod)
        {
            string sql = " Delete from Clientes where codigo = " + "@codigo";
            MySqlCommand commS = new MySqlCommand(sql, Conn.mConn);

            commS.Parameters.Add("@codigo", MySqlDbType.Int32);
            // atribui-se o respectivo valor
            commS.Parameters["@codigo"].Value = cod;
            Conn.ExecuteNonQuery(commS);
        }

       ~Cliente()
        {
        }

  

    }
}