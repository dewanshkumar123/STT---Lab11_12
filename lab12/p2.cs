using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab12p2
{
    public partial class Form1 : Form
    {
        private DateTime targetTime;
        private Random rand = new Random();

        private TextBox txtTime;
        private Button btnStart;
        private System.Windows.Forms.Timer timer1; 

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            txtTime = new TextBox();
            txtTime.Location = new Point(30, 30);
            txtTime.Size = new Size(150, 25);
            txtTime.PlaceholderText = "HH:MM:SS"; 
            this.Controls.Add(txtTime);

            btnStart = new Button();
            btnStart.Text = "Start";
            btnStart.Location = new Point(200, 30);
            btnStart.Click += btnStart_Click;
            this.Controls.Add(btnStart);

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; 
            timer1.Tick += timer1_Tick;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtTime.Text, out targetTime))
            {
                timer1.Start();
                MessageBox.Show("Alarm set! Form background will now change every second.");
            }
            else
            {
                MessageBox.Show("Invalid time format! Please enter in HH:MM:SS format.");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            string current = DateTime.Now.ToString("HH:mm:ss");
            string target = targetTime.ToString("HH:mm:ss");

            if (current == target)
            {
                timer1.Stop();
                MessageBox.Show("⏰ Alarm Time Reached!");
            }
        }
    }
}
