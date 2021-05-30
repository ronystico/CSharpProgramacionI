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

namespace MatchingGame
{
    public partial class Form1 : Form
    {

        // firstClicked se refiere al primer Label que controla          
        // cuando el jugador hace click, pero puede ser null          
        // cuando el jugador no ha hecho click en algún Label todavía         
        Label firstClicked = null;

        // Variable para el contador de segundos
        int tiemporestante = 60;

        // secondClicked se refiere al primer Label
        // que el jugador hace click        
        Label secondClicked = null; 

        // Este Random selecciona un orden aleatorio para "s"         
        Random random = new Random();

        // Cada letra es un icono diferente        
        // en la fuente Webdings
        // y cada icono aparece dos veces en la lista       
        List<string> icons = new List<string>()
        {
            "y", "y", "q", "q", "x", "x", "g", "g",
            "w", "w", "a", "a", "3", "3", "j", "j"
        };

        // Sonido respuesta correcta
        private void SonidoCorrecta ()
        {
            SoundPlayer s = new SoundPlayer(global::JuegoFormarPareja.Properties.Resources.Acierto);
            s.Play();
        }

        // Sonido respuesta incorrecta
        private void SonidoIncorrecta()
        {
            SoundPlayer s = new SoundPlayer(global::JuegoFormarPareja.Properties.Resources.S_23);
            s.Play();
        }

        // Sonido voltear Label
        private void SonidoVoltear()
        {
            // No se va a implementar, es un juego rápido
        }

        private void AssignIconsToSquares()
        {
            // El TableLayoutPanel tiene 16 labels,             
            // y el icon list tiene 16 iconos,             
            // se genera un icono aleatorio y se añade a cada Label                      
            foreach (Control control in tableLayoutPanel1.Controls)             {
                Label iconLabel = control as Label;
                if (iconLabel != null)                 {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;                     
                    icons.RemoveAt(randomNumber);
                }
            } 
        }

        public void CheckForWinner()
        {             // Explora todos los labels en el TableLayoutPanel,              
                      // revisando si todos coinciden             
            foreach (Control control in tableLayoutPanel1.Controls)             {
                Label iconLabel = control as Label; 

            if (iconLabel != null) {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
        }

            // Si el ciclo no retorna, no encuentra iconos que no coinciden
            // Significa que el usuario ganó. Se muestra un mensaje y se cierra el Form
            timer2.Stop();
            MessageBox.Show("Coincidiste en todos los iconos!", "Felicidades!");
            Close();
            
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            SonidoCorrecta();
            
        }

        private void Evento_clic(object sender, EventArgs e)
        {

            // Comienza a contar el tiempo restante
            if (timer2.Enabled==false)
            {
                timer2.Start();
            }
            

            // El timer es sólo para cuando no coinciden dos iconos          
            // que el usuario muestra, así que ignora los clics si el timer          
            // está en ejecución        
            if (Timer1.Enabled == true) return; 

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Si el label clickeado es negro, se clickeó un icono             
                // que ya fue revelado, así que ignora el clic
                if (clickedLabel.ForeColor == Color.LightCyan) return;

                // Si firstClicked es nulo, ese es el primer icono              
                // en el par que el jugador hizo clic,             
                // entonces se asigna a firstClicked el label que el jugador
                // hizo clic, cambia su color a negro y retornar            
                if (firstClicked == null)             {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.LightCyan; 

                return;
            }

                // Llegados a este punto, el timer no está corriendo
                // y firstClicked no es nulo
                // entonces debería ser el segundo icono que el jugador hace clic
                // Poner su color a negro            
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.LightCyan;

                // Revisar si el jugador ganó             
                CheckForWinner(); 

                // Cuando el jugador tiene dos respuestas correctas, se reestablece             
                // firstClicked y secondClicked             
                // luego se reproduce el sonido de respuesta correcta o incorrecta
                // depende el caso
                if (firstClicked.Text == secondClicked.Text)             {
                    SonidoCorrecta();
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                else SonidoIncorrecta();

                // En este punto, el jugador hizo clic en dos iconos, así que comienza
                // el timer y luego de 3/4 de segundos oculta los iconos          
                Timer1.Start();

            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Para el timer         
            Timer1.Stop();

            // Oculta los iconos
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Se resetea firstClicked and secondClicked
            firstClicked = null;
            secondClicked = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Si aún no se acaba el tiempo, muestra el tiempo restante 
            // y luego se resta un segundo

            // Si no, luego de parar el timer2 se muestra un mensaje
            // de que no se acabó a tiempo y se cierra el programa
            if (tiemporestante >0)
            {
                lblTiemporestante.Text=Convert.ToString(tiemporestante);
                tiemporestante--;
            }
            else
            {
                timer2.Stop();
                MessageBox.Show("No lo hiciste a tiempo");
                lblTiemporestante.Text = Convert.ToString(tiemporestante);
                Close();
            }

            
        }
    }
}
