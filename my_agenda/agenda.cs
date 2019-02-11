using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace my_agenda
{
    class agenda
    {
        private MySqlConnection cn = null; //para la conexion
        private MySqlCommand cmd = null; // para ejecutar comandos 
        private MySqlDataReader reader = null; //para almacenar los datos
        private DataTable table = null; // para organizar la informacion recibida

        //metodo para insertar en la base de datos
        public bool insertar(string nombre, string telefono)
        {
            try
            {
                string query = "INSERT INTO directorio(nombre, telefono)VALUES('" + nombre + "','" + telefono + "')";
                cn = conexion.conectar();
                cn.Open();
                cmd = new MySqlCommand(query, cn);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return false;
        }

        //metodo para consultar
        public DataTable consultar()
        {
            try
            {
                nombresColumnas();
                string query = "SELECT * FROM directorio";
                cn = conexion.conectar();
                cn.Open();
                cmd = new MySqlCommand(query, cn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    object[] valores = new object[3];
                    valores[0] = reader["id"];
                    valores[1] = reader["nombre"];
                    valores[2] = reader["telefono"];
                    table.Rows.Add(valores);
                    
                    
                    //table.Rows.Add(new object[]{ reader["id"], reader["nombre"], reader["telefono"] });
                }
                reader.Close();
                //cn.Close();
                return table;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return table;
        }

        //metodo para eliminar
        public bool eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM directorio WHERE id='" + id + "'";
                cn = conexion.conectar();
                cn.Open();
                cmd = new MySqlCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //cn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Ocurrio un error en el proceso...");
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
              
            } return false;
        } 

        //metodo para filtrar
        public DataTable filtrar(string filtro)
        {
            try
            {
                nombresColumnas();
                string query = "SELECT * FROM directorio WHERE nombre LIKE '" + filtro + "%'";
                cn = conexion.conectar();
                cn.Open();
                cmd = new MySqlCommand(query, cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(new object[] { reader["id"], reader["nombre"], reader["telefono"] });
                }
                reader.Close();
                cn.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ocurrio un error en el proceso");
            }
            catch (NullReferenceException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ocurrio un error en el proceso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ocurrio un error en el proceso");
            }
            return table;
        }
        
        //metodo para actualizar
        public bool actualizar(int id, string nombre, string telefono)
        {
            try
            {
                string query = "UPDATE directorio SET nombre='" + nombre + "',telefono='" + telefono + "'WHERE id='" + id.ToString() + "'";
                //System.Windows.Forms.MessageBox.Show(query);
                cn = conexion.conectar();
                cn.Open();
                cmd = new MySqlCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                   // cn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Ocurrio un error en el proceso...");
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return false; 
        }

        //metodo para darle nombres a las columnas
        private void nombresColumnas()
        {
            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Nombre");
            table.Columns.Add("Telefono");
        }
    }
}
