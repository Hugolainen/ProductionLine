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

namespace TestModbus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            int result;
            if (btConnect.Text == "Connexion")
            {
                result = CommModbus.lib_modbus_connect("127.0.0.1", 502);
                tBoxLog.AppendText("Résultat connexion : " + Convert.ToString(result) + Environment.NewLine);
                btConnect.Text = "Déconnexion";
            }
            else
            {
                result = CommModbus.lib_modbus_deconnect();
                tBoxLog.AppendText("Résultat déconnexion : " + Convert.ToString(result) + Environment.NewLine);
                btConnect.Text = "Connexion";
            }
        }

        private void btReadInputBits_Click(object sender, EventArgs e)
        {
            int result;
            byte[] dest = new byte[4] { 0, 0, 0, 0 };
            result = CommModbus.lib_modbus_read_input_bits(1, 0, 4, dest);

            tBoxLog.AppendText("Résultat lecture input bits : " + Convert.ToString(result) + " => ");
            for(int i = 0; i < 4; i++)
            {
                tBoxLog.AppendText(dest[i] == 1 ? "TRUE " : "FALSE ");
            }
            tBoxLog.AppendText(Environment.NewLine);
        }

        private void btReadInputRegisters_Click(object sender, EventArgs e)
        {
            int result;
            ushort[] dest = new ushort[2] { 0, 0 };
            result = CommModbus.lib_modbus_read_input_registers(1, 4, 2, dest);

            tBoxLog.AppendText("Résultat lecture input registers : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(Convert.ToString(dest[i]) + " ");
            }
            tBoxLog.AppendText(Environment.NewLine);
        }

        private void btReadCoils_Click(object sender, EventArgs e)
        {
            int result;
            byte[] dest = new byte[4] { 0, 0, 0, 0 };
            result = CommModbus.lib_modbus_read_bits(1, 6, 4, dest);

            tBoxLog.AppendText("Résultat lecture coils : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 4; i++)
            {
                tBoxLog.AppendText(dest[i] == 1 ? "TRUE " : "FALSE ");
            }
            tBoxLog.AppendText(Environment.NewLine);
        }

        private void btReadHoldingRegisters_Click(object sender, EventArgs e)
        {
            int result;
            ushort[] dest = new ushort[2] { 0, 0 };
            result = CommModbus.lib_modbus_read_registers(1, 10, 2, dest);

            tBoxLog.AppendText("Résultat lecture holding registers : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(Convert.ToString(dest[i]) + " ");
            }
            tBoxLog.AppendText(Environment.NewLine);
        }

        private void btWriteCoils_Click(object sender, EventArgs e)
        {
            int result;
            byte[] dest = new byte[2] { 0, 0 };
            

            tBoxLog.AppendText("Résultat écriture coils : " + Environment.NewLine);

            result = CommModbus.lib_modbus_read_bits(1, 12, 2, dest);
            tBoxLog.AppendText("    Avant : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(dest[i] == 1 ? "TRUE " : "FALSE ");
            }
            tBoxLog.AppendText(Environment.NewLine);

            dest[0] = 0;
            dest[1] = 1;
            result = CommModbus.lib_modbus_write_bits(1, 12, 2, dest);

            result = CommModbus.lib_modbus_read_bits(1, 12, 2, dest);
            tBoxLog.AppendText("    Après : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(dest[i] == 1 ? "TRUE " : "FALSE ");
            }
            tBoxLog.AppendText(Environment.NewLine);

            Thread.Sleep(1000);
            dest[0] = 0;
            dest[1] = 0;
            result = CommModbus.lib_modbus_write_bits(1, 12, 2, dest);
        }

        private void btWriteRegisters_Click(object sender, EventArgs e)
        {
            int result;
            ushort[] dest = new ushort[2] { 0, 0 };
            
            tBoxLog.AppendText("Résultat écriture registers : " + Environment.NewLine);

            result = CommModbus.lib_modbus_read_registers(1, 14, 2, dest);
            tBoxLog.AppendText("    Avant : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(Convert.ToString(dest[i]) + " ");
            }
            tBoxLog.AppendText(Environment.NewLine);

            dest[0] = 42;
            dest[1] = 50;
            result = CommModbus.lib_modbus_write_registers(1, 14, 2, dest);

            result = CommModbus.lib_modbus_read_registers(1, 14, 2, dest);
            tBoxLog.AppendText("    Après : " + Convert.ToString(result) + " => ");
            for (int i = 0; i < 2; i++)
            {
                tBoxLog.AppendText(Convert.ToString(dest[i]) + " ");
            }
            tBoxLog.AppendText(Environment.NewLine);

            Thread.Sleep(1000);
            dest[0] = 0;
            dest[1] = 255;
            result = CommModbus.lib_modbus_write_registers(1, 14, 2, dest);
        }
    }
}
