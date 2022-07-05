using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grafico_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {            

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Selecionar .TXT";
            openFileDialog1.Filter = "Arquivo texto (*.txt)" + "All files (*.*)|*.*";

            openFileDialog1.ShowDialog();


            txtArquivos.Text = openFileDialog1.FileName;

            //Exibindo texto completo por linhas
            string[] lines = File.ReadAllLines(openFileDialog1.FileName);

            Console.WriteLine("O arquivo contem {0} linhas", lines.Length.ToString());
            int i = 0;
            char[] delimitadores = new char[] {' ', '.' };

            double[] T, X, Y;
            int totalLinha = lines.Length - 12;

            T = new double[totalLinha];
            X = new double[totalLinha];
            Y = new double[totalLinha];

            int t = 0, x = 0, y = 0, n = 0;
            int l = 0;

            foreach (string line in lines)
            {
                i++;

                if ((!line.Contains("Trajectory")) && i > 8)
                {
                  
                    string[] strings = line.Split(delimitadores);
                    
                    foreach (string s in strings){
                        
                        if(s != "")
                        {
                            if (n == 0)
                            {
                                T[t] = Convert.ToDouble(s);                                
                                t++;
                                n = 1;                               
                            }
                            else if(n == 1)
                            {
                                X[x] = Convert.ToDouble(s);                                
                                x++;
                                n = 2;                               
                            }
                            else
                            {
                                Y[y] = Convert.ToDouble(s);

                                y++;
                                n = 0;                               
                            }
                        }
                        
                    }                  
                }                    
            }
            /*
            Console.WriteLine("******************** X ******************");
            foreach (double line in X)
            {                
                Console.WriteLine(line);
            }

            Console.WriteLine("******************** Y ******************");
            foreach (double line in Y)
            {                
                Console.WriteLine(line);
            }*/

            this.chart1.Series.Clear();            
            Series series = this.chart1.Series.Add("Total Income");
            series.ChartType = SeriesChartType.Spline;

            series.BorderWidth = 1;
            
            for(int z = 0; z < X.Length; z++)
            {
                series.Points.AddXY(X[z], Y[z]);
            }
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.chart1.Titles.Add("Coordenadas");
        }
    }
}
