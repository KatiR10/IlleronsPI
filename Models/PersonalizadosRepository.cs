using System;
using MySqlConnector;
using System.Collections.Generic;
namespace Illerons.Models
{
    public class PersonalizadosRepository
    {
        private const string DadosConexao = "Database= Illerons; Data Source=localhost; User Id=root;";


        public List<Personalizados> listar()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Personalizados";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Personalizados> Lista = new List<Personalizados>();

            while (Reader.Read())
            {
                Personalizados PersonalizadosEncontrado = new Personalizados();
                PersonalizadosEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    PersonalizadosEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("DataNascimento")))
                    PersonalizadosEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    PersonalizadosEncontrado.Telefone = Reader.GetString("Telefone");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    PersonalizadosEncontrado.Email = Reader.GetString("Email");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Roupa")))
                    PersonalizadosEncontrado.Roupa = Reader.GetString("Roupa");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Detalhes")))
                    PersonalizadosEncontrado.Detalhes = Reader.GetString("Detalhes");

                PersonalizadosEncontrado.Usuario = Reader.GetInt32("Usuario");

                Lista.Add(PersonalizadosEncontrado);

            }

            Conexao.Close();
            return Lista;
        }

        public void inserir(Personalizados perso)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO Personalizados (Nome, DataNascimento, Telefone, Email, Roupa, Detalhes, Usuario) VALUES (@Nome, @DataNascimento, @Telefone, @Email, @Roupa, @Detalhes, @Usuario)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", perso.Nome);
            Comando.Parameters.AddWithValue("@DataNascimento", perso.DataNascimento);
            Comando.Parameters.AddWithValue("@Telefone", perso.Telefone);
            Comando.Parameters.AddWithValue("@Email", perso.Email);
            Comando.Parameters.AddWithValue("@Roupa", perso.Roupa);
            Comando.Parameters.AddWithValue("@Detalhes", perso.Detalhes);
            Comando.Parameters.AddWithValue("@Usuario", perso.Usuario);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }

        public void editar(Personalizados perso)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "UPDATE Personalizados SET Nome=@Nome, DataNascimento=@DataNascimento, Telefone=@Telefone, Email=@Email, Roupa=@Roupa, Detalhes=@Detalhes, Usuario=@Usuario WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);


            Comando.Parameters.AddWithValue("@Id", perso.Id);
            Comando.Parameters.AddWithValue("@Nome", perso.Nome);
            Comando.Parameters.AddWithValue("@DataNascimento", perso.DataNascimento);
            Comando.Parameters.AddWithValue("@Telefone", perso.Telefone);
            Comando.Parameters.AddWithValue("@Email", perso.Email);
            Comando.Parameters.AddWithValue("@Roupa", perso.Roupa);
            Comando.Parameters.AddWithValue("@Detalhes", perso.Detalhes);
            Comando.Parameters.AddWithValue("@Usuario", perso.Usuario);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }

        public void remover(Personalizados perso)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "DELETE FROM Personalizados WHERE Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", perso.Id);
            Comando.ExecuteNonQuery();


            Conexao.Close();

        }
        public Personalizados buscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Personalizados WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();
            Personalizados PersonalizadosEncontrado = new Personalizados();

            if (Reader.Read())
            {


                PersonalizadosEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    PersonalizadosEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("DataNascimento")))
                    PersonalizadosEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    PersonalizadosEncontrado.Telefone = Reader.GetString("Telefone");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    PersonalizadosEncontrado.Email = Reader.GetString("Email");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Roupa")))
                    PersonalizadosEncontrado.Roupa = Reader.GetString("Roupa");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Detalhes")))
                    PersonalizadosEncontrado.Detalhes = Reader.GetString("Detalhes");

                PersonalizadosEncontrado.Usuario = Reader.GetInt32("Usuario");

            }


            Conexao.Close();
            return PersonalizadosEncontrado;
        }


    }
}



