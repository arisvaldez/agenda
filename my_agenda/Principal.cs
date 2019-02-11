using System;
using System.Data;
using System.Windows.Forms;

namespace my_agenda
{
    public partial class Principal : Form
    {
        private int id;
        agenda age = new agenda();
        DataTable dt;

        public Principal()
        {
            InitializeComponent();
            restablecerControles();
            consultar();
            dgvAgenda.Columns["id"].Visible = false;
        }

        private void consultar()
        {
            dgvAgenda.DataSource = dt = age.consultar();

        }
     
        private void obtenerId()
        {
            id = Convert.ToInt32(dgvAgenda.CurrentRow.Cells["id"].Value);
        }

        private void obtenerDatos()
        {
            obtenerId();
            txtNombre.Text = dgvAgenda.CurrentRow.Cells["nombre"].Value.ToString();
            txtTelefono.Text = dgvAgenda.CurrentRow.Cells["telefono"].Value.ToString();
        }

        private void restablecerControles()
        {
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtFiltrar.Clear();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
        }


        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                return;
            }
            bool rs = age.insertar(txtNombre.Text, txtTelefono.Text);

            if (rs)
            {
                MessageBox.Show("Registro insertado correctamente");
                consultar();
            }
            restablecerControles();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool rs = age.actualizar(id, txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Regidtro actualizado correctamente...");
                consultar();
            }
            restablecerControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            DialogResult r =
                MessageBox.Show(
                "Esta seguro que desea eliminar este registro?",
                "Eliminar",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (r == DialogResult.OK)
            {
                bool rs = age.eliminar(id);
                if (rs)
                {
                    MessageBox.Show("Regidtro eliminado correctamente");
                    consultar();
                }
                restablecerControles();
            }

        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            string valor = txtFiltrar.Text;
             dt.DefaultView.RowFilter = $"Nombre Like '%{valor}%'";
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            restablecerControles();
            obtenerId();
            this.btnEliminar.Enabled = true;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = true;
        }

    }
}
