using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LendoTXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ***** Trocar "...." pelo caminho do arquivos *****


            //Exibindo texto completo            
            string text = File.ReadAllText(@"C:\....\Texto2.txt");

            label1.Text = text;


            //Exibindo texto completo por linhas
            string[] lines = File.ReadAllLines(@"C:\....\Texto1.txt");
            
            Console.WriteLine("O arquivo contem {0} linhas", lines.Length.ToString());            
            foreach (string line in lines)
            { 
               Console.WriteLine(line.Replace(" ", ","));
            }
        }
    }
}
