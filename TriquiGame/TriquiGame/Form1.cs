using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriquiGame
{
    public partial class Form1 : Form
    {
        private bool turno = true; // cuando es true es el turno de x
        private int turnoConta = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creado por Guillermo Chirinos", "Juego de Triqui V 1.0");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button) sender;

            if (turno)
                b.Text = "X";
            else
                b.Text = "O";

            turno = !turno;
            b.Enabled = false;
            turnoConta++;

            Ganador();
        }

        private void Ganador()
        {
            bool hay_ganador = false;

            // Verificacion Horizontal
            if ((A1.Text == A2.Text)&&(A2.Text == A3.Text) && (!A1.Enabled))
            {
                hay_ganador = true;
            } // End
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                hay_ganador = true;
            } // End
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                hay_ganador = true;
            } // End

            // Verificacion Vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                hay_ganador = true;
            } // End
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                hay_ganador = true;
            } // End
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                hay_ganador = true;
            } // End

            // Verificacion Diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                hay_ganador = true;
            } // End
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                hay_ganador = true;
            } // End

            if (hay_ganador)
            {
                DeshabilitarBotones();

                string _ganador = "";
                if (turno)
                {
                    _ganador = "O";
                }
                else
                {
                    _ganador = "X";
                }
                MessageBox.Show("Enhorabuena, el ganador fue: " + _ganador,"Felicidades");
            }// End if

            else
            {
                if (turnoConta == 9)
                {
                    MessageBox.Show("Hay un empate","Atencion");
                }
            }
        } // End Ganador

        private void DeshabilitarBotones()
        {
            try
            {
                foreach (Control com in Controls)
                {
                    Button b = (Button)com;
                    b.Enabled = false;
                }// End ForEach
            }
            catch
            {
            }
            
        }

        private void nuevoJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turno = true;
            turnoConta = 0;

            try
            {
                foreach (Control com in Controls)
                {
                    Button b = (Button)com;
                    b.Enabled = true;
                    b.Text = "";
                }// End ForEach
            }
            catch
            {
            }
        }
    }
}
