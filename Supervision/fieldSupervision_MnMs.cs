using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supervision
{
    public partial class fieldSupervision_MnMs : Form
    {
        public fieldSupervision_MnMs()
        {
            InitializeComponent();
            label_convoyerSpeed.Text = "Convoyer control rate : 2 ctrl / s";
            label_securityControlRate.Text = "Security control rate : 2 ctrl/s";

            // Initialise the notification itemList
            listView_notifications.View = View.Details;
            listView_notifications.Columns.Add("Ack.", 50, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Desciption", 300, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Priority", 100, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Timestamp", 100, HorizontalAlignment.Left);
            generateNotification("MnMs field screen initialised", "high");
        }

        // Generates a string containing the Hours : Minute : Secondes of it's calling time
        private string get_timestamp()
        {
            DateTime timestamp = DateTime.Now;
            int h = timestamp.Hour;
            int m = timestamp.Minute;
            int s = timestamp.Second;
            return h.ToString() + "h:" + m.ToString() + "m:" + s.ToString() + "s";
        }
        
        // Add an item to the notification itemList
        private void generateNotification(string description, string priority)
        {
            var item1 = new ListViewItem(new[] { "", description, priority, get_timestamp() });
            listView_notifications.Items.Add(item1);
        }

        // Shut down the application
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Disconnect the user and goes back to the starting screen
        private void button_disconnect_Click(object sender, EventArgs e)
        {
            Global.swapToStartScreen();
        }

        // Is shown if User=Admin - Swap to global screen
        private void button_goToGlobal_Click(object sender, EventArgs e)
        {
            Global.swapToGlobalScreen();
        }

        // Is shown if User=Admin or Engineer - Swap to local screen
        private void button_goToLocal_Click(object sender, EventArgs e)
        {
            Global.swapToLocalScreen_Chocolate();
        }

        // Is called every time this screen is shown, updates its content 
        private void fieldSupervision1_Activated(object sender, EventArgs e)
        {
            label_user.Text = Global.user;
            if (Global.user == "Admin")
            {
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.adminWhite_icon;
                button_goToGlobal.Visible = true;
                button_goToLocal.Visible = true;
            }

            else if (Global.user == "Engineer")
            {
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.engineerWhite_icon;
                button_goToGlobal.Visible = false;
                button_goToLocal.Visible = true;
            }

            else
            {
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.operatorWhite_icon;
                button_goToGlobal.Visible = false;
                button_goToLocal.Visible = false;
            }

            if(Global.prod_MnMs.getReqStatus() == "Accepted")
            {
                label_orderAmmount.Text = Global.prod_MnMs.getOrder().ToString();
            }
            else
            {
                label_orderAmmount.Text = "No accepted order yet";
            }

            if(Global.prod_MnMs.getOrderStatus() == "waiting to start")
            {
                label_localOrder.Text = "Order : Start prod";
                label_localOrder.ForeColor = Color.FromArgb(185, 194, 31);
            }
            else
            {
                label_localOrder.Text = "Order : Stop prod ";
                label_localOrder.ForeColor = Color.FromArgb(241,90,34);
            }
        }

        // Opens the MnMs counting vision control screen
        private void button_controlConvoyer1_Click(object sender, EventArgs e)
        {
            Global.showVisionControl_MnMs();
        }

        private void button_controlConvoyer2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error: This screen is not yet available \n Se référer au bouton 'Control convoyer 1' pour la Démo");
        }

        private void button_controlConvoyerX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error: This screen is not yet available \n Se référer au bouton 'Control convoyer 1' pour la Démo");
        }

        // Opens the MnMs security vision control screen
        private void button_controlSecurity_Click(object sender, EventArgs e)
        {
            Global.showVisionControl_Security();
        }

        // This button allows to start/stop the MnMs production by writting a Modbus variable on the runtime
        private void button_start_stop_prod_Click(object sender, EventArgs e)
        {
            if (button_start_stop_prod.Text == "Start production" && Global.prod_MnMs.getOrderStatus() == "waiting to start")
            {
                // Write coil address 0 à true
                Global.communicateModbus(2, 1, 0, "true");

                button_start_stop_prod.Text = "Stop production";
                pictureBox_statusConvoyer1.BackColor = Color.Green;
                pictureBox_statusConvoyer2.BackColor = Color.Green;
                pictureBox_statusConvoyerX.BackColor = Color.Green;
                pictureBox_statusConvoyerSecurity.BackColor = Color.Green;
                Global.prod_MnMs.setOrderStatus("in progress");

                //add items to ListView
                generateNotification("Production started", "Average");

                //Initialisation des chart de production
                Global.prod_MnMs.startChrono();
                chartMnMs.Series.Clear();

                chartMnMs.Series.Add("Total");
                chartMnMs.Series["Total"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Total"].Color = Color.Violet;
                chartMnMs.Series["Total"].Points.AddXY("0", Global.MnMscountingResult.get_nbTotal());

                chartMnMs.Series.Add("Blue");
                chartMnMs.Series["Blue"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Blue"].Color = Color.Blue;
                chartMnMs.Series["Blue"].Points.AddXY("0", Global.MnMscountingResult.get_nbBleu());

                chartMnMs.Series.Add("Red");
                chartMnMs.Series["Red"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Red"].Color = Color.Red;
                chartMnMs.Series["Red"].Points.AddXY("0", Global.MnMscountingResult.get_nbRouge());

                chartMnMs.Series.Add("Yellow");
                chartMnMs.Series["Yellow"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Yellow"].Color = Color.Yellow;
                chartMnMs.Series["Yellow"].Points.AddXY("0", Global.MnMscountingResult.get_nbJaune());

                chartMnMs.Series.Add("Orange");
                chartMnMs.Series["Orange"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Orange"].Color = Color.Orange;
                chartMnMs.Series["Orange"].Points.AddXY("0", Global.MnMscountingResult.get_nbOrange());

                chartMnMs.Series.Add("Brown");
                chartMnMs.Series["Brown"].ChartType = SeriesChartType.Line;
                chartMnMs.Series["Brown"].Color = Color.Brown;
                chartMnMs.Series["Brown"].Points.AddXY("0", Global.MnMscountingResult.get_nbMarron());
            }
            else if (button_start_stop_prod.Text == "Stop production")
            {
                // Write coil address 0 à false
                Global.communicateModbus(2, 1, 0, "false");

                button_start_stop_prod.Text = "Start production";
                pictureBox_statusConvoyer1.BackColor = Color.Red;
                pictureBox_statusConvoyer2.BackColor = Color.Red;
                pictureBox_statusConvoyerX.BackColor = Color.Red;
                pictureBox_statusConvoyerSecurity.BackColor = Color.Red;
                Global.prod_MnMs.setOrderStatus("waiting to start");

                //add items to ListView
                generateNotification("Production stopped", "Average");
            }
            else
                MessageBox.Show("Error : the production can't be started before receiving the correct order");
        }

        // This trackbar allows to adjust the MnMs counting control rate
        private void trackBar_convoyerSpeed_Scroll(object sender, EventArgs e)
        {
            if (trackBar_convoyerSpeed.Value < 750)
                trackBar_convoyerSpeed.Value = 500;
            else if (trackBar_convoyerSpeed.Value < 1250)
                trackBar_convoyerSpeed.Value = 1000;
            else if (trackBar_convoyerSpeed.Value < 1750)
                trackBar_convoyerSpeed.Value = 1500;
            else if (trackBar_convoyerSpeed.Value < 2250)
                trackBar_convoyerSpeed.Value = 2000;
            else if (trackBar_convoyerSpeed.Value < 2750)
                trackBar_convoyerSpeed.Value = 2500;
            else
                trackBar_convoyerSpeed.Value = 3000;

            float rate = (float)1000 / (float)trackBar_convoyerSpeed.Value;
            rate = (float)Math.Round(rate * 10f) / 10f;
            label_convoyerSpeed.Text = "Convoyer control rate : " + rate.ToString() + " ctrl / s";


            // Write Register address 6 à la valeur du trackbar
            Global.communicateModbus(3, 1, 6, (trackBar_convoyerSpeed.Value).ToString());
        }

        // This trackbar allows to adjust the security control rate
        private void trackBar_SecurityControlRate_Scroll(object sender, EventArgs e)
        {
            if (trackBar_SecurityControlRate.Value < 750)
                trackBar_SecurityControlRate.Value = 500;
            else if (trackBar_SecurityControlRate.Value < 1250)
                trackBar_SecurityControlRate.Value = 1000;
            else if (trackBar_SecurityControlRate.Value < 1750)
                trackBar_SecurityControlRate.Value = 1500;
            else if (trackBar_SecurityControlRate.Value < 2250)
                trackBar_SecurityControlRate.Value = 2000;
            else if (trackBar_SecurityControlRate.Value < 2750)
                trackBar_SecurityControlRate.Value = 2500;
            else
                trackBar_SecurityControlRate.Value = 3000;

            float rate = (float)1000 / (float)trackBar_SecurityControlRate.Value;
            rate = (float)Math.Round(rate * 10f) / 10f;
            label_securityControlRate.Text = "Security control rate : " + rate.ToString() + " ctrl / s";

            //Write Register address 7 à la valeur du trackbar
            Global.communicateModbus(3, 1, 7, (trackBar_SecurityControlRate.Value).ToString());
        }

        // This timer allows the field supervision to remain updated with the vision control screens and fonctions
        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            if(Global.prodSecurity_dangerStatus == "Warning")
            {
                pictureBox_statusConvoyer1.BackColor = Color.Green;
                pictureBox_statusConvoyer2.BackColor = Color.Green;
                pictureBox_statusConvoyerX.BackColor = Color.Green;
                Global.prod_MnMs.setOrderStatus("in progress");
                pictureBox_statusConvoyerSecurity.BackColor = Color.Orange;

                generateNotification("Security alarm : operator in warning zone", "low");
            }
            else if(Global.prodSecurity_dangerStatus == "Danger")
            {
                pictureBox_statusConvoyerSecurity.BackColor = Color.Red;
                pictureBox_statusConvoyer1.BackColor = Color.Red;
                pictureBox_statusConvoyer2.BackColor = Color.Red;
                pictureBox_statusConvoyerX.BackColor = Color.Red;
                Global.prod_MnMs.setOrderStatus("security hazard");
                generateNotification("Security alarm : operator in danger zone, production stopped", "high");
            }
            else
            {
                pictureBox_statusConvoyer1.BackColor = Color.Green;
                pictureBox_statusConvoyer2.BackColor = Color.Green;
                pictureBox_statusConvoyerX.BackColor = Color.Green;
                Global.prod_MnMs.setOrderStatus("in progress");
                pictureBox_statusConvoyerSecurity.BackColor = Color.Green;
            }
        }

        // This button allows to delete the 'checked' items in the notification itemList
        private void button_cleanNotification_Click(object sender, EventArgs e)
        {
            for (int i = listView_notifications.CheckedIndices.Count - 1; i >= 0; i--)
            {
                // To delete a checked Item from the listView
                listView_notifications.Items.RemoveAt(listView_notifications.CheckedIndices[i]);
            }
        }

        private delegate void MajChart();
        public void majChart()
        {
            TimeSpan time = Global.prod_MnMs.elapsedTime();
            string totalSec = Convert.ToInt32(time.TotalSeconds).ToString();
            if (chartMnMs.InvokeRequired)
            {
                var d = new MajChart(majChart);
                chartMnMs.Invoke(d, new object[] {  });
            }
            else
            {
                chartMnMs.Series["Total"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbTotal());
                chartMnMs.Series["Blue"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbBleu());
                chartMnMs.Series["Red"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbRouge());
                chartMnMs.Series["Orange"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbOrange());
                chartMnMs.Series["Yellow"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbJaune());
                chartMnMs.Series["Brown"].Points.AddXY(totalSec, Global.MnMscountingResult.get_nbMarron());
            }
        }

        public DataPointCollection getTotalMnMs()
        {
            if (chartMnMs.Series.IndexOf("Total") == -1)
            {
                Series data = new Series();
                return data.Points;
            }
            else
                return chartMnMs.Series["Total"].Points;
        }
    }
}
