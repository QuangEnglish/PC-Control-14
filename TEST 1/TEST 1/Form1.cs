using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;


namespace TEST_1
{
    
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort("COM3", 9600);

        bool choPhepDieuKhien = false;
        int DemSanPham = 0;

        int state = 0;
        int time = 0;

        int stateNam = 0;
        int timeNam = 0;
        public Form1()
        {
            InitializeComponent();
            float scaleX = (float)Screen.PrimaryScreen.Bounds.Width / 1920;
            float scaleY = (float)Screen.PrimaryScreen.Bounds.Height / 1080;

            this.Scale(new SizeF(scaleX, scaleY));
            // port.Open();
            port.DataReceived += Port_DataReceived;
           

            MakeRound(panelRed);
            MakeRound(panelYellow);
            MakeRound(panelGreen);

            MakeRound(panelRedNam);
            MakeRound(panelYellowNam);
            MakeRound(panelGreenNam);


        }
        
         private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
         {
             string data = port.ReadLine().Trim();

            
            this.Invoke(new Action(() =>
             {


                 if (data == "ON")
                 {
                     btnON.BackColor = Color.Lime;
                     btnOFF.BackColor = SystemColors.Control;

                 }

                 else if (data == "OFF")
                 {
                     btnOFF.BackColor = Color.Red;
                     btnON.BackColor = SystemColors.Control;

                 }
                 else if (data == "C")
                 {
                     if (choPhepDieuKhien)
                     {
                         DemSanPham++;
                         SoSanPham.Text = DemSanPham.ToString();
                     }
                     
                 }
             }));
         }
        private void btnOFF_Click(object sender, EventArgs e)
        {
            if (!choPhepDieuKhien) return;
            

                port.WriteLine("0");

            DemSanPham--;
            SoSanPham.Text = DemSanPham.ToString();


        }





        private void btnON_Click(object sender, EventArgs e)
        {
            if (!choPhepDieuKhien) return;

            port.WriteLine("1");

            DemSanPham++;
            SoSanPham.Text = DemSanPham.ToString();

        }
        private void btnSTOP_Click(object sender, EventArgs e)
        {
            choPhepDieuKhien = false;
            MessageBox.Show("Bạn có chắc muốn STOP");

            btnOFF.Enabled = false;
            btnON.Enabled = false;

            btnON.BackColor = SystemColors.Control;
            btnOFF.BackColor = SystemColors.Control;
            btnSTOP.BackColor = Color.Red;
            btnSTART.BackColor = SystemColors.Control;

            port.WriteLine("0");

        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            choPhepDieuKhien = true;
            MessageBox.Show("Trạng Thái START");

            btnOFF.Enabled = true;
            btnON.Enabled = true;
            btnSTART.BackColor = Color.Lime;
            btnSTOP.BackColor = SystemColors.Control;

            timer1.Interval = 1000;
            timer1.Start();

        }


        

        private void btnReset_Click(object sender, EventArgs e)
        {
            DemSanPham = 0;
            SoSanPham.Text = "0";
        }

        private void SoSanPham_Click(object sender, EventArgs e)
        {

        }
        private void MakeRound(Panel p)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, p.Width, p.Height);
            p.Region = new Region(path);
        }


        //Den PHia BAc
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            timeNam++;

            if (state == 0)
            {

                panelRed.BackColor = Color.Red;
                panelYellow.BackColor = Color.DarkGray;
                panelGreen.BackColor = Color.DarkGray;

                labelRed.Text = (11 - time).ToString("00");
                labelYelow.Text = "";
                labelGreen.Text = "";




                if (time == 10)
                {
                    state = 1;
                    time = 0;
                }
            }

            else if (state == 1)
            {
                panelRed.BackColor = Color.DarkGray;
                panelYellow.BackColor = Color.DarkGray;
                panelGreen.BackColor = Color.Lime;

                labelGreen.Text = (8 - time).ToString("00");
                labelRed.Text = "";
                labelYelow.Text = "";




                if (time == 7)
                {
                    state = 2;
                    time = 0;
                }
            }

            else if (state == 2)
            {
                panelRed.BackColor = Color.DarkGray;
                panelYellow.BackColor = Color.Yellow;
                panelGreen.BackColor = Color.DarkGray;

                labelYelow.Text = (4 - time).ToString("00");
                labelGreen.Text = "";
                labelRed.Text = "";

                if (time == 3)
                {
                    state = 0;
                    time = 0;
                }

            }

            if (stateNam == 0)
            {


                panelGreenNam.BackColor = Color.Lime;
                panelYellowNam.BackColor = Color.DarkGray;
                panelRedNam.BackColor = Color.DarkGray;

                labelGreenNam.Text = (8 - timeNam).ToString("00");
                labelYelowNam.Text = "";
                labelRedNam.Text = "";



                if (timeNam == 7)
                {
                    stateNam = 1;
                    timeNam = 0;
                }
            }

            else if (stateNam == 1)
            {

                panelYellowNam.BackColor = Color.Yellow;
                panelGreenNam.BackColor = Color.DarkGray;
                panelRedNam.BackColor = Color.DarkGray;

                labelYelowNam.Text = (4 - timeNam).ToString("00");
                labelGreenNam.Text = "";
                labelRedNam.Text = "";


                if (timeNam == 3)
                {
                    stateNam = 2;
                    timeNam = 0;
                }
            }

            else if (stateNam == 2)
            {
                panelRedNam.BackColor = Color.Red;
                panelYellowNam.BackColor = Color.DarkGray;
                panelGreenNam.BackColor = Color.DarkGray;

                labelRedNam.Text = (11 - timeNam).ToString("00");
                labelGreenNam.Text = "";
                labelYelowNam.Text = "";

                if (timeNam == 10)
                {
                    stateNam = 0;
                    timeNam = 0;
                }
            }
        }       

      
        private void labelGreen_Click(object sender, EventArgs e)
        {

        }

        private void labelRed_Click(object sender, EventArgs e)
        {

        }

        private void labelYelow_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelGreenNam_Click(object sender, EventArgs e)
        {

        }

        private void labelYelowNam_Click(object sender, EventArgs e)
        {

        }
    }
}
