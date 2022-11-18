using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace BaseDatosFireBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "1qc09IprkPefO5O1V9tySgNeYWljlwSfgppchvWZ",
            BasePath = "https://fir-bdcsharp-52a7a-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }catch
            {
                MessageBox.Show("Existe un problema en la conexión de la Internet");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante std = new Estudiante
            {
                Nombre = textBox1.Text,
                Cuenta = textBox2.Text,
                Semestre = textBox3.Text,
                Grupo = textBox4.Text
            };
            var setter = client.Set("ListaEstudiantes/" + textBox2.Text, std);
            MessageBox.Show("Datos insertados correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Estudiante std = new Estudiante
            {
                Nombre = textBox1.Text,
                Cuenta = textBox2.Text,
                Semestre = textBox3.Text,
                Grupo = textBox4.Text
            };
            var setter = client.Update("ListaEstudiantes/" + textBox2.Text, std);
            MessageBox.Show("Datos actualizados correctamente.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var resultado = client.Delete("ListaEstudiantes/" + textBox2.Text);
            textBox2.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Datos eliminados correctamente.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resultado = client.Get("ListaEstudiantes/" + textBox2.Text);
            Estudiante std = resultado.ResultAs<Estudiante>();
            textBox1.Text = std.Nombre;
            textBox3.Text = std.Semestre;
            textBox4.Text = std.Grupo;
            MessageBox.Show("Datos encontrados en la base de datos.");
        }
    }
}
