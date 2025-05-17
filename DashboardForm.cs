using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJET_2
{
    public partial class DashboardForm : Form
    {
        private int userId;
        private string userName;

        public DashboardForm(int userId, string userName)
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
            this.Load += Dashboard_Load;
            listTasks.ItemCheck += new ItemCheckEventHandler(listTasks_ItemCheck);
            listTasks.ItemCheck += new ItemCheckEventHandler(listTasks_ItemCheck);
            this.userId = userId;
            this.userName = userName;
            lblWelcome.Text = $"Bienvenue, {userName} 👋";
            lblDate.Text = $"Connecté le : {DateTime.Now}";
            LoadTasks();
        }

        //fonction pour initialiser le dashboard
        private void Dashboard_Load(object sender, EventArgs e)
        {
            listTasks.View = View.Details;
            listTasks.CheckBoxes = true;
            listTasks.Columns.Clear();
            listTasks.Columns.Add("Tâches", 300);
            listTasks.Columns.Add("État", 150);
            listTasks.Columns.Add("Créée le", 150);
        }

        //fonction pour charger les tâches propres à l'utilisateur
        private void LoadTasks()
        {
            listTasks.Items.Clear();

            string connStr = "server=localhost;user=root;password=;database=todo-list;port=3306;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Description, IsCompleted, CreatedAt FROM Tasks WHERE UserId = @UserId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var isCompleted = reader.GetBoolean("IsCompleted");
                            var createdAt = reader.GetDateTime("CreatedAt");
                            var item = new ListViewItem(reader.GetString("Description"));
                            item.Tag = reader.GetInt32("Id");
                            item.Checked = isCompleted;
                            item.SubItems.Add(isCompleted ? "Tâche effectuée" : "Tâche non effectuée");
                            item.SubItems.Add(createdAt.ToString("dd/MM/yyyy HH:mm")); 
                            listTasks.Items.Add(item);
                        }

                    }
                }
            }
        }

        //fonction pour ajouter une tâche en saisissant le nom de la tâche et en cliquant sur le bouton ajouter
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string desc = txtTask.Text.Trim();
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Veuillez saisir une description de tâche.");
                return;
            }

            string connStr = "server=localhost;user=root;password=;database=todo-list;port=3306;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Tasks (UserId, Description) VALUES (@UserId, @Description)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Description", desc);
                    cmd.ExecuteNonQuery();
                }
            }

            txtTask.Clear();
            LoadTasks();
        }

        //supprimer une tâche en saisissant le nom de la tâche et en cliquant sur le bouton supprimer
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTasks.CheckedItems)
            {
                int taskId = (int)item.Tag;

                string connStr = "server=localhost;user=root;password=;database=todo-list;port=3306;";
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "DELETE FROM Tasks WHERE Id = @Id AND UserId = @UserId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", taskId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadTasks();
        }

        //fonction pour mettre à jour l'état de la tâche en cochant un checkbox
        private void listTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                var item = listTasks.Items[e.Index];
                int taskId = (int)item.Tag;
                bool isCompleted = (e.NewValue == CheckState.Checked);

                string connStr = "server=localhost;user=root;password=;database=todo-list;port=3306;";
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id AND UserId = @UserId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IsCompleted", isCompleted);
                        cmd.Parameters.AddWithValue("@Id", taskId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }


                item.SubItems[1].Text = isCompleted ? "Tâche effectuée" : "Tâche non effectuée";
            }));
        }

        //éviter un bug lorsque l'utilisateur coche
        private void listTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTasks.ItemCheck += new ItemCheckEventHandler(listTasks_ItemCheck);

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
