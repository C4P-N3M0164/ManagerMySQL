namespace ManagerMySQL
{
    partial class CreateBackUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BaseDatos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.btn_BrowserFolder = new System.Windows.Forms.Button();
            this.btn_Acept = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.fb_Directory = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NameDB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copia de seguridad";
            // 
            // txt_BaseDatos
            // 
            this.txt_BaseDatos.Location = new System.Drawing.Point(148, 70);
            this.txt_BaseDatos.Name = "txt_BaseDatos";
            this.txt_BaseDatos.ReadOnly = true;
            this.txt_BaseDatos.Size = new System.Drawing.Size(377, 20);
            this.txt_BaseDatos.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Guardar en:";
            // 
            // txtPathFile
            // 
            this.txtPathFile.Location = new System.Drawing.Point(148, 114);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.ReadOnly = true;
            this.txtPathFile.Size = new System.Drawing.Size(328, 20);
            this.txtPathFile.TabIndex = 4;
            // 
            // btn_BrowserFolder
            // 
            this.btn_BrowserFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BrowserFolder.Location = new System.Drawing.Point(482, 112);
            this.btn_BrowserFolder.Name = "btn_BrowserFolder";
            this.btn_BrowserFolder.Size = new System.Drawing.Size(43, 23);
            this.btn_BrowserFolder.TabIndex = 5;
            this.btn_BrowserFolder.Text = "...";
            this.btn_BrowserFolder.UseVisualStyleBackColor = true;
            this.btn_BrowserFolder.Click += new System.EventHandler(this.btn_BrowserFolder_Click);
            // 
            // btn_Acept
            // 
            this.btn_Acept.Location = new System.Drawing.Point(428, 198);
            this.btn_Acept.Name = "btn_Acept";
            this.btn_Acept.Size = new System.Drawing.Size(93, 33);
            this.btn_Acept.TabIndex = 6;
            this.btn_Acept.Text = "Aceptar";
            this.btn_Acept.UseVisualStyleBackColor = true;
            this.btn_Acept.Click += new System.EventHandler(this.btn_Acept_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(527, 198);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 33);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Cancelar";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Guardar como:";
            // 
            // txt_NameDB
            // 
            this.txt_NameDB.Location = new System.Drawing.Point(148, 153);
            this.txt_NameDB.Name = "txt_NameDB";
            this.txt_NameDB.Size = new System.Drawing.Size(377, 20);
            this.txt_NameDB.TabIndex = 9;
            // 
            // CreateBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 243);
            this.Controls.Add(this.txt_NameDB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Acept);
            this.Controls.Add(this.btn_BrowserFolder);
            this.Controls.Add(this.txtPathFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_BaseDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateBackUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CreateBackUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BaseDatos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.Button btn_BrowserFolder;
        private System.Windows.Forms.Button btn_Acept;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.FolderBrowserDialog fb_Directory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NameDB;
    }
}