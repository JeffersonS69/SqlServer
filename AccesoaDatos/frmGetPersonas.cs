using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccesoaDatos
{
    public partial class frmGetPersonas : Form
    {
        public frmGetPersonas()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
           this.dgPersonas.DataSource = Clases.Personas.getPersonas();
        }
        private void cargaPersonas()
        {
            this.dgPersonas.DataSource = Clases.Personas.getPersonas();
        }

        

        private void dgPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(this.dgPersonas.Columns[e.ColumnIndex].Name == "LinkSeleccionar")
                {
                    string cedula = this.dgPersonas["Cedula", e.RowIndex].Value.ToString();
                    frmConxPersonas form1 = new frmConxPersonas(cedula);
                    form1.ShowDialog();
                    //MessageBox.Show("Clic en seleccionar !!!");
                }else if(this.dgPersonas.Columns[e.ColumnIndex].Name == "LinkEliminar")
                {
                    //MessageBox.Show("Clic en eliminar!!!");
                    string cedula = this.dgPersonas["Cedula", e.RowIndex].Value.ToString();
                    DialogResult dial = MessageBox.Show("Desea Eliminar los datos", "Mensaje para los Papus", MessageBoxButtons.YesNo);
                    if(dial == DialogResult.No)
                        return;

                    int respuesta = Clases.Personas.borrar(cedula);
                    if (respuesta > 0)
                    {
                        this.cargaPersonas();
                        MessageBox.Show("Registro borrado con éxito...");
                    }
                    else
                        MessageBox.Show("No se puedo borrar el registro...");

                    //MessageBox.Show("La cédula es: " + cedula); 
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmGetPersonas_Load(object sender, EventArgs e)
        {

        }
    }
}
