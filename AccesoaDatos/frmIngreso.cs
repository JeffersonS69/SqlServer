using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoaDatos
{
    public partial class frmIngreso : Form
    {
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //1. Crear la conexión
            // SqlConnection conexion = new SqlConnection(@"server = //; database = //; user id= //; password= //");
            SqlConnection conexion = new SqlConnection(@"server=L-ELR-001\SQLEXPRESS; database =TI2021; Intregrated Security=true");

            //2. Definir una operación
            string sql = "insert into personas(cedula, apellidos, nombres, fechaNacimiento, peso)";
            sql += "values (@cedula, @apellidos, @nombres, @fechaNacimiento, @peso)";

            //3. Ejecutar la operación
            SqlCommand comando = new SqlCommand(sql, conexion);

            //3.1 Configurar los parámetros: @cedula, @apellidos, @nombres, @fechaNacimiento, @peso
            comando.Parameters.Add(new SqlParameter("@cedula", this.txtCedula.Text));
            comando.Parameters.Add(new SqlParameter("@apellidos", this.txtApellidos.Text));
            comando.Parameters.Add(new SqlParameter("@nombres", this.txtNombres.Text));
            comando.Parameters.Add(new SqlParameter("@fechaNacimiento", this.txtFechaNac.Text));
            comando.Parameters.Add(new SqlParameter("@peso", this.txtPeso.Text));

            //3.2 Abir conexión
            conexion.Open();
            //3.3 insertar el registro en la BDD
            int res = comando.ExecuteNonQuery();

            //4. Cerrar conexión
            conexion.Close();

            MessageBox.Show("Filas insertadas: " + res.ToString());

        }
    }
}
