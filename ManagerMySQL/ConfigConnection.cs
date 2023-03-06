using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    

namespace ManagerMySQL
{
    public partial class ConfigConnection : Form
    {
        public ConfigConnection()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //guardar en el archivo los datos.

            if (this.txtServidor.Text == "" || this.txtServidor.Text == null)
            {
                MessageBox.Show("Porfavor ingrese un servidor al cual conectarse");
            }
            else
            {
                using (StreamWriter configConnect = new StreamWriter(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL"))
                {
                    configConnect.WriteLine(this.txtServidor.Text + ";" + this.txtRoot.Text + ";" + this.txtPass.Text + ";");
                }

                this.Close();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Servidor: Servidor al cual se va a conectar (ejmplo: localhost). No coloque el puerto. nos conectaremos a la base de datos no al proycto. \n \n " +
                "Usuario: Usuario con el que se conecta a la base de datos. por defecto para las instancias locales usan el usuario 'Root'. En caso de conectarse a una instancia alojada en un Host use el usuario creado en el panel de control de su base de datos \n \n " +
                "Contraseña: dato de seguridad para el acceso a la instancia. En instancias locales por dejecto se deja vacia. En casi de conectarse a una instancia alojada en un Host, digite la contraseña de acceso a su base de datos");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            using (StreamWriter configConnect = new StreamWriter(Directory.GetCurrentDirectory() + @"\Configconnection.mSQL"))
            {
                configConnect.WriteLine(";");
            }
            this.Close();
        }
    }
}
