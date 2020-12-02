#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <windows.h>
#include <cmath>
#include <vector>
#include <ctime>

#include "ImageClasse.h"
#include "ImageNdg.h"
#include "ImageCouleur.h"
#include "fonction.h"

using namespace std;

string securite(CImageNdg img)
{
	int imgLarg = img.lireLargeur();

	//seuillage
	CImageNdg imgS = img.seuillage("manu", 100, 200);
	
	// Inversion
	CImageNdg imgInv = imgS.transformation("complement");

	// Erosion
	CImageNdg imgErodee = imgInv.morphologie("erosion");

	// Etiquetage
	CImageClasse imgClasse = CImageClasse(imgErodee, "V8");
	imgClasse = imgClasse.filtrage("taille", 500);
	//std::string g = "image etiq" + to_string(i);
	//mgClasse.sauvegarde(g);

	// récupération de la position de l'objet

	std::vector<SIGNATURE_Forme> sig = imgClasse.sigComposantesConnexes(false);//fichier de signature de forme
	int nombre_objet = imgClasse.lireNbRegions();
	int maxXpos = 0, Xpos;
	string s;
	if (nombre_objet == 0)
		s = "safe";
	else
	{
		for (int j = 1; j <= nombre_objet; j++)
		{
			Xpos = sig[j].rectEnglob_Bj;
			//récupération de la position en x maximal pour chaque objet
			if (Xpos > maxXpos)
			{
				maxXpos = Xpos;
			}
		}

		// Si un objet apparait à l'écran, il est considéré comme un Warning directement
		// Si l'object dépasse le 1/3 de l'image, alors il est considéré comme un danger
		if (maxXpos >= imgLarg / 3)
			s = "danger";
		else
			s = "warning";

	}
	//printf(" nombre d'objet %d \nObjet le plus loin %d \nPosition max %d \nverdict %s\n\n ", nombre_objet, z, maxXpos, s.c_str());

	return s.c_str();
}

string comptageMMS(CImageNdg imgNdg, CImageCouleur img)
{
	
	// Seuillage
	CImageNdg imgS = imgNdg.seuillage("auto");


	// Inversion
	CImageNdg imgInv = imgS.transformation("complement");

	// Erosion
	CImageNdg imgErodee = imgInv.morphologie("erosion");
	

	// Etiquetage
	CImageClasse imgClasse = CImageClasse(imgErodee, "V8");


	// imgClasse.sigComposantesConnexes(true);
	std::vector<SIGNATURE_Forme> sign = imgClasse.sigComposantesConnexes(false);

	// Retourner le centre de grav + surface

	int nombre_objet = imgClasse.lireNbRegions();
	int nbMMSRouge = 0;
	int nbMMSOrange = 0;
	int nbMMSJaune = 0;
	int nbMMSMarron = 0;
	int nbMMSBleu = 0;

	for (int j = 1; j <= nombre_objet; j++)

	{
		int gravx = sign[j].centreGravite_i;
		int gravy = sign[j].centreGravite_j;
		int surface = sign[j].surface;

		// Exraction des plans
		CImageNdg planR = img.plan(0);
		CImageNdg planV = img.plan(1);
		CImageNdg planB = img.plan(2);

		// ROI
		CImageNdg img1 = planR.ROI(gravx, gravy, 50, 50);
		//img1.sauvegarde("Objet 4 plan rouge");
		CImageNdg img2 = planV.ROI(gravx, gravy, 50, 50);
		//img2.sauvegarde("Objet 4 plan Vert");
		CImageNdg img3 = planB.ROI(gravx, gravy, 50, 50);
		//img3.sauvegarde("Objet 4 plan Bleu");

		// Histo
		vector<unsigned long> histo1 = img1.histogramme();
		vector<unsigned long> histo2 = img2.histogramme();
		vector<unsigned long> histo3 = img3.histogramme();

		/*printf("Centre de gravite en x: %d,\nCentre de gravite en y: %d,\nSurface: %d \n", gravx, gravy, surface)*/
		int valRouge = 0;
		int valVert = 0;
		int valBleu = 0;


		for (int p = 100; p < 150; p++)
		{
			valRouge = valRouge + histo1[p];
			valVert = valVert + histo2[p];
			valBleu = valBleu + histo3[p];

		}

		int nbpixels = valBleu + valRouge + valVert;

		float valR = (float)valRouge / (float)nbpixels;
		float valB = (float)valBleu / (float)nbpixels;
		float valV = (float)valVert / (float)nbpixels;

		/*printf("Nombre de pixel: %d \n",nbpixels);*/

		/*printf("Proportion pixel rouge %f,\nProportion pixel bleu: %f, \nProportion pixel vert: %f \n", valR, valB, valV);
*/

		if (valR > 0.55)
		{
			nbMMSRouge = nbMMSRouge + 1;
		}
		else if (valB > 0.55)
		{
			nbMMSBleu = nbMMSBleu + 1;
		}
		else if (valV > 0.59 && valB < 0.106)
		{
			nbMMSJaune = nbMMSJaune + 1;
		}
		else if (valR < 0.52 && valV>0.3 && valB < 0.2)
		{
			nbMMSOrange = nbMMSOrange + 1;
		}
		else if (valR < 0.55 && valR > 0.3 && valB > 0.2)
		{
			nbMMSMarron = nbMMSMarron + 1;
		}

		/*printf("Nombre d'objets:%d\nNombre MMS Rouge: %d\nNombre MMS Orange: %d\nNombre MMS Bleu: %d\nNombre MMS Marron: %d\nNombre MMS Jaune: %d\n", nombre_objet, nbMMSRouge, nbMMSOrange, nbMMSBleu, nbMMSMarron, nbMMSJaune);
		printf("\n");*/

		
	}
	string tab = to_string(nombre_objet) + to_string(nbMMSRouge) + to_string(nbMMSOrange) + to_string(nbMMSBleu) + to_string(nbMMSMarron) + to_string(nbMMSJaune) ;
	
	return tab;
}


