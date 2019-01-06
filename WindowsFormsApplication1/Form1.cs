using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        
            chart1.Series.Clear();  // Remova todas as séries de dados existentes
            chart1.Series.Add("ºC");  // ADICIONA uma Série de dados
            chart1.Titles.Clear();
            chart1.Titles.Add("Monitorização de temperatura");


            int v_temp =0;
            string v_data = "";
            string ficheiro = "leituras.txt";
            if (File.Exists(ficheiro)== true)
              {
                StreamReader sr = File.OpenText(ficheiro);

                string linha = "";
                while ((linha = sr.ReadLine())!=null)
                {
                    string[] dr = linha.Split(';');
                    v_data = Convert.ToString(dr[1]); // traz a data   
                    string v_hora = v_data.Substring(11, 5);
                    v_temp = Convert.ToInt16(dr[2]); // traz a temp

                    chart1.Series[0].Points.AddXY(v_hora, v_temp);
                }
                sr.Close();
            }             
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcao = chartType.Text;
            switch (opcao)
            {
                case "Column": chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    break;
                case "Line": chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[0].Color = Color.Red;
                    break;
                case "Bubble":
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart1.Series[0].Color = Color.Yellow;

                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartType.Text = chartType.Items[0].ToString();
        }
    }
}
