using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AccesoaDatos.Clases
{
    public static class Personas
    {
        private static string cadenacon= "server=JEFF\\SQLEXPRESS; database=TI2021; Integrated Security=true";

        public static int insertar(string cedula, string apellidos, string nombres, DateTime fechanacimiento, double peso)
        {
            SqlConnection conexion = new SqlConnection(cadenacon);
            string sql = "insert into personas(Cedula, Apellidos, Nombres, FechaNacimiento, Peso) ";
            sql += "values (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Peso)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            comando.Parameters.Add(new SqlParameter("@Apellidos", apellidos));
            comando.Parameters.Add(new SqlParameter("@Nombres", nombres));
            comando.Parameters.Add(new SqlParameter("@FechaNacimiento", fechanacimiento));
            comando.Parameters.Add(new SqlParameter("@Peso", peso));
            conexion.Open();
            int res = comando.ExecuteNonQuery();
            conexion.Close();

            return res;
        }

        public static int borrar(string cedula)
        {
            SqlConnection conexion = new SqlConnection(cadenacon);
            string sql = "delete from personas ";
            sql += "where Cedula=@Cedula";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            conexion.Open();
            int res = comando.ExecuteNonQuery();
            conexion.Close();

            return res;
        }
        
        public static DataTable seleccionar(string cedula)
        {
            SqlConnection conexion = new SqlConnection (cadenacon);
            string sql = "Select cedula, apellidos, nombres, fechaNacimiento, peso ";
            sql += "from personas where cedula=@cedula";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            SqlDataAdapter ad1 = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            ad1.Fill(dt);
            return dt;

        }
        public static DataTable getPersonas()
        {
            SqlConnection conexion = new SqlConnection(cadenacon);

            string sql = "Select Cedula, Apellidos, Nombres, upper(Apellidos +' '+ Nombres) as NombreCompleto, FechaNacimiento, Peso ";
            sql += "from personas order by Apellidos, Nombres";


            SqlCommand comando = new SqlCommand(sql, conexion);
            SqlDataAdapter ad1 = new SqlDataAdapter(comando);

            //Pasar los datos desde el adaptador a un datatable
            DataTable dt = new DataTable();
            ad1.Fill(dt);


            return dt;
        }


      

    }
}
