using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentesVisuales
{
    public partial class Form1 : Form
    {
        List<string> nombres = new List<string>();
        List<Paciente> pacientes = new List<Paciente>();
        List<int> enteros = new List<int>();
        public Form1()
        {
            pacientes.Add(new Paciente() {Id=45,Nombre="" });
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }
    }

    public class Paciente//modelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
