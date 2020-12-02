// traitement.cpp : Définit les fonctions exportées de la DLL.
//

#include "pch.h"
#include "framework.h"
#include "traitement.h"
#include "fonction.h"

void traitementMnMs(char* res, std::byte * data, int stride, int nbLig, int nbCol)
{
	CImageCouleur img(nbLig, nbCol);
	byte* pixPtr = (byte*)data;

	for (int y = 0; y < nbLig; y++)			// Remplissage des pixels
	{
		for (int x = 0; x < nbCol; x++)
		{
			img(y, x)[0] = (unsigned char)pixPtr[3 * x + 2];
			img(y, x)[1] = (unsigned char)pixPtr[3 * x + 1];
			img(y, x)[2] = (unsigned char)pixPtr[3 * x];
		}
		pixPtr += stride;				  // Largeur une seule ligne, gestion multiple 32 bits
	}

	string res_tmp = comptageMMS(img.plan(), img);

	strcpy(res, res_tmp.c_str());

}

void traitementSecurity(char * res, std::byte * data, int stride, int nbLig, int nbCol)
{
	CImageCouleur img(nbLig, nbCol);
	byte* pixPtr = (byte*)data;

	for (int y = 0; y < nbLig; y++)			// Remplissage des pixels
	{
		for (int x = 0; x < nbCol; x++)
		{
			img(y, x)[0] = (unsigned char)pixPtr[3 * x + 2];
			img(y, x)[1] = (unsigned char)pixPtr[3 * x + 1];
			img(y, x)[2] = (unsigned char)pixPtr[3 * x];
		}
		pixPtr += stride;				  // Largeur une seule ligne, gestion multiple 32 bits
	}

	string res_tmp = securite(img.plan());

	strcpy(res, res_tmp.c_str());
}
