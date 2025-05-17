using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PROJET_2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        //fonction pour hasher le mot de passe
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        //fonction pour se connecter via un bouton
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            
            string connStr = "server=localhost;user id=root;database=todo-list;";


            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string passwordHash = HashPassword(password);

                    string sql = "SELECT Id, Name FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("Id");
                                string name = reader.GetString("Name");

                                MessageBox.Show("Connexion réussie !");
                                var dashboard = new DashboardForm(userId, name);
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Email ou mot de passe incorrect.");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de connexion à la base de données : " + ex.Message);
            }
        }
    }
}
