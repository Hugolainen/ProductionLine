// Le bloc ifdef suivant est la façon standard de créer des macros qui facilitent l'exportation
// à partir d'une DLL plus simple. Tous les fichiers contenus dans cette DLL sont compilés avec le symbole TRAITEMENT_EXPORTS
// défini sur la ligne de commande. Ce symbole ne doit pas être défini pour un projet
// qui utilise cette DLL. Ainsi, les autres projets dont les fichiers sources comprennent ce fichier considèrent les fonctions
// TRAITEMENT_API comme étant importées à partir d'une DLL, tandis que cette DLL considère les symboles
// définis avec cette macro comme étant exportés.
#ifdef TRAITEMENT_EXPORTS
#define TRAITEMENT_API __declspec(dllexport)
#else
#define TRAITEMENT_API __declspec(dllimport)
#endif

#include<string>

#ifdef __cplusplus
extern "C"
{
#endif

	TRAITEMENT_API void traitementMnMs(char* res, std::byte* data, int stride, int nbLig, int nbCol);
	TRAITEMENT_API void traitementSecurity(char* res, std::byte* data, int stride, int nbLig, int nbCol);

#ifdef __cplusplus
}
#endif
