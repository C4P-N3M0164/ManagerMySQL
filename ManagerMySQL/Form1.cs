using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ManagerMySQL
{
    public partial class Form1 : Form
    {

        MySqlConnectionStringBuilder builder;
        DataTable dataBases = new DataTable();
        string globalQuery = "";

        string dbSelected;

        public Form1()
        {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(35, 32, 39);

            builder = new MySqlConnectionStringBuilder();

            ConfigConnection configWindow = new ConfigConnection();
            configWindow.StartPosition = FormStartPosition.CenterScreen;
            // Abrir ventana de conexion.

            this.txt_Result.Font = new Font("Console", 12f);
            this.txt_Result.ScrollBars = ScrollBars.Vertical;

            this.tabPage1.Text = "Query" + (tc_control1.TabCount + 1);
            this.tabPage2.Text = "Resultados";
            this.tabPage3.Text = "Error";

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#bfdbff");
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5AE669");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            configWindow.ShowDialog();
            DataConfigInstance();
            ConfigMenu();
        }

        private void DataConfigInstance()
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL");
            var config = sr.ReadToEnd();
            string[] datos = config.Split(';');

            if (datos[0].ToString() != "")
            {
                builder.Server = datos[0].ToString();
                builder.UserID = datos[1].ToString();
                builder.Password = datos[2];

                string query = "show databases";
                dataBases = ExecuteBasicQueryes(query);
                for (int i = 0; i < dataBases.Rows.Count; i++)
                {
                    this.cmb_DataBases.Items.Add(dataBases.Rows[i]["Database"].ToString());
                }
                sr.Close();
                this.cmb_DataBases.SelectedIndex = 0;
                lbl_InstanceName.Text = "Instance: " + datos[0] + " User: " + datos[1];
            }
        }

        private void ConfigMenu()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            //treeView1.Nodes.Add("Base de datos");
            //treeView1.Nodes[0].Nodes.Add("Tablas");
            //treeView1.Nodes[0].Nodes[0].Nodes.Add("Campos");
            //treeView1.Nodes[0].Nodes.Add("Tablas");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Campos");
            //treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Alguna otra cosa");

            // Generar campos de nivel 1 (Bases de datos)
            for (int i = 0; i < dataBases.Rows.Count; i++)
            {
                treeView1.Nodes.Add(dataBases.Rows[i]["Database"].ToString());
                treeView1.Nodes[i].Name = dataBases.Rows[i]["Database"].ToString();
                treeView1.Nodes[i].ContextMenuStrip = this.cms_Menu;
            }

            // Generar campos de nivel 2 (Tablas)
            DataTable dt = new DataTable();
            for (int i = 0; i < dataBases.Rows.Count; i++)
            {
                string query = "show tables from " + dataBases.Rows[i]["Database"].ToString();
                dt = ExecuteBasicQueryes(query);
                for (int e = 0; e < dt.Rows.Count; e++) //Agregamos cada tabla a un nuevo nodo que le pertenezca a esa base de datos.
                {
                    string name = "Tables_in_" + dataBases.Rows[i]["Database"].ToString();
                    treeView1.Nodes[i].Nodes.Add(dt.Rows[e][name].ToString());
                }
            }

            treeView1.EndUpdate();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            string query = this.txt_Result.SelectedText;
            dataGridView1.DataSource = ExecuteQueryes(query);
        }

        private void txt_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tabPage1.Text != "Query" + (tc_control1.TabCount + 1) + "*")
            {
                this.tabPage1.Text = "Query" + (tc_control1.TabCount + 1) + "*";
            }

            if (e.KeyCode == Keys.F5)
            {
                string query = this.txt_Result.SelectedText;
                dataGridView1.DataSource = ExecuteQueryes(query);
                globalQuery = query;

                string[] partes = query.Split(' ');

                if (partes[0].ToLower() == "create")
                {
                    ConfigMenu();
                }

                this.txt_Result.Focus();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = saveFileDialog1.FileName;
                    using (StreamWriter sw = new StreamWriter(pathFile))
                    {
                        sw.WriteLine(this.txt_Result.Text);
                    }
                }

                this.tabPage1.Text = "Query" + (tc_control1.TabCount + 1);
            }

            //MessageBox.Show(this.txt_Result.Lines.Length.ToString());
        }

        private void ReadConfigConnection()
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL"); //m de main.(solo es una denominacion).
            var config = sr.ReadToEnd();
            string[] datos = config.Split(';');

            builder.Server = datos[0];
            builder.UserID = datos[1];
            builder.Password = datos[2];
            builder.Database = datos[3];

            sr.Close();
        }

        private DataTable ExecuteBasicQueryes(string query)
        {

            MySqlConnection databaseConnection = new MySqlConnection(builder.ToString());
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = query;

            DataTable dt = new DataTable();
            try
            {
                databaseConnection.Open();
                dt.Load(commandDatabase.ExecuteReader());

                if (dt.Rows.Count == 0)
                {
                    // hacer log
                    MessageBox.Show("No hay datos disponibles");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            databaseConnection.Close();
            return dt;
        }

        private BindingSource ExecuteQueryes(string query)
        {
            ReadConfigConnection();

            BindingSource source = new BindingSource();
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(builder.ToString());
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = query;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    source.DataSource = reader;
                    while (reader.Read())
                    {
                        source.DataSource = reader;
                    }

                    this.txt_Errors.Text = "Consulta ejecutada correctamente !!";
                    this.tabResults.SelectTab(0);
                }
                else
                {
                    if (reader.RecordsAffected > 0)
                    {
                        this.txt_Errors.Text = "Se " + (reader.RecordsAffected >= 2 ? "han" : "ha") + " afectado " + reader.RecordsAffected + (reader.RecordsAffected >= 2 ? " lineas" : " linea");
                        this.tabResults.SelectTab(1);
                    }
                    else
                    {
                        source.DataSource = "no data";
                        this.txt_Errors.Text = "No se encontraron datos. " + query;
                        this.tabResults.SelectTab(1);
                    }
                }

                databaseConnection.Close();
                //reader.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción.
                // Crear un log.
                //MessageBox.Show(ex.Message);
                this.txt_Errors.Text = ex.Message;
                this.tabResults.SelectTab(1);
            }
            return source;
        }

        private void cmb_DataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL"); //m de main.(solo es una denominacion).
            var config = sr.ReadToEnd();
            string[] datos = config.Split(';');
            sr.Close();

            //guardar en el archivo la base de datos.
            using (StreamWriter configConnect = new StreamWriter(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL"))
            {
                configConnect.Write(datos[0] + ";" + datos[1] + ";" + datos[2] + ";" + this.cmb_DataBases.Text + ";");
            }
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dbSelected);
            CreateBackUp _createBackup = new CreateBackUp(dbSelected);
            _createBackup.ShowDialog();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            dbSelected = e.Node.Name;
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exportar datos a un archivo json.

            ReadConfigConnection();

            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(builder.ToString());
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = globalQuery;

            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Columns.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }
            dt.Load(reader);

            var _json = JsonConvert.SerializeObject(dt);

            fb_ToExport.ShowDialog();
            var pathFile = fb_ToExport.SelectedPath + @"\QueryJson.json";

            using (StreamWriter sw = File.AppendText(pathFile))
            {
                sw.WriteLine(_json);
            }

            MessageBox.Show("Proceso terminado");
        }

        private void txt_Result_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            foreach (string file in files)
            {
                StreamReader sr = new StreamReader(file); 
                var dataSave = sr.ReadToEnd();
                this.txt_Result.AppendText(dataSave);
                sr.Close();
            }
        }

        private void txt_Result_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
