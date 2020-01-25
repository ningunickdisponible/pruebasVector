using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebasConVector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int[] vec = randomVector();
            int mayor = 0;
            for (int x = 0; x < vec.Length; x++)
            {
                Console.WriteLine(vec[x]);
                if (mayor < vec[x])
                {
                    mayor = vec[x];
                }
            }
            label1.Text = mayor.ToString();     
        }

        //Devuelve un vector de enteros con una cantidad de posiciones aleatorias (entre 0 y 20), lleno de numeros aleatorios (entre 0 y 50)
        public int[] randomVector()
        {
            Random random = new Random();
            int size = random.Next(0, 20);
            int[] res = new int[size];
            for (int x = 0; x < size; x++)
            {
                res[x] = random.Next(0, 50);
            }
            return res;
        }

        //Esta función fue un extra, para probar con Ivan algo.
        public int[] randomVectorFaltanteUno()
        {
            Random random = new Random();
            int faltante = random.Next(0, 100000);
            int[] res = new int[100000];
            for (int x = 0; x < 100000; x++)
            {
                if (x >= faltante) {
                    res[x] = x + 1;
                }
                else
                {
                    res[x] = x;
                }
            }
            //shuffle
            for (int t = 0; t< res.Length; t++)
            {
                int tmp = res[t];
                int r = random.Next(t, res.Length);
                res[t] = res[r];
                res[r] = tmp;
            } 
            return res;
        }


        private void BtnGauss_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int[] vecFaltanteUno = randomVectorFaltanteUno();
            int Gauss = (vecFaltanteUno.Length / 2) * (vecFaltanteUno.Length + 1);
            
            int suma = 0;
            for (int x = 0; x < vecFaltanteUno.Length; x++)
            {
                suma = suma + vecFaltanteUno[x];
            }
            Cursor.Current = Cursors.Default;
            label2.Text = (Gauss - suma).ToString();
        }
        //Esta función fue un extra, si quieren pueden tratar de entender que hice aca
        void bubbleSort(ref int[] arr)
        {
            int temp = 0;
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
        }

        //Esta función fue un extra, si quieren pueden tratar de entender que hice aca
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int[] vecFaltanteUno = randomVectorFaltanteUno();
            bubbleSort(ref vecFaltanteUno);
            Cursor.Current = Cursors.Default;
        }

        private void BtnBuscador_Click(object sender, EventArgs e)
        {
            int[] vec = randomVector();
            int indice = -1;
            int numeroingesado = int.Parse(txtNumero.Text);
            for (int x = 0; x < vec.Length; x++)
            {
                Console.WriteLine(vec[x]);
                if (numeroingesado == vec[x])
                {
                    indice = x;
                }

            }
            lblIndice.Text = indice.ToString();
        }

        private void BtnMasVeces_Click(object sender, EventArgs e)
        {
            int[] vecNumeros = new int[] { 2, 2, 4, 5, 2, 0, 8, 6, 7, 5, 6,6,6,22,22,22,22,22,22,22,22 };
            int veces = 0;
            int numeroMasRepetido = 0;
            int numeroEvaluado = 0;
            int VecesTmp = 0; //contador

            for (int x = 0; x < vecNumeros.Length; x++)
            {
                numeroEvaluado = vecNumeros[x];
                for (int y = 0; y < vecNumeros.Length; y++)
                {

                    if (numeroEvaluado == vecNumeros[y])
                    {    
                        VecesTmp = VecesTmp + 1 ;
                    }
                }
                if (VecesTmp > veces)
                {
                    veces = VecesTmp;
                    numeroMasRepetido = numeroEvaluado;
                }
                VecesTmp = 0; 
            }
            lblNumeroRepetido.Text = numeroMasRepetido.ToString();
            lblVecesQueSeRepite.Text = veces.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int contador = 0;
            int[,] matriz = new int[3,3];
            matriz[0, 0] = 1;
            matriz[1, 1] = 1;
            matriz[2, 2] = 1;
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                string fila = "";
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    
                    fila = fila + matriz[x,y] + " ";
                }
                Console.WriteLine(fila + "\n");
            }

        }
    }
}
