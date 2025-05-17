namespace PROJET_2
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.listTasks = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(55, 41);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(35, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(55, 73);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "label2";
            // 
            // listTasks
            // 
            this.listTasks.CheckBoxes = true;
            this.listTasks.HideSelection = false;
            this.listTasks.Location = new System.Drawing.Point(58, 158);
            this.listTasks.Name = "listTasks";
            this.listTasks.Size = new System.Drawing.Size(555, 197);
            this.listTasks.TabIndex = 2;
            this.listTasks.UseCompatibleStateImageBehavior = false;
            this.listTasks.View = System.Windows.Forms.View.Details;
            this.listTasks.SelectedIndexChanged += new System.EventHandler(this.listTasks_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.Location = new System.Drawing.Point(341, 71);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(447, 71);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(422, 23);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(100, 20);
            this.txtTask.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nom de la tâche";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Yellow;
            this.btnDisconnect.Location = new System.Drawing.Point(58, 103);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(86, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Déconnexion";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 414);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listTasks);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblWelcome);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ListView listTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisconnect;
    }
}