using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ManagerMySQL
{
    public partial class CreateBackUp : Form
    {
        public string dbSelected { get; set; }
        public CreateBackUp(string _dbSelected)
        {
            InitializeComponent();
            dbSelected = _dbSelected;
            this.txt_BaseDatos.Text = dbSelected;
            this.txt_NameDB.Text = dbSelected;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Acept_Click(object sender, EventArgs e)
        {
            if (this.txtPathFile.Text != "")
            {
                string query = "mysqldump.exe -u root " + dbSelected + " > " + Path.Combine(this.txtPathFile.Text, this.txt_NameDB.Text + ".sql").ToString();
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine(query);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    MessageBox.Show("Proceso terminado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione la carpeta en donde guardara la base de datos");
            }
        }

        private void btn_BrowserFolder_Click(object sender, EventArgs e)
        {
            this.fb_Directory.ShowDialog();
            this.txtPathFile.Text = this.fb_Directory.SelectedPath;
        }
    }
}
