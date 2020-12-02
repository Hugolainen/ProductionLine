using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using System.Diagnostics;

namespace Supervision
{
    public partial class startingScreen : Form
    {
        public startingScreen()
        {
            InitializeComponent();
            button_goToGlobalScreen.Visible = false;
            button_goToLocalScreen.Visible = false;
            button_goToFieldScreen.Visible = false;
            button_disconnect.Enabled = false;
            textBox_username.Enabled = true;
            textBox_password.Enabled = true;
            button_connect.Enabled = true;
            pictureBox_globalScreen.Visible = false;
            pictureBox_fieldScreen1.Visible = false;
            pictureBox_fieldScreen2.Visible = false;
            pictureBox_localScreen1.Visible = false;
            pictureBox_localScreen2.Visible = false;
            pictureBox_User.BackgroundImage = Supervision.Properties.Resources.noOneConnected_icon;

            Global.startScreen = this;
            /*
            Global.globalScreen = new globalSupervision();
            Global.fieldScreen_MnMs = new fieldSupervision_MnMs();
            Global.localScreen_chocolate = new localSupervision_Chocolate();
            Global.visionControl_Screen_MnMs = new visionControl_MnMs();
            Global.visionControl_Screen_Security = new visionControl_Security();
            */
        }

        private void button_goToGlobaleScreen_Click(object sender, EventArgs e)
        {
            Global.swapToGlobalScreen();
            this.Hide();
        }

        private void button_goToLocalScreen_Click(object sender, EventArgs e)
        {
            Global.swapToLocalScreen_Chocolate();
            this.Hide();
        }

        private void button_goToFieldScreen_Click(object sender, EventArgs e)
        {
            Global.swapToFieldScreen_MnMs();
            this.Hide();
        }

        // COnnect to a specific User depending on the User/Password combinaision
        private void button_connect_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text != "admin" && textBox_username.Text != "engineer" && textBox_username.Text != "operator")
            {
                MessageBox.Show("Username doesn't exist, please try again");
            }
            else
            {
                if (textBox_username.Text == "admin")
                    if (textBox_password.Text == "admin")
                    {
                        button_goToGlobalScreen.Visible = true;
                        button_goToLocalScreen.Visible = true;
                        button_goToFieldScreen.Visible = true;
                        pictureBox_User.BackgroundImage = Supervision.Properties.Resources.admin_icon;
                        textBox_username.Enabled = false;
                        textBox_password.Enabled = false;
                        Global.user = "Admin";
                        button_disconnect.Enabled = true;
                        button_connect.Enabled = false;
                        pictureBox_globalScreen.Visible = true;
                        pictureBox_fieldScreen1.Visible = true;
                        pictureBox_fieldScreen2.Visible = true;
                        pictureBox_localScreen1.Visible = true;
                        pictureBox_localScreen2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Password incorrect for user 'admin', please try again");
                    }

                if (textBox_username.Text == "engineer")
                    if (textBox_password.Text == "engineer")
                    {
                        button_goToGlobalScreen.Visible = false;
                        button_goToLocalScreen.Visible = true;
                        button_goToFieldScreen.Visible = true;
                        pictureBox_User.BackgroundImage = Supervision.Properties.Resources.engineer_icon;
                        textBox_username.Enabled = false;
                        textBox_password.Enabled = false;
                        Global.user = "Engineer";
                        button_disconnect.Enabled = true;
                        button_connect.Enabled = false;
                        pictureBox_fieldScreen1.Visible = true;
                        pictureBox_fieldScreen2.Visible = true;
                        pictureBox_localScreen1.Visible = true;
                        pictureBox_localScreen2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Password incorrect for user 'engineer', please try again");
                    }

                if (textBox_username.Text == "operator")
                    if (textBox_password.Text == "operator")
                    {
                        button_goToGlobalScreen.Visible = false;
                        button_goToLocalScreen.Visible = false;
                        button_goToFieldScreen.Visible = true;
                        pictureBox_User.BackgroundImage = Supervision.Properties.Resources.operator_icon;
                        textBox_username.Enabled = false;
                        textBox_password.Enabled = false;
                        Global.user = "Operator";
                        button_disconnect.Enabled = true;
                        button_connect.Enabled = false;
                        pictureBox_fieldScreen1.Visible = true;
                        pictureBox_fieldScreen2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Password incorrect for user 'operator', please try again");
                    }
            }
            label_user.Text = Global.user;
            textBox_password.Text = "";
        }

        // Disconnect the User
        private void button_disconnect_Click(object sender, EventArgs e)
        {
            pictureBox_User.BackgroundImage = Supervision.Properties.Resources.noOneConnected_icon;
            button_goToGlobalScreen.Visible = false;
            button_goToLocalScreen.Visible = false;
            button_goToFieldScreen.Visible = false;
            textBox_password.Enabled = true;
            textBox_username.Enabled = true;
            Global.user = "No one connected";
            label_user.Text = Global.user;
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            pictureBox_globalScreen.Visible = false;
            pictureBox_fieldScreen1.Visible = false;
            pictureBox_fieldScreen2.Visible = false;
            pictureBox_localScreen1.Visible = false;
            pictureBox_localScreen2.Visible = false;
        }

        // Shut down the application
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void startingScreen_Activated(object sender, EventArgs e)
        {
            if (Global.modbusConnection_status)
            {
                textBox_connectModbus_IP.Visible = false;
                textBox_connectModbus_Port.Visible = false;
                button_connectModbus.Visible = false;
                label_ModbusIP.Text = "IP : " + Global.modbusIP;
                label_ModbusPort.Text = "Port : " + Global.modbusPort.ToString();
                label_ModbusIP.Visible = true;
                label_ModbusPort.Visible = true;
                label_rtInfo.Visible = true;

                textBox_username.Enabled = true;
                textBox_password.Enabled = true;
                button_connect.Enabled = true;
            }
            else
            {
                textBox_connectModbus_IP.Visible = true;
                textBox_connectModbus_Port.Visible = true;
                button_connectModbus.Visible = true;
                label_ModbusIP.Visible = false;
                label_ModbusPort.Visible = false;
                label_rtInfo.Visible = false;

                textBox_username.Enabled = false;
                textBox_password.Enabled = false;
                button_connect.Enabled = false;
            }

            button_disconnect.Enabled = false;
            textBox_password.Text = "";
            textBox_username.Text = "";
            label_user.Text = Global.user;
            pictureBox_User.BackgroundImage = Supervision.Properties.Resources.noOneConnected_icon;
            button_goToFieldScreen.Visible = false;
            button_goToGlobalScreen.Visible = false;
            button_goToLocalScreen.Visible = false;
            pictureBox_globalScreen.Visible = false;
            pictureBox_fieldScreen1.Visible = false;
            pictureBox_fieldScreen2.Visible = false;
            pictureBox_localScreen1.Visible = false;
            pictureBox_localScreen2.Visible = false;

        }

        private void startingScreen_Shown(object sender, EventArgs e)
        {
            Global.prod_MnMs = Global.initArchives("MnMs");
            Global.prod_KitKat = Global.initArchives("KitKat");
            Global.prod_Milk = Global.initArchives("Milk");
            Global.prod_SparkWater = Global.initArchives("SparkWater");
            Global.prod_StillWater = Global.initArchives("StillWater");
        }

        private void button_connectModbus_Click(object sender, EventArgs e)
        {
            Global.modbusIP = textBox_connectModbus_IP.Text;
            Global.modbusPort = Int32.Parse(textBox_connectModbus_Port.Text);

            bool resConnect;
            resConnect = Global.connectModbus(Global.modbusIP, Global.modbusPort.ToString());

            if (resConnect)
            {
                textBox_connectModbus_IP.Visible = false;
                textBox_connectModbus_Port.Visible = false;
                button_connectModbus.Visible = false;
                label_ModbusIP.Text = "IP : " + Global.modbusIP;
                label_ModbusPort.Text = "Port : " + Global.modbusPort.ToString();
                label_ModbusIP.Visible = true;
                label_ModbusPort.Visible = true;
                label_rtInfo.Visible = true;

                textBox_username.Enabled = true;
                textBox_password.Enabled = true;
                button_connect.Enabled = true;

                button_disconnect.Enabled = false;
                textBox_password.Text = "";
                textBox_username.Text = "";
                label_user.Text = Global.user;
                pictureBox_User.BackgroundImage = Supervision.Properties.Resources.noOneConnected_icon;
                button_goToFieldScreen.Visible = false;
                button_goToGlobalScreen.Visible = false;
                button_goToLocalScreen.Visible = false;
                pictureBox_globalScreen.Visible = false;
                pictureBox_fieldScreen1.Visible = false;
                pictureBox_fieldScreen2.Visible = false;
                pictureBox_localScreen1.Visible = false;
                pictureBox_localScreen2.Visible = false;
            }
        }
    }
}
