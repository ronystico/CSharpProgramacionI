using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;

namespace PruebaMatematica
{
    public partial class Form1 : Form
    {
        // Creando el objeto llamado randomizer tomando como semilla los milisegundos actuales
        Random randomizer = new Random(DateTime.Now.Millisecond);

        // Creando las variables que guarda los números de la suma
        int addend1, addend2;

        // Se guardan los números aleatorios de resta en las variables
        int minuend, subtrahend;

        // // Se guardan los números aleatorios de multiplicación en las variables
        int multiplicand, multiplier;

        // // Se guardan los números aleatorios de división en las variables
        int dividend, divisor;

        // Variable que observa el tiempo restante
        int timeLeft;

        // Método que reproduce el sonido
        private void ReproducirSonido ()
        {
            SoundPlayer sonido = new SoundPlayer(Properties.Resources.S_23);
            sonido.Play();
        }

        // Creando el Método que inicializa el contador y llena los problemas
        public void StartTheQuiz()
        {
            // Se guardan los números aleatorios de suma en las variables
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Se convierten los datos a string y se muestran al usuario
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Se pone el NumericUpDown en Cero
            suma.Value = 0;

            // Se llena el problema de la resta con un método parecido al de la suma
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            diferencia.Value = 0;

            // Se llena el problema de la multiplicación con un método parecido al de la suma
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            producto.Value = 0;

            // Se llena el problema de la división con un método parecido al de la suma
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            cociente.Value = 0;

            // Start the timer.
            // Modified in 2021. How dare I put 30 seconds only XD
            timeLeft = 90;
            timeLabel.Text = "90 segundos";
            timer1.Start();

        }

        // Método que evalúa todas las respuestas
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == suma.Value) && (minuend - subtrahend == diferencia.Value) && (multiplicand * multiplier == producto.Value) && (dividend / divisor == cociente.Value))
                return true;
            else
                return false;
        }

        /* Método que reproduce un sonido y cambia de color el NumericUpDown al tener
           una respuesta correcta */
        private void Sonido_RCorrecta(object sender, EventArgs e)
        {
            // Suma
            if (addend1 + addend2 == suma.Value)
            {
                ReproducirSonido();
                suma.BackColor = Color.LightGreen;
            }

            // Resta
            if (minuend - subtrahend == diferencia.Value)
            {
                ReproducirSonido();
                diferencia.BackColor = Color.LightGreen;
            }

            // Multiplicación
            if (multiplicand * multiplier == producto.Value)
            {
                ReproducirSonido();
                producto.BackColor = Color.LightGreen;
            }

            // División
            if (dividend / divisor == cociente.Value)
            {
                ReproducirSonido();
                cociente.BackColor = Color.LightGreen;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            suma.BackColor = Color.White;
            diferencia.BackColor = Color.White;
            producto.BackColor = Color.White;
            cociente.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                /* Si CheckTheAnswer() es verdadero, entonces el usuario
                   recibe la respuesta verdadera. Después recibe la respuesta verdadera
                   y muestra un MessageBox */
                timer1.Stop();
                MessageBox.Show("¡¡¡Todas tus respuestas fueron correctas!!!",
                "¡¡¡Felicidades!!!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                /* Si CheckTheAnswer() aún no es verdadero, mantener
                   restando tiempo. También se actualiza el tiempo restante en el Label */
                timeLeft--;
                timeLabel.Text = timeLeft + " segundos";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "¡¡¡Se acabó el tiempo!!!";
                MessageBox.Show("No lo finalizaste a tiempo", "¡¡¡Lo siento!!!");

                suma.Value = addend1 + addend2;
                diferencia.Value = minuend - subtrahend;
                producto.Value = multiplicand * multiplier;
                cociente.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            // Poner el Label del tiempo restante en rojo cuando queden 5 segundos
            if (timeLeft<=5)
            {
                timeLabel.BackColor = Color.Red;
            }
            else
            {
                timeLabel.BackColor = Color.LightGreen;
            }
            
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Seleccionar toda la respuesta en el control NumericUpDown.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
