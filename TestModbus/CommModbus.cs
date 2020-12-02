using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TestModbus
{
    class CommModbus
    {
        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int fncommModbus();

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_connect(string ip, int port);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_deconnect();

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_read_input_bits(int slaveId, int addr, int nb, byte[] dest);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_read_input_registers(int slaveId, int addr, int nb, ushort[] dest);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_read_bits(int slaveId, int addr, int nb, byte[] dest);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_read_registers(int slaveId, int addr, int nb, ushort[] dest);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_write_bits(int slaveId, int addr, int nb, byte[] src);

        [DllImport("commModbus.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int lib_modbus_write_registers(int slaveId, int addr, int nb, ushort[] src);

    }
}
