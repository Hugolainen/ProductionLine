using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Supervision
{
    public partial class globalSupervision : Form
    {

        // Initialise the production reports structures
        string[] prod_MnMs_report = new string[6];
        string[] prod_KitKat_report = new string[6];
        string[] prod_Milk_report = new string[6];
        string[] prod_SparkWater_report = new string[6];
        string[] prod_StillWater_report = new string[6];
        string commandMode = "average";

        public globalSupervision()
        {
            InitializeComponent();

            // Initialise the notification itemList
            listView_notifications.View = View.Details;
            listView_notifications.Columns.Add("Ack.", 50, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Desciption", 600, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Priority", 100, HorizontalAlignment.Left);
            listView_notifications.Columns.Add("Timestamp", 100, HorizontalAlignment.Left);
            generateNotification("Global screen initialised", "high");
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
        private void button1_Click(object sender, EventArgs e)
        {
            Global.swapToStartScreen();
        }

        // Is shown if User=Admin or Engineer - Swap to local screen
        private void button_goToLocal_Click(object sender, EventArgs e)
        {
            Global.swapToLocalScreen_Chocolate();
        }

        // Is shown if User=Admin or Engineer or Operator - Swap to field screen
        private void button_goToField_Click(object sender, EventArgs e)
        {
            Global.swapToFieldScreen_MnMs();
        }

        // Is called every time this screen is shown
        private void globalSupervision_Activated(object sender, EventArgs e)
        {
            label_user.Text = Global.user;
            if (Global.user == "Admin")
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.adminWhite_icon;
            else if (Global.user == "Engineer")
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.engineerWhite_icon;
            else
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.operatorWhite_icon;

            updateProdReports();
            updateCommandSection();
        }

        // Updates the content of the Command section archived values based on the selected date in the calendar
        private void monthCalendar_prod_DateSelected(object sender, DateRangeEventArgs e)
        {
            updateProdReports();
            updateCommandSection();
        }
        
        // Updates the value of the Command section based on User's parameters (time period, sum/average mode)
        void updateCommandSection()
        {
            label_MMs_PrevOrder.Text = prod_MnMs_report[0];
            label_MMs_PrevProd.Text = prod_MnMs_report[1];
            label_MMs_PrevBalance.Text = (Int32.Parse(prod_MnMs_report[1]) - Int32.Parse(prod_MnMs_report[0])).ToString();
            label_MMs_CustomerNeed.Text = prod_MnMs_report[2];
            label_MMs_ReqStatus.Text = prod_MnMs_report[4];
            label_MMs_OrderStatus.Text = prod_MnMs_report[5];
            if(Int32.Parse(label_MMs_PrevBalance.Text) < 0)
            {
                label_MMs_PrevBalance.ForeColor = Color.FromArgb(241, 90, 34);
            }
            else if(Int32.Parse(label_MMs_PrevBalance.Text) > 0)
            {
                label_MMs_PrevBalance.ForeColor = Color.FromArgb(185, 194, 31);
            }
            if(Global.prod_MnMs.getReqStatus() == "Accepted")
            {
                button_MMs_OrderSend.Enabled = false;
            }

            label_KitKat_PrevOrder.Text = prod_KitKat_report[0];
            label_KitKat_PrevProd.Text = prod_KitKat_report[1];
            label_KitKat_PrevBalance.Text = (Int32.Parse(prod_KitKat_report[1]) - Int32.Parse(prod_KitKat_report[0])).ToString();
            label_KitKat_CustomerNeed.Text = prod_KitKat_report[2];
            label_KitKat_ReqStatus.Text = prod_KitKat_report[4];
            label_KitKat_OrderStatus.Text = prod_KitKat_report[5];
            if (Int32.Parse(label_KitKat_PrevBalance.Text) < 0)
            {
                label_KitKat_PrevBalance.ForeColor = Color.FromArgb(241, 90, 34);
            }
            else if (Int32.Parse(label_KitKat_PrevBalance.Text) > 0)
            {
                label_KitKat_PrevBalance.ForeColor = Color.FromArgb(185, 194, 31);
            }
            if (Global.prod_KitKat.getReqStatus() == "Accepted")
            {
                button_KitKat_OrderSend.Enabled = false;
            }

            label_Milk_PrevOrder.Text = prod_Milk_report[0];
            label_Milk_PrevProd.Text = prod_Milk_report[1];
            label_Milk_PrevBalance.Text = (Int32.Parse(prod_Milk_report[1]) - Int32.Parse(prod_Milk_report[0])).ToString();
            label_Milk_CustomerNeed.Text = prod_Milk_report[2];
            label_Milk_ReqStatus.Text = prod_Milk_report[4];
            label_Milk_OrderStatus.Text = prod_Milk_report[5];
            if (Int32.Parse(label_Milk_PrevBalance.Text) < 0)
            {
                label_Milk_PrevBalance.ForeColor = Color.FromArgb(241, 90, 34);
            }
            else if (Int32.Parse(label_Milk_PrevBalance.Text) > 0)
            {
                label_Milk_PrevBalance.ForeColor = Color.FromArgb(185, 194, 31);
            }
            if (Global.prod_Milk.getReqStatus() == "Accepted")
            {
                button_Milk_OrderSend.Enabled = false;
            }

            label_SparkWater_PrevOrder.Text = prod_SparkWater_report[0];
            label_SparkWater_PrevProd.Text = prod_SparkWater_report[1];
            label_SparkWater_PrevBalance.Text = (Int32.Parse(prod_SparkWater_report[1]) - Int32.Parse(prod_SparkWater_report[0])).ToString();
            label_SparkWater_CustomerNeed.Text = prod_SparkWater_report[2];
            label_SparkWater_ReqStatus.Text = prod_SparkWater_report[4];
            label_SparkWater_OrderStatus.Text = prod_SparkWater_report[5];
            if (Int32.Parse(label_SparkWater_PrevBalance.Text) < 0)
            {
                label_SparkWater_PrevBalance.ForeColor = Color.FromArgb(241, 90, 34);
            }
            else if (Int32.Parse(label_SparkWater_PrevBalance.Text) > 0)
            {
                label_SparkWater_PrevBalance.ForeColor = Color.FromArgb(185, 194, 31);
            }
            if (Global.prod_SparkWater.getReqStatus() == "Accepted")
            {
                button_SparkWater_OrderSend.Enabled = false;
            }

            label_StillWater_PrevOrder.Text = prod_StillWater_report[0];
            label_StillWater_PrevProd.Text = prod_StillWater_report[1];
            label_StillWater_PrevBalance.Text = (Int32.Parse(prod_StillWater_report[1]) - Int32.Parse(prod_StillWater_report[0])).ToString();
            label_StillWater_CustomerNeed.Text = prod_StillWater_report[2];
            label_StillWater_ReqStatus.Text = prod_StillWater_report[4];
            label_StillWater_OrderStatus.Text = prod_StillWater_report[5];
            if (Int32.Parse(label_StillWater_PrevBalance.Text) < 0)
            {
                label_StillWater_PrevBalance.ForeColor = Color.FromArgb(241, 90, 34);
            }
            else if (Int32.Parse(label_StillWater_PrevBalance.Text) > 0)
            {
                label_StillWater_PrevBalance.ForeColor = Color.FromArgb(185, 194, 31);
            }
            if (Global.prod_StillWater.getReqStatus() == "Accepted")
            {
                button_StillWater_OrderSend.Enabled = false;
            }
        }

        // Updates the request status
        void updateProdReports()
        {
            DateTime startDay = monthCalendar_prod.SelectionStart;
            DateTime endDay = monthCalendar_prod.SelectionEnd;
            label_numberSelectedDay.Text = ((int)(endDay - startDay).TotalDays + 1).ToString();

            prod_MnMs_report = Global.getProdInfo(startDay, endDay, Global.prod_MnMs, commandMode);
            prod_KitKat_report = Global.getProdInfo(startDay, endDay, Global.prod_KitKat, commandMode);
            prod_Milk_report = Global.getProdInfo(startDay, endDay, Global.prod_Milk, commandMode);
            prod_SparkWater_report = Global.getProdInfo(startDay, endDay, Global.prod_SparkWater, commandMode);
            prod_StillWater_report = Global.getProdInfo(startDay, endDay, Global.prod_StillWater, commandMode);
        }

        // Updates the Command section labels
        void updateTodayProd()
        {
            prod_MnMs_report[4] = Global.prod_MnMs.getReqStatus();
            prod_MnMs_report[5] = Global.prod_MnMs.getOrderStatus();
            prod_MnMs_report[3] = Global.prod_MnMs.getOrder().ToString();
            label_MMs_ReqStatus.Text = prod_MnMs_report[4];
            label_MMs_OrderStatus.Text = prod_MnMs_report[5];

            prod_KitKat_report[4] = Global.prod_KitKat.getReqStatus();
            prod_KitKat_report[5] = Global.prod_KitKat.getOrderStatus();
            prod_KitKat_report[3] = Global.prod_KitKat.getOrder().ToString();
            label_KitKat_ReqStatus.Text = prod_KitKat_report[4];
            label_KitKat_OrderStatus.Text = prod_KitKat_report[5];

            prod_Milk_report[4] = Global.prod_Milk.getReqStatus();
            prod_Milk_report[5] = Global.prod_Milk.getOrderStatus();
            prod_Milk_report[3] = Global.prod_Milk.getOrder().ToString();
            label_Milk_ReqStatus.Text = prod_Milk_report[4];
            label_Milk_OrderStatus.Text = prod_Milk_report[5];

            prod_SparkWater_report[4] = Global.prod_SparkWater.getReqStatus();
            prod_SparkWater_report[5] = Global.prod_SparkWater.getOrderStatus();
            prod_SparkWater_report[3] = Global.prod_SparkWater.getOrder().ToString();
            label_SparkWater_ReqStatus.Text = prod_SparkWater_report[4];
            label_SparkWater_OrderStatus.Text = prod_SparkWater_report[5];

            prod_StillWater_report[4] = Global.prod_StillWater.getReqStatus();
            prod_StillWater_report[5] = Global.prod_StillWater.getOrderStatus();
            prod_StillWater_report[3] = Global.prod_StillWater.getOrder().ToString();
            label_StillWater_ReqStatus.Text = prod_StillWater_report[4];
            label_StillWater_OrderStatus.Text = prod_StillWater_report[5];
        }

        // Swap the Command section mode
        private void button_archiveMode_Click(object sender, EventArgs e)
        {
            if(button_archiveMode.Text == "Swap to sum mode archives")
            {
                button_archiveMode.Text = "Swap to average mode archives";
                commandMode = "sum";
            }
            else
            {
                button_archiveMode.Text = "Swap to sum mode archives";
                commandMode = "average";
            }
            updateProdReports();
            updateCommandSection();
        }

        // These buttons are allowing the user to send / cancel orders to the local screen
        private void button_MMs_OrderSend_Click(object sender, EventArgs e)
        {
            if (button_MMs_OrderSend.Text == "send")
            {
                if (textBox_MMs_Order.Text == "")
                {
                    MessageBox.Show("Please fill an order quantity before sending a request");
                }
                else
                {
                    Global.prod_MnMs.setOrder(Int32.Parse(textBox_MMs_Order.Text));
                    Global.prod_MnMs.setReqStatus("sent to production");
                    textBox_MMs_Order.Enabled = false;
                    button_MMs_OrderSend.Text = "cancel";
                    updateTodayProd();
                    generateNotification("MnMs order sent", "low");
                }
            }
            else
            {
                Global.prod_MnMs.setOrder(0);
                Global.prod_MnMs.setReqStatus("waiting");
                textBox_MMs_Order.Enabled = true;
                textBox_MMs_Order.Text = "";
                button_MMs_OrderSend.Text = "send";
                updateTodayProd();
                generateNotification("MnMs order canceled", "low");
            }
        }
        private void button_KitKat_OrderSend_Click(object sender, EventArgs e)
        {
            if (button_KitKat_OrderSend.Text == "send")
            {
                if (textBox_KitKat_Order.Text == "")
                {
                    MessageBox.Show("Please fill an order quantity before sending a request");
                }
                else
                {
                    Global.prod_KitKat.setOrder(Int32.Parse(textBox_KitKat_Order.Text));
                    Global.prod_KitKat.setReqStatus("sent to production");
                    textBox_KitKat_Order.Enabled = false;
                    button_KitKat_OrderSend.Text = "cancel";
                    updateTodayProd();
                    generateNotification("KitKat order sent", "low");
                }
            }
            else
            {
                Global.prod_KitKat.setOrder(0);
                Global.prod_KitKat.setReqStatus("waiting");
                textBox_KitKat_Order.Enabled = true;
                textBox_KitKat_Order.Text = "";
                button_KitKat_OrderSend.Text = "send";
                updateTodayProd();
                generateNotification("KitKat order canceld", "low");
            }
        }
        private void button_Milk_OrderSend_Click(object sender, EventArgs e)
        {
            if (button_Milk_OrderSend.Text == "send")
            {
                if (textBox_Milk_Order.Text == "")
                {
                    MessageBox.Show("Please fill an order quantity before sending a request");
                }
                else
                {
                    Global.prod_Milk.setOrder(Int32.Parse(textBox_Milk_Order.Text));
                    Global.prod_Milk.setReqStatus("sent to production");
                    textBox_Milk_Order.Enabled = false;
                    button_Milk_OrderSend.Text = "cancel";
                    updateTodayProd();
                    generateNotification("Milk order sent", "low");
                }
            }
            else
            {
                Global.prod_Milk.setOrder(0);
                Global.prod_Milk.setReqStatus("waiting");
                textBox_Milk_Order.Enabled = true;
                textBox_Milk_Order.Text = "";
                button_Milk_OrderSend.Text = "send";
                updateTodayProd();
                generateNotification("Milk order canceld", "low");
            }
        }
        private void button_SparkWater_OrderSend_Click(object sender, EventArgs e)
        {
            if (button_SparkWater_OrderSend.Text == "send")
            {
                if (textBox_SparkWater_Order.Text == "")
                {
                    MessageBox.Show("Please fill an order quantity before sending a request");
                }
                else
                {
                    Global.prod_SparkWater.setOrder(Int32.Parse(textBox_SparkWater_Order.Text));
                    Global.prod_SparkWater.setReqStatus("sent to production");
                    textBox_SparkWater_Order.Enabled = false;
                    button_SparkWater_OrderSend.Text = "cancel";
                    updateTodayProd();
                    generateNotification("Sparkling water order sent", "low");
                }
            }
            else
            {
                Global.prod_SparkWater.setOrder(0);
                Global.prod_SparkWater.setReqStatus("waiting");
                textBox_SparkWater_Order.Enabled = true;
                textBox_SparkWater_Order.Text = "";
                button_SparkWater_OrderSend.Text = "send";
                updateTodayProd();
                generateNotification("Sparkling water order canceled", "low");
            }
        }
        private void button_StillWater_OrderSend_Click(object sender, EventArgs e)
        {
            if (button_StillWater_OrderSend.Text == "send")
            {
                if (textBox_StillWater_Order.Text == "")
                {
                    MessageBox.Show("Please fill an order quantity before sending a request");
                }
                else
                {
                    Global.prod_StillWater.setOrder(Int32.Parse(textBox_StillWater_Order.Text));
                    Global.prod_StillWater.setReqStatus("sent to production");
                    textBox_StillWater_Order.Enabled = false;
                    button_StillWater_OrderSend.Text = "cancel";
                    updateTodayProd();
                    generateNotification("Still water order sent", "low");
                }
            }
            else
            {
                Global.prod_StillWater.setOrder(0);
                Global.prod_StillWater.setReqStatus("waiting");
                textBox_StillWater_Order.Enabled = true;
                textBox_StillWater_Order.Text = "";
                button_StillWater_OrderSend.Text = "send";
                updateTodayProd();
                generateNotification("Still water order canceled", "low");
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
    }
}
