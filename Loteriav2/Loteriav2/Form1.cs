using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loteriav2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
        }

        public void Jugar ()
        {
            // Guardando los valores en un Array
            byte[] numeros = new byte[6];

            textBox7.Text = ("");

            // Verificando que los números sean correctos antes de ponerlo en la matriz

            if (Convert.ToInt16(textBox1.Text) <= 49
                & Convert.ToInt16(textBox1.Text) != Convert.ToInt16(textBox6.Text)
                & Convert.ToInt16(textBox1.Text) != Convert.ToInt16(textBox4.Text)
                & Convert.ToInt16(textBox1.Text) != Convert.ToInt16(textBox3.Text)
                & Convert.ToInt16(textBox1.Text) != Convert.ToInt16(textBox2.Text)
                & Convert.ToInt16(textBox1.Text) != Convert.ToInt16(textBox5.Text))
            {
                numeros[0] = Convert.ToByte(textBox1.Text);
            }
            else MessageBox.Show("El número de la casilla 1 es incorrecto o repetido");

                if (Convert.ToInt16(textBox2.Text) <= 49
                    & Convert.ToInt16(textBox2.Text) != Convert.ToInt16(textBox6.Text)
                    & Convert.ToInt16(textBox2.Text) != Convert.ToInt16(textBox4.Text)
                    & Convert.ToInt16(textBox2.Text) != Convert.ToInt16(textBox3.Text)
                    & Convert.ToInt16(textBox2.Text) != Convert.ToInt16(textBox5.Text)
                    & Convert.ToInt16(textBox2.Text) != Convert.ToInt16(textBox1.Text))
                {
                    numeros[1] = Convert.ToByte(textBox2.Text);
                }
                else MessageBox.Show("El número de la casilla 2 es incorrecto o repetido");

                if (Convert.ToInt16(textBox3.Text) <= 49
                    & Convert.ToInt16(textBox3.Text) != Convert.ToInt16(textBox6.Text)
                    & Convert.ToInt16(textBox3.Text) != Convert.ToInt16(textBox4.Text)
                    & Convert.ToInt16(textBox3.Text) != Convert.ToInt16(textBox5.Text)
                    & Convert.ToInt16(textBox3.Text) != Convert.ToInt16(textBox2.Text)
                    & Convert.ToInt16(textBox3.Text) != Convert.ToInt16(textBox1.Text))
                {
                    numeros[2] = Convert.ToByte(textBox3.Text);
                }
                else MessageBox.Show("El número de la casilla 3 es incorrecto o repetido");

                if (Convert.ToInt16(textBox4.Text) <= 49
                    & Convert.ToInt16(textBox4.Text) != Convert.ToInt16(textBox6.Text)
                    & Convert.ToInt16(textBox4.Text) != Convert.ToInt16(textBox5.Text)
                    & Convert.ToInt16(textBox4.Text) != Convert.ToInt16(textBox3.Text)
                    & Convert.ToInt16(textBox4.Text) != Convert.ToInt16(textBox2.Text)
                    & Convert.ToInt16(textBox4.Text) != Convert.ToInt16(textBox1.Text))
                {
                    numeros[3] = Convert.ToByte(textBox4.Text);
                }
                else MessageBox.Show("El número de la casilla 4 es incorrecto o repetido");

                if (Convert.ToInt16(textBox5.Text) <= 49
                    & Convert.ToInt16(textBox5.Text) != Convert.ToInt16(textBox6.Text)
                    & Convert.ToInt16(textBox5.Text) != Convert.ToInt16(textBox4.Text)
                    & Convert.ToInt16(textBox5.Text) != Convert.ToInt16(textBox3.Text)
                    & Convert.ToInt16(textBox5.Text) != Convert.ToInt16(textBox2.Text)
                    & Convert.ToInt16(textBox5.Text) != Convert.ToInt16(textBox1.Text))
                {
                    numeros[4] = Convert.ToByte(textBox5.Text);
                }
                else MessageBox.Show("El número de la casilla 5 es incorrecto o repetido");

                if (Convert.ToInt16(textBox6.Text) <= 49
                    & Convert.ToInt16(textBox6.Text) != Convert.ToInt16(textBox5.Text)
                    & Convert.ToInt16(textBox6.Text) != Convert.ToInt16(textBox4.Text)
                    & Convert.ToInt16(textBox6.Text) != Convert.ToInt16(textBox3.Text)
                    & Convert.ToInt16(textBox6.Text) != Convert.ToInt16(textBox2.Text)
                    & Convert.ToInt16(textBox6.Text) != Convert.ToInt16(textBox1.Text))
                {
                    numeros[5] = Convert.ToByte(textBox6.Text);
                }
                else MessageBox.Show("El número de la casilla 6 es incorrecto o repetido");



            // Ordenando de Menor a mayor
            Array.Sort(numeros);

            // Caja negra, digo generar los números ganadores
            // Creando la matriz
            byte[] ganadores = new byte[6];

            // Creando el glorioso Random
            Random r = new Random(DateTime.Now.Millisecond);

            textBox8.Text=("");
            // Creando el for para insertar los números aleatorios
            for (int e = 0; e<=5;e++)
            {
            // goto de nuevo si se repite un número
            denuevo:
                int gs = r.Next(minValue: 1, maxValue: 49);

                if (gs != ganadores[0] & gs != ganadores[1] & gs != ganadores[2] & gs != ganadores[3] & gs != ganadores[4] & gs != ganadores[5])
                {
                    ganadores[e] = byte.Parse(Convert.ToString(gs));
                }
                else goto denuevo;
                

            }


            // Números acertados y cantidad de aciertos
            // Limpiar resultado anterior
            textBox10.Text = ("");

            // Contador números acertados
            int contacertados = 0;

            // Aumentando contador si aplica y poniendo SÓLO los números ganadores
            for (int na = 0; na< numeros.Length;na++)
            {
                for (int ca=0; ca<ganadores.Length ;ca++)
                {
                    if (numeros[na] == ganadores[ca])
                    {
                        contacertados++;
                        textBox10.AppendText(Convert.ToString(ganadores[ca] + " "));
                    }
                }
            }
            
            textBox9.Text=(Convert.ToString(contacertados+ " "));

            //Ordenando de menor a mayor
            Array.Sort(numeros);
            Array.Sort(ganadores);

            // Appendando los números jugados en un TextBox
            for (int i =0;i<=5;i++)
            {
                
                textBox7.AppendText(Convert.ToString(numeros[i] + " "));
            }

            // Appendando los números ganadores en un TextBox
            for (int u = 0; u <= 5; u++)
            {
                textBox8.AppendText(Convert.ToString(ganadores[u] + " "));
            }

            // Preguntando si volver a jugar
            DialogResult result = MessageBox.Show("Quiere volver a jugar? REVISE SUS RESULTADOS PRIMERO!!!", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                textBox1.Text=("");
                textBox2.Text = ("");
                textBox3.Text = ("");
                textBox4.Text = ("");
                textBox5.Text = ("");
                textBox6.Text = ("");
                textBox7.Text = ("");
                textBox8.Text = ("");
                textBox9.Text = ("");
                textBox10.Text = ("");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugar();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ahora vamos a jugar a la Lotería primitiva. Para ello, se pedirá al usuario que introduzca 6 números enteros comprendidos entre el 1 y el 49 ambos incluidos. No estará permitido repetir número. Una vez elegidos los seis números el programa nos mostrará nuestros 6 números así como la combinación ganadora (ordenada de menor a mayor). Esta combinación constará de 6 números entre el 1 y el 49 elegidos al azar por el programa. Finalmente nos dirá cuántos aciertos hemos tenido y nos preguntará si queremos volver a jugar."
                , "Lotería Primitiva");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
