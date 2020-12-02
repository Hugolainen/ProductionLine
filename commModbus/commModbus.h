// Le bloc ifdef suivant est la façon standard de créer des macros qui facilitent l'exportation
// à partir d'une DLL plus simple. Tous les fichiers contenus dans cette DLL sont compilés avec le symbole COMMMODBUS_EXPORTS
// défini sur la ligne de commande. Ce symbole ne doit pas être défini pour un projet
// qui utilise cette DLL. Ainsi, les autres projets dont les fichiers sources comprennent ce fichier considèrent les fonctions
// COMMMODBUS_API comme étant importées à partir d'une DLL, tandis que cette DLL considère les symboles
// définis avec cette macro comme étant exportés.
#ifdef COMMMODBUS_EXPORTS
#define COMMMODBUS_API __declspec(dllexport)
#else
#define COMMMODBUS_API __declspec(dllimport)
#endif

#include<string>

#include "modbus.h"

#ifdef __cplusplus
extern "C"
{
#endif
	COMMMODBUS_API int lib_modbus_connect(const char* ip, int port);
	COMMMODBUS_API int lib_modbus_deconnect();

	COMMMODBUS_API int lib_modbus_read_input_bits(int slave_id, int addr, int nb, uint8_t* dest);
	COMMMODBUS_API int lib_modbus_read_input_registers(int slave_id, int addr, int nb, uint16_t* dest);
	COMMMODBUS_API int lib_modbus_read_bits(int slave_id, int addr, int nb, uint8_t* dest);
	COMMMODBUS_API int lib_modbus_read_registers(int slave_id, int addr, int nb, uint16_t* dest);

	COMMMODBUS_API int lib_modbus_write_bits(int slave_id, int addr, int nb, uint8_t* src);
	COMMMODBUS_API int lib_modbus_write_registers(int slave_id, int addr, int nb, uint16_t* src);

#ifdef __cplusplus
}
#endif