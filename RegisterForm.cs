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

namespace PROJET_2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
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

        // fonction pour enregistrer l'utilisateur via un bouton
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Vérifier si les champs sont vides
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            string passwordHash = HashPassword(password);

            string connStr = "server=localhost;user id=root;database=todo-list;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Vérifier si un utilisateur avec cet email existe déjà
                string checkSql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (var checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Un compte avec cet email existe déjà.");
                        return;
                    }
                }

                // Insérer le nouvel utilisateur
                string sql = "INSERT INTO Users (Name, Email, PasswordHash) VALUES (@name, @email, @passwordHash)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                    cmd.ExecuteNonQuery();
                }

                // Récupérer l'ID nouvellement créé
                string getIdSql = "SELECT Id FROM Users WHERE Email = @Email";
                using (var getIdCmd = new MySqlCommand(getIdSql, conn))
                {
                    getIdCmd.Parameters.AddWithValue("@Email", email);
                    int userId = Convert.ToInt32(getIdCmd.ExecuteScalar());

                    MessageBox.Show("Inscription réussie !");
                    var dashboard = new DashboardForm(userId, name); // 👈 deux paramètres
                    dashboard.Show();
                    this.Hide();
                }
            }
        }

        // fonction pour aller à la page de connexion si l'utilisateur a déjà un compte
        private void btnConnection_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}


