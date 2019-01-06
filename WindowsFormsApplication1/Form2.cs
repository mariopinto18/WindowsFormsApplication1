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
    public partial class Form2 : Form

    {
      

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
    
            int v_temp = 0;
            int v_id = 0;
            string v_data;

            string ficheiro = "leituras.txt";
            if (File.Exists(ficheiro) == true)
            {
                StreamReader sr = File.OpenText(ficheiro);

                string linha = "";
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dr = linha.Split(';');
                    v_id = Convert.ToInt16(dr[0]); // traz o id
                    v_data = Convert.ToString(dr[1]); // traz a data
                    string v_hora = v_data.Substring(11, 5);
                    v_temp = Convert.ToInt16(dr[2]); // traz a temp

                    chart1.Series[0].Points.AddXY(v_hora, v_temp);
                }
                sr.Close();
            }

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int v_temp = 0;
            int v_id = 0;
            string v_data;

            string ficheiro = "leituras.txt";
            if (File.Exists(ficheiro) == true)
            {
                StreamReader sr = File.OpenText(ficheiro);

                string linha = "";
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dr = linha.Split(';');
                    v_id = Convert.ToInt16(dr[0]); // traz o id
                    v_data = Convert.ToString(dr[1]); // traz a data
                    string v_hora = v_data.Substring(11, 5);
                    v_temp = Convert.ToInt16(dr[2]); // traz a temp

                    chart1.Series[0].Points.AddXY(v_hora, v_temp);
                }
                sr.Close();
            }

        }
    }
}
