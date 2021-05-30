using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numerosj.ReadOnly = true;
            numerosg.ReadOnly = true;
            txtaciertos.ReadOnly = true;
        }

        public void Jugar ()
        {
            // Goto que inicia el método Jugar de nuevo
            Iniciar:
            // Crear la matriz
            byte[] numeros = new byte[6];

            //Recibir datos
            for (int i = 0; i <= 5; i++)
            {
                // Pidiendo datos con InputBox
                string parsenumeros = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese su número " + (i+1) + " (del 1 al 49)",
                "Jugada " + (i+1) + " de 6");

                // Convirtiendo datos pedidos a Byte y poniéndolo en la matriz
                numeros[i] = byte.Parse(parsenumeros);

                // Array.Sort(numeros);
                
            }

            // Caja negra digo crear número aleatorio
            // Inicializando el Random
            Random r = new Random(DateTime.Now.Millisecond);

            byte[] aleatorio = new byte[6];
            for (int e = 0; e <= 5; e++)
            {
                int rs = r.Next(minValue: 1, maxValue: 49);
                aleatorio[e] = byte.Parse(Convert.ToString(rs));

            }


            // Limpiando los TextBox antes de recibir los números
            numerosj.Text=("");
            numerosg.Text = ("");

            // Mostrando los números jugados
            for (int a = 0; a <= 5; a++)
            {
               numerosj.AppendText(Convert.ToString(numeros[a] + " "));
            }

            // Mostrando los números aleatorios
            for (int a = 0; a <= 5; a++)
            {
                numerosg.AppendText(Convert.ToString(aleatorio[a] + " "));
            }

            //Preguntando si volver a jugar
            DialogResult result = MessageBox.Show("Quieres volver a jugar?","Volver a jugar",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // // Goto que inicia el método Jugar de nuevo
                goto Iniciar;
            }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Agregado en 2021
            Application.Exit();
        }
    }
}
