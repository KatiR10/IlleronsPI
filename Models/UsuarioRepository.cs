
using System;
using MySqlConnector;
using System.Collections.Generic;

namespace Illerons.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database= Illerons; Data Source=localhost; User Id=root;";

        public void TestarConexao()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando!");
            Conexao.Close();

        }

        public Usuario ValidarLogin(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String Query = "SELECT * FROM Usuario WHERE Login=@Login and Senha=@Senha";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = null;
            if (Reader.Read())
            {
                UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }



            Conexao.Close();
            return UsuarioEncontrado;
        }

        public List<Usuario> listar()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while (Reader.Read())
            {
                Usuario UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                Lista.Add(UsuarioEncontrado);

            }

            Conexao.Close();
            return Lista;
        }

        public void inserir(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO Usuario (Nome, Login, Senha, DataNascimento) VALUES (@Nome, @Login, @Senha, @DataNascimento)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);


            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }
        public void editar(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);


            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }


        public void remover(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "DELETE FROM Usuario WHERE Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }
 public Usuario buscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if (Reader.Read())
            {
                UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

            }

            Conexao.Close();
            return UsuarioEncontrado;
        }




    }
}