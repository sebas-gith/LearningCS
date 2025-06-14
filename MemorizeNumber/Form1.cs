using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace MemorizeNumber
{
    public partial class Form1 : Form
    {
        private string _number;

        private int length;

        private bool hideIsActive = true;

        private Stopwatch stopwatch = new Stopwatch();

        private System.Timers.Timer timer;


        private Dictionary<Control, Size> OriginalState = new();
        public Form1()
        {

            InitializeComponent();

            this.Text = "MemorizeNumber";
            this.Resize += Form1_Resize;
            this.SizeChanged += Form1_SizeChanged;
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                RestoreConfiguration(PanelInicio);
            }
        }

        private void SaveConfiguratoInDictionary(Control root)
        {
            foreach (Control parent in root.Controls)
            {
                OriginalState[parent] = parent.Size;

                if (parent.HasChildren)
                {
                    SaveConfiguratoInDictionary(parent);
                }
            }
            //save the root element
            OriginalState[root] = root.Size;
        }

        private void RestoreConfiguration(Control panel)
        {
            foreach (Control parent in panel.Controls)
            {

                if (OriginalState.TryGetValue(parent, out var state))
                {
                    parent.Size = state;
                }
                if (parent.HasChildren)
                {
                    RestoreConfiguration(parent);
                }
            }

            if (OriginalState.TryGetValue(panel, out var statePanel))
            {
                panel.Size = statePanel;
            }
        }

        private void Form1_SizeChanged(object? sender, EventArgs e)
        {
            SetPanelGameInTheMiddle();
            SetPanelOptionsInTheMiddle();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveConfiguratoInDictionary(PanelInicio);
            timer = new System.Timers.Timer(10); // Intervalo de 10 ms
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.SynchronizingObject = this; // Para poder actualizar controles del formulario
            SetPanelOptionsInTheMiddle();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan tiempo = stopwatch.Elapsed;
            label2.Text = string.Format("{1:00}:{2:00}.{3:000}",
                tiempo.Hours, tiempo.Minutes, tiempo.Seconds, tiempo.Milliseconds);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                this.length = Convert.ToInt32(textBox1.Text);
                NumberGenerator();
                HideNumber();
                PanelJuego.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Use a correct format", "ErrorMessage", MessageBoxButtons.OK);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelJuego.Visible = false;
        }

        private void NumberGenerator()
        {
            StringBuilder number = new();


            for (int i = 0; i < length; ++i)
            {
                Random random = new Random();
                char n = (char)(random.Next(0, 10) + 48);
                number.Append(n);
            }

            _number = number.ToString();
        }

        private void HideNumber()
        {
            StringBuilder num = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                num.Append("*");
            }

            label3.Text = num.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!hideIsActive)
            {
                hideIsActive = true;
                HideNumber();

                button3.Text = "See";
                timer.Stop();
                stopwatch.Stop();
                textBox2.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                textBox2.Text = "";
                button3.Text = "Hide";
                label3.Text = _number;
                hideIsActive = false;
                stopwatch.Start();
                timer.Start();
                textBox2.Enabled = false;
                button4.Enabled = false;

            }
        }

        private void SetPanelGameInTheMiddle()
        {
            Point pos = new Point(PanelInicio.Width / 2 - PanelImp.Width / 2, PanelInicio.Height / 2 - PanelImp.Height / 2);
            PanelImp.Location = pos;
        }

        private void RestartApp()
        {
            timer.Stop();
            stopwatch.Reset();
            label2.Text = "00:00.000";

            NumberGenerator();
            HideNumber();

            button3.Text = "See";
            hideIsActive = true;

            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RestartApp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_number == textBox2.Text)
            {
                MessageBox.Show("Congrats!!!!, You are strong, man", "Message", MessageBoxButtons.OK);
                RestartApp();
            }
        }

        private void SetPanelOptionsInTheMiddle()
        {
            Point pos = new Point(PanelInicio.Width / 2 - PanelOptions.Width / 2, PanelInicio.Height / 2 - PanelOptions.Height / 2);
            PanelOptions.Location = pos;
        }

        private void PanelOptions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelImp_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
