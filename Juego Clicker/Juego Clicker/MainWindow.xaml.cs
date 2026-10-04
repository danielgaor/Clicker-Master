using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Juego_Clicker
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int contador = 0;
        int coste = 10;
        int incremento = 1;
        int vidaJefe;
        Boolean atacarAlJefe = false;

        private void Boton_Juego(object sender, RoutedEventArgs e)
        {
            contador += incremento;
            txtClics.Text = $"LLEVAS: {contador} CLICS";
        }

        private void Boton_Mejora(object sender, RoutedEventArgs e)
        {
            if(contador >= coste)
            {
                contador -= coste;
                incremento++;
                txtClics.Text = $"LLEVAS: {contador} CLICS";
                coste = coste * 2;
                txtCadaVez.Text = $"+ {incremento} CLICS CADA VEZ";
                txtCoste.Text = $"COSTE: {coste} CLICS";
            }
            else
            {
                MessageBox.Show($"¡Aún te quedan {coste - contador} clics!");
            }
        }

        private void Boton_Jefe(object sender, RoutedEventArgs e)
        {
            if (!atacarAlJefe)
            {
                btnJuego.Visibility = Visibility.Hidden;
                btnMejora.Visibility = Visibility.Hidden;
                btnCreditos.Visibility = Visibility.Hidden;

                txtCadaVez.Visibility = Visibility.Hidden;
                txtCoste.Visibility = Visibility.Hidden;
                txtClics.Visibility = Visibility.Hidden;

                txtVidaJefe.Visibility = Visibility.Visible;

                vidaJefe = coste * 2;
                txtVidaJefe.Text = "VIDA: " + vidaJefe;
                atacarAlJefe = true;
            }
            else
            {
                if (vidaJefe > 0)
                {
                    vidaJefe -= incremento;
                    txtVidaJefe.Text = "VIDA: " + vidaJefe;
                    if(vidaJefe <= 0)
                    {
                        txtVidaJefe.Text = $"¡HAS DERROTADO AL JEFE! AQUÍ TIENES {coste * 3} CLICS DE RECOMPENSA";
                    }
                }
                else
                {
                    btnJuego.Visibility = Visibility.Visible;
                    btnMejora.Visibility = Visibility.Visible;

                    txtCadaVez.Visibility = Visibility.Visible;
                    txtCoste.Visibility = Visibility.Visible;
                    txtClics.Visibility = Visibility.Visible;

                    txtVidaJefe.Visibility = Visibility.Hidden;

                    contador += coste * 3;
                    txtClics.Text = $"LLEVAS: {contador} CLICS";
                    vidaJefe = coste * 2;
                    atacarAlJefe = false;
                }
            }
        }

        private void Boton_Creditos(object sender, RoutedEventArgs e)
        {
            btnJefe.Visibility = Visibility.Hidden;
            btnJuego.Visibility = Visibility.Hidden;
            btnMejora.Visibility = Visibility.Hidden;
            btnCreditos.Visibility = Visibility.Hidden;

            txtCadaVez.Visibility = Visibility.Hidden;
            txtClics.Visibility = Visibility.Hidden;
            txtCoste.Visibility = Visibility.Hidden;
            txtTitulo.Visibility = Visibility.Hidden;
            txtTitulo2.Visibility = Visibility.Hidden;
            txtVidaJefe.Visibility = Visibility.Hidden;

            btnVolverAlJuego.Visibility = Visibility.Visible;

            txtCreditos.Visibility = Visibility.Visible;
            txtCreditos_Copiar.Visibility = Visibility.Visible;
            txtCreditos_Copiar1.Visibility = Visibility.Visible;

        }

        private void Boton_VolverAljuego(object sender, RoutedEventArgs e)
        {
            btnJefe.Visibility = Visibility.Visible;
            btnJuego.Visibility = Visibility.Visible;
            btnMejora.Visibility = Visibility.Visible;
            btnCreditos.Visibility = Visibility.Visible;

            txtCadaVez.Visibility = Visibility.Visible;
            txtClics.Visibility = Visibility.Visible;
            txtCoste.Visibility = Visibility.Visible;
            txtTitulo.Visibility = Visibility.Visible;
            txtTitulo2.Visibility = Visibility.Visible;

            btnVolverAlJuego.Visibility = Visibility.Hidden;

            txtCreditos.Visibility = Visibility.Hidden;
            txtCreditos_Copiar.Visibility = Visibility.Hidden;
            txtCreditos_Copiar1.Visibility = Visibility.Hidden;
        }
    }
}
