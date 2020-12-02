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
    public partial class localSupervision_Chocolate : Form
    {
        public localSupervision_Chocolate()
        {
            InitializeComponent();

            // Initialise the notification itemList
            listView_notifications.View = View.Details;
            listView_notifications.Columns.Add("Ack.", 50, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Desciption", 400, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Priority", 125, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Timestamp", 125, HorizontalAlignment.Left);
            generateNotification("Chocolate local screen initialised", "high");
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

        // Buttons that allows to accept or refuse an order, they contain a security level forcing the user to commit a second click
        private void button_MnMs_OrderAccept_Click(object sender, EventArgs e)
        {
            if (Global.prod_MnMs.getOrder() > 0 && Global.prod_MnMs.getReqStatus() == "sent to production")
            {
                if (button_MnMs_OrderAccept.Text == "Confirm ?")
                {
                    button_MnMs_OrderAccept.BackColor = Color.FromArgb(185, 194, 31);
                    button_MnMs_OrderAccept.Text = "Confirmed";
                    button_MnMs_OrderAccept.Enabled = false;
                    button_MnMs_OrderRefuse.Enabled = false;
                    Global.prod_MnMs.setReqStatus("Accepted");
                    generateNotification("MnMs order accepted", "low");
                    updateCommand();
                }
                if (button_MnMs_OrderAccept.Text == "Accept")
                {
                    button_MnMs_OrderAccept.Text = "Confirm ?";
                    button_MnMs_OrderRefuse.Text = "Refuse";
                }
            }
            else
                MessageBox.Show("Error : No order received");
        }
        private void button_KitKat_OrderAccept_Click(object sender, EventArgs e)
        {
            if (Global.prod_KitKat.getOrder() > 0 && Global.prod_KitKat.getReqStatus() == "sent to production")
            {
                if (button_KitKat_OrderAccept.Text == "Confirm ?")
                {
                    button_KitKat_OrderAccept.BackColor = Color.FromArgb(185, 194, 31);
                    button_KitKat_OrderAccept.Text = "Confirmed";
                    button_KitKat_OrderAccept.Enabled = false;
                    button_KitKat_OrderRefuse.Enabled = false;
                    Global.prod_KitKat.setReqStatus("Accepted");
                    generateNotification("KitKat order accepted", "low");
                    updateCommand();
                }
                if (button_KitKat_OrderAccept.Text == "Accept")
                {
                    button_KitKat_OrderAccept.Text = "Confirm ?";
                    button_KitKat_OrderRefuse.Text = "Refuse";
                }
            }
            else
                MessageBox.Show("Error : No order received");
        }
        private void button_MnMs_OrderRefuse_Click(object sender, EventArgs e)
        {
            if (Global.prod_MnMs.getOrder() > 0 && Global.prod_MnMs.getReqStatus() == "sent to production")
            {
                if (button_MnMs_OrderRefuse.Text == "Confirm ?")
                {
                    button_MnMs_OrderRefuse.Text = "Confirmed";
                    button_MnMs_OrderRefuse.BackColor = Color.FromArgb(241, 90, 34);
                    button_MnMs_OrderAccept.Enabled = false;
                    button_MnMs_OrderRefuse.Enabled = false;
                    Global.prod_MnMs.setReqStatus("Refused");
                    generateNotification("MnMs order refused", "low");
                    updateCommand();
                }
                if (button_MnMs_OrderRefuse.Text == "Refuse")
                {
                    button_MnMs_OrderRefuse.Text = "Confirm ?";
                    button_MnMs_OrderAccept.Text = "Accept";
                }
              
            }
            else
                MessageBox.Show("Error : No order received");
        }
        private void button_KitKat_OrderRefuse_Click(object sender, EventArgs e)
        {
            if (Global.prod_KitKat.getOrder() > 0 && Global.prod_KitKat.getReqStatus() == "sent to production")
            {
                if (button_KitKat_OrderRefuse.Text == "Confirm ?")
                {
                    button_KitKat_OrderRefuse.Text = "Confirmed";
                    button_KitKat_OrderRefuse.BackColor = Color.FromArgb(241, 90, 34);
                    button_KitKat_OrderAccept.Enabled = false;
                    button_KitKat_OrderRefuse.Enabled = false;
                    Global.prod_KitKat.setReqStatus("Refused");
                    generateNotification("KitKat order refused", "low");
                    updateCommand();
                }
                if (button_KitKat_OrderRefuse.Text == "Refuse")
                {
                    button_KitKat_OrderRefuse.Text = "Confirm ?";
                    button_KitKat_OrderAccept.Text = "Accept";
                }
            }
            else
                MessageBox.Show("Error : No order received");
        }

        // Buttons that are modifying the start/stop order sent to the production lines (AKA field screens)
        private void button_generalStart_Click(object sender, EventArgs e)
        {
            if (Global.prod_MnMs.getReqStatus() == "Accepted")
            {
                Global.prod_MnMs.setOrderStatus("waiting to start");
                button_lineMnMs_start.Text = "Stop";
                generateNotification("MnMs START order sent to production", "low");
                updateCommand();
            }
            else
                MessageBox.Show("Error : Need an Accepted order to start MnMs production");

            if (Global.prod_KitKat.getReqStatus() == "Accepted")
            {
                Global.prod_KitKat.setOrderStatus("in progress");
                button_lineKitKat_start.Text = "Stop";
                generateNotification("Kitkat START order sent to production", "low");
                updateCommand();
            }
            else
                MessageBox.Show("Error : Need an Accepted order to start KitKat production");

            updateLineStatus();
        }
        private void button_generalStop_Click(object sender, EventArgs e)
        {
            Global.prod_MnMs.setOrderStatus("waiting to stop");
            button_lineMnMs_start.Text = "Start";
            generateNotification("MnMs STOP order sent to production", "low");

            Global.prod_KitKat.setOrderStatus("stoped");
            button_lineKitKat_start.Text = "Start";
            generateNotification("KitKat STOP order sent to production", "low");

            updateCommand();
            updateLineStatus();
        }
        private void button_lineMnMs_start_Click(object sender, EventArgs e)
        {
            if (Global.prod_MnMs.getReqStatus() == "Accepted")
            {
                if (button_lineMnMs_start.Text == "Start")
                {
                    Global.prod_MnMs.setOrderStatus("waiting to start");
                    button_lineMnMs_start.Text = "Stop";
                    generateNotification("MnMs START order sent to production", "low");
                }
                else
                {
                    Global.prod_MnMs.setOrderStatus("waiting to stop");
                    button_lineMnMs_start.Text = "Start";
                    generateNotification("MnMs STOP order sent to production", "low");
                }
                updateCommand();
                updateLineStatus();
            }
            else
                MessageBox.Show("Error : Need an Accepted order to start production");
        }
        private void button_lineKitKat_Start_Click(object sender, EventArgs e)
        {
            if (Global.prod_KitKat.getReqStatus() == "Accepted")
            {
                if (button_lineKitKat_start.Text == "Start")
                {
                    Global.prod_KitKat.setOrderStatus("in progress");
                    button_lineKitKat_start.Text = "Stop";
                    generateNotification("KitKat START order sent to production", "low");
                }
                else
                {
                    Global.prod_KitKat.setOrderStatus("stoped");
                    button_lineKitKat_start.Text = "Start";
                    generateNotification("KitKat START order sent to production", "low");
                }
                updateCommand();
                updateLineStatus();
            }
            else
                MessageBox.Show("Error : Need an Accepted order to start production");
        }

        // Swap to MnMs field screen
        private void button_lineMnMs_accessField_Click(object sender, EventArgs e)
        {
            Global.swapToFieldScreen_MnMs();
        }

        // If there was one - Swaped to KitKat field screen
        private void button_lineKitKat_accessField_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error : This screen is not yet available \n Cet écran n'a pas été développé");
        }

        // Called every time this screen is shown
        private void localSupervision_Chocolate_Activated(object sender, EventArgs e)
        {
            label_user.Text = Global.user;
            if (Global.user == "Admin")
            {
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.adminWhite_icon;
                button_goToGlobal.Visible = true;
            }
            else if (Global.user == "Engineer")
            {
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.engineerWhite_icon;
                button_goToGlobal.Visible = false;
            }

            else
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.operatorWhite_icon;

            initCommand();

            majCharts();
        }

        // Updates the Order/Command section values
        void updateCommand()
        {
            if (Global.prod_MnMs.getReqStatus() == "sent to production")
            {
                label_MnMs_ReqStatus.Text = "Waiting for Acq";
            }
            else
            {
                label_MnMs_ReqStatus.Text = Global.prod_MnMs.getReqStatus();
            }
            label_MnMs_OrderStatus.Text = Global.prod_MnMs.getOrderStatus();

            if (Global.prod_KitKat.getReqStatus() == "sent to production" || Global.prod_KitKat.getReqStatus() == "waiting")
            {
                label_KitKat_ReqStatus.Text = "Waiting for Acq";
            }
            else
            {
                label_KitKat_ReqStatus.Text = Global.prod_KitKat.getReqStatus();
            }
            label_KitKat_OrderStatus.Text = Global.prod_KitKat.getOrderStatus();
        }

        // Initialises the Order/Command section values
        void initCommand()
        {
            label_MnMs_Order.Text = Global.prod_MnMs.getOrder().ToString();
            label_MnMs_OrderStatus.Text = Global.prod_MnMs.getOrderStatus();
            if (Global.prod_MnMs.getReqStatus() == "sent to production" || Global.prod_MnMs.getReqStatus() == "waiting")
            {
                if(Global.prod_MnMs.getReqStatus() == "sent to production")
                {
                    label_MnMs_ReqStatus.Text = "Waiting for Acq";
                }
                else
                {
                    label_MnMs_ReqStatus.Text = "Waiting";
                }
                button_MnMs_OrderAccept.Text = "Accept";
                button_MnMs_OrderAccept.Enabled = true;
                button_MnMs_OrderAccept.BackColor = Color.LightGray;
                button_MnMs_OrderRefuse.Text = "Refuse";
                button_MnMs_OrderRefuse.Enabled = true;
                button_MnMs_OrderRefuse.BackColor = Color.LightGray;
            }
            else
            {
                label_MnMs_ReqStatus.Text = Global.prod_MnMs.getReqStatus();
            }

            label_KitKat_Order.Text = Global.prod_KitKat.getOrder().ToString();
            label_KitKat_OrderStatus.Text = Global.prod_KitKat.getOrderStatus();
            if (Global.prod_KitKat.getReqStatus() == "sent to production" || Global.prod_KitKat.getReqStatus() == "waiting")
            {
                if(Global.prod_KitKat.getReqStatus() == "sent to production")
                {
                    label_KitKat_ReqStatus.Text = "Waiting for Acq";
                }
                else
                {
                    label_KitKat_ReqStatus.Text = "Waiting";
                }
                button_KitKat_OrderAccept.Text = "Accept";
                button_KitKat_OrderAccept.Enabled = true;
                button_KitKat_OrderAccept.BackColor = Color.LightGray;
                button_KitKat_OrderRefuse.Text = "Refuse";
                button_KitKat_OrderRefuse.Enabled = true;
                button_KitKat_OrderRefuse.BackColor = Color.LightGray;
            }
            else
            {
                label_KitKat_ReqStatus.Text = Global.prod_KitKat.getReqStatus();
            }
           
            updateLineStatus();
        }

        // Updates the production section values
        void updateLineStatus()
        {
            if (Global.prod_MnMs.getOrderStatus() == "in progress")
            {
                label_lineMnMs.Text = "running";
                label_lineMnMs.BackColor = Color.FromArgb(185, 194, 31);
            }
            else
            {
                label_lineMnMs.Text = "not running";
                label_lineMnMs.BackColor = Color.FromArgb(200, 200, 200);
            }

            if (Global.prod_KitKat.getOrderStatus() == "in progress")
            {
                label_lineKitKat.Text = "running";
                label_lineKitKat.BackColor = Color.FromArgb(185, 194, 31);
            }
            else
            {
                label_lineKitKat.Text = "not running";
                label_lineKitKat.BackColor = Color.FromArgb(200, 200, 200);
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

        private void timer_realTimerUpdate_Tick(object sender, EventArgs e)
        {
            majCharts();
        }

        private void majCharts()
        {
            if(!timer_realTimerUpdate.Enabled)
            {
                timer_realTimerUpdate.Interval = 5000;
                timer_realTimerUpdate.Start();
            }

            chartChocolate.Series["MnMs"].Points.Clear();
            DataPointCollection data = Global.fieldScreen_MnMs.getTotalMnMs();
            foreach(DataPoint p in data)
            {
                chartChocolate.Series["MnMs"].Points.Add(p);
            }
        }
    }
}
