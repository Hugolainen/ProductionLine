using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Supervision
{
    public static class Global
    {
        // Modbus connection
        public static bool modbusConnection_status = false;
        public static string modbusIP;
        public static int modbusPort;

        // User management variable
        public static string user = "No one connected";

        // Variable used for the showing of the vision control screens when using the fiel screen
        public static bool visionControlScreen_status = false;

        // MnMs production security alarm 
        public static string prodSecurity_dangerStatus = "OK";

        // MnMs production report
        public static MnMs_stats MnMscountingResult = new MnMs_stats();

        // Supervision screens
        public static localSupervision_Chocolate localScreen_chocolate = new localSupervision_Chocolate();
        public static globalSupervision globalScreen = new globalSupervision();
        public static fieldSupervision_MnMs fieldScreen_MnMs = new fieldSupervision_MnMs();
        public static startingScreen startScreen;
        public static visionControl_MnMs visionControl_Screen_MnMs = new visionControl_MnMs();
        public static visionControl_Security visionControl_Screen_Security = new visionControl_Security();


        // Update of the MnMs production
        public static void update_MnMs_stats(int total, int red, int orange, int blue, int yellow, int brown)
        {
            MnMscountingResult.majSums(total, orange, red, brown, blue, yellow);
            fieldScreen_MnMs.majChart();
        }

        // Modbus communication
        public static bool connectModbus(string IP, string Port)
        {
            int result;
            result = WrapperModbus.lib_modbus_connect(IP, Int16.Parse(Port));
            if (result == 0)
            {
                Global.modbusConnection_status = true;
                MessageBox.Show("Modbus communication with the runtime OK");
                return true;
            }
            else
            {
                MessageBox.Show("Modbus communication failed to connect");
                return false;
            }

        }

        public static bool disconnectModbus(string IP, string Port)
        {
            int result;
            result  = WrapperModbus.lib_modbus_deconnect();
            if(result == 0)
            {
                Global.modbusConnection_status = false;
                MessageBox.Show("Modbus communication disconnected");
                return true;
            }
            else
            {
                MessageBox.Show("Failed to disconnect");
                return false;
            }
        }

        public static bool communicateModbus(int comType, int slaveID, int addr, string value)
        {
            // 1 - Read coil | 2 - Write coil | 3 - Write Register
            switch (comType)
            {
                case 1:
                    {
                        byte[] dest = new byte[1] { 0 };
                        WrapperModbus.lib_modbus_read_bits(slaveID, addr, 1, dest);
                        if (dest[0] == 1)
                            return true;
                        else
                            return false;
                    }
                case 2:
                    {
                        byte[] dest = new byte[1] { 0 };
                        if (value == "true")
                            dest[0] = 1;
                        else
                            dest[0] = 0;

                        WrapperModbus.lib_modbus_write_bits(slaveID, addr, 1, dest);
                        return true;
                    }
                case 3:
                    {
                        ushort[] dest = new ushort[1] { 0 };
                        dest[0] = ushort.Parse(value);

                        WrapperModbus.lib_modbus_write_registers(slaveID, addr, 1, dest);
                        return true;
                    }
                default:
                    MessageBox.Show("Error : Modbus fonction miss-used");
                    return false;
            }
        }


        // Naviagtion functions
        public static void showVisionControl_Security()
        {
            if (visionControlScreen_status == false)
            {
                fieldScreen_MnMs.Location = new Point(fieldScreen_MnMs.Left - 230, fieldScreen_MnMs.Top);
                visionControl_Screen_Security.Show();
                visionControl_Screen_Security.Location = new Point(fieldScreen_MnMs.Right - 10, fieldScreen_MnMs.Top);
                visionControlScreen_status = true;
            }
            else
            {
                visionControl_Screen_Security.Show();
                visionControl_Screen_Security.Location = new Point(fieldScreen_MnMs.Right - 10, fieldScreen_MnMs.Top);
                visionControl_Screen_MnMs.Hide();
            }
        }
        public static void closeVisionControl_Security()
        {
            fieldScreen_MnMs.Location = new Point(fieldScreen_MnMs.Left + 230, fieldScreen_MnMs.Top);
            visionControl_Screen_Security.Hide();
            visionControlScreen_status = false;
        }
        public static void showVisionControl_MnMs()
        {
            if(visionControlScreen_status == false)
            {
                fieldScreen_MnMs.Location = new Point(fieldScreen_MnMs.Left - 230, fieldScreen_MnMs.Top);
                visionControl_Screen_MnMs.Show();
                visionControl_Screen_MnMs.Location = new Point(fieldScreen_MnMs.Right - 10, fieldScreen_MnMs.Top);
                visionControlScreen_status = true;
            }
            else
            {
                visionControl_Screen_MnMs.Show();
                visionControl_Screen_MnMs.Location = new Point(fieldScreen_MnMs.Right - 10, fieldScreen_MnMs.Top);
                visionControl_Screen_Security.Hide();
            }
        }
        public static void closeVisionControl_MnMs()
        {
            fieldScreen_MnMs.Location = new Point(fieldScreen_MnMs.Left + 230, fieldScreen_MnMs.Top);
            visionControl_Screen_MnMs.Hide();
            visionControlScreen_status = false;
        }
        public static void swapToStartScreen()
        {
            user = "No one connected";
            startScreen.Show();
            globalScreen.Hide();
            localScreen_chocolate.Hide();
            fieldScreen_MnMs.Hide();
            visionControl_Screen_MnMs.Hide();
            visionControl_Screen_Security.Hide();
            visionControl_Screen_MnMs.Hide();
            visionControl_Screen_Security.Hide();
        }
        public static void swapToLocalScreen_Chocolate()
        {
            localScreen_chocolate.Show();
            globalScreen.Hide();
            fieldScreen_MnMs.Hide();
            startScreen.Hide();
            visionControl_Screen_MnMs.Hide();
            visionControl_Screen_Security.Hide();
        }
        public static void swapToGlobalScreen()
        {
            globalScreen.Show();
            localScreen_chocolate.Hide();
            fieldScreen_MnMs.Hide();
            startScreen.Hide();
            visionControl_Screen_MnMs.Hide();
            visionControl_Screen_Security.Hide();
        }
        public static void swapToFieldScreen_MnMs()
        {
            fieldScreen_MnMs.Show();
            globalScreen.Hide();
            localScreen_chocolate.Hide();
            startScreen.Hide();
            visionControl_Screen_MnMs.Hide();
            visionControl_Screen_Security.Hide();
        }

        // Production archives initialisation
        public static Production prod_MnMs = new Production("");
        public static Production prod_KitKat = new Production("");
        public static Production prod_Milk = new Production("");
        public static Production prod_SparkWater = new Production("");
        public static Production prod_StillWater = new Production("");

        // Production archive values generation
        public static Production initArchives(string prodType)
        {
            Production prod = new Production(prodType);
            return prod;
        }

        // Read a specific production archive values on a defined period of time
        public static string[] getProdInfo(DateTime startDay, DateTime endDay, Production prod, string type)
        {
            string[] res = new string[6];
            int indiceRef = (int)(startDay - new DateTime(2020, 4, 1)).TotalDays;
            int diffDay = (int)(endDay - startDay).TotalDays + 1;
            int sumOrders = 0, sumProds = 0;

            if (diffDay > 1)
            {
                for (int i = indiceRef; i < indiceRef + diffDay; i++)
                {
                    sumOrders = sumOrders + prod.getPrevOrder(i);
                    sumProds = sumProds + prod.getPrevProds(i);
                }
                if(type == "average")
                {
                    res[0] = (sumOrders / diffDay).ToString();
                    res[1] = (sumProds / diffDay).ToString();
                }
                else
                {
                    res[0] = sumOrders.ToString();
                    res[1] = sumProds.ToString();
                }
            }
            else
            {
                res[0] = prod.getPrevOrder(indiceRef).ToString();
                res[1] = prod.getPrevProds(indiceRef).ToString();
            }
            res[2] = prod.getCustomerNeed().ToString();
            res[3] = prod.getOrder().ToString();
            res[4] = prod.getReqStatus();
            res[5] = prod.getOrderStatus();

            return res;
        }
    }

    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new startingScreen());
        }
    }
}
