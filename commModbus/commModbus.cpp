// commModbus.cpp : Définit les fonctions exportées de la DLL.
//

#include "pch.h"
#include "framework.h"
#include "commModbus.h"

modbus_t* ctx = NULL;
CRITICAL_SECTION csCtx;

COMMMODBUS_API int lib_modbus_connect(const char* ip, int port)
{
	int res = 0;

	InitializeCriticalSection(&csCtx);

	ctx = modbus_new_tcp(ip, port);
	if (ctx != NULL)
	{
		res = modbus_connect(ctx);
	}
	else
	{
		res = -1;
	}

	return res;
}

COMMMODBUS_API int lib_modbus_deconnect()
{
	EnterCriticalSection(&csCtx);

	modbus_close(ctx);
	modbus_free(ctx);

	LeaveCriticalSection(&csCtx);

	DeleteCriticalSection(&csCtx);

	return 0;
}

COMMMODBUS_API int lib_modbus_read_input_bits(int slave_id, int addr, int nb, uint8_t* dest)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_read_input_bits(ctx, addr, nb, dest);
	
	LeaveCriticalSection(&csCtx);

	return result;
}

COMMMODBUS_API int lib_modbus_read_input_registers(int slave_id, int addr, int nb, uint16_t* dest)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_read_input_registers(ctx, addr, nb, dest);

	LeaveCriticalSection(&csCtx);

	return result;
}

COMMMODBUS_API int lib_modbus_read_bits(int slave_id, int addr, int nb, uint8_t* dest)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_read_bits(ctx, addr, nb, dest);

	LeaveCriticalSection(&csCtx);

	return result;
}

COMMMODBUS_API int lib_modbus_read_registers(int slave_id, int addr, int nb, uint16_t* dest)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_read_registers(ctx, addr, nb, dest);

	LeaveCriticalSection(&csCtx);

	return result;
}

COMMMODBUS_API int lib_modbus_write_bits(int slave_id, int addr, int nb, uint8_t* src)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_write_bits(ctx, addr, nb, src);

	LeaveCriticalSection(&csCtx);

	return result;
}

COMMMODBUS_API int lib_modbus_write_registers(int slave_id, int addr, int nb, uint16_t* src)
{
	EnterCriticalSection(&csCtx);

	modbus_set_slave(ctx, slave_id);

	int result = modbus_write_registers(ctx, addr, nb, src);

	LeaveCriticalSection(&csCtx);

	return result;
}