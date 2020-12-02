using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Supervision
{
    public partial class visionControl_MnMs : Form
    {
        // Safe writting in the labels
        private delegate void SafeCallDelegate(string text, Label lab);
        private void writeSafe_label(string text, Label lab)
        {
            if (lab.InvokeRequired)
            {
                var d = new SafeCallDelegate(writeSafe_label);
                lab.Invoke(d, new object[] { text, lab });
            }
            else
            {
                lab.Text = text;
            }
        }

        // Result structures
        private MnMs_stats controlStats = new MnMs_stats();
        private MnMs_stats actualControlStats = new MnMs_stats();

        // Vision control result
        private string controlResult = "0000000";

        // Folder where the pictures are located
        private List<string> _list_path;
        private int _list_path_pos;
        private int _list_path_size;

        // Timer
        System.Timers.Timer timerCom_Secu = new System.Timers.Timer();

        public visionControl_MnMs()
        {
            InitializeComponent();

            pictureBox_imageControl.SizeMode = PictureBoxSizeMode.StretchImage;

            // Timer
            timerCom_Secu.Interval = 100;
            timerCom_Secu.Elapsed += new ElapsedEventHandler(TimerEventProcessor);
        }


        // Close this screen and re-center the MnMs field screen
        private void button_close_Click(object sender, EventArgs e)
        {
            Global.closeVisionControl_MnMs();
        }

        // Called when the User swaps the image base parameter for the data
        private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateScreen();
        }

        // Called when the User swaps the percent parameter for the data
        private void checkBox_percent_CheckedChanged(object sender, EventArgs e)
        {
            updateScreen();
        }

        // Updates the screen objects depending on the User selected parameters (percent / single image)
        private void updateScreen()
        {
            writeSafe_label(controlStats.get_nbImg().ToString(), label_nbImage);

           if (!checkBox_allImages.Checked)
           {
                writeSafe_label(actualControlStats.get_nbTotal().ToString(), label_nbMnMs);

                if (checkBox_percent.Checked)
                {
                    writeSafe_label(actualControlStats.get_nbRougePercent().ToString(), label_nbRed);
                    writeSafe_label(actualControlStats.get_nbJaunePercent().ToString(), label_nbYellow);
                    writeSafe_label(actualControlStats.get_nbOrangePercent().ToString(), label_nbOrange);
                    writeSafe_label(actualControlStats.get_nbBleuPercent().ToString(), label_nbBlue);
                    writeSafe_label(actualControlStats.get_nbMarronPercent().ToString(), label_nbBrown);
                }
                else
                {
                    writeSafe_label(actualControlStats.get_nbRouge().ToString(), label_nbRed);
                    writeSafe_label(actualControlStats.get_nbJaune().ToString(), label_nbYellow);
                    writeSafe_label(actualControlStats.get_nbOrange().ToString(), label_nbOrange);
                    writeSafe_label(actualControlStats.get_nbBleu().ToString(), label_nbBlue);
                    writeSafe_label(actualControlStats.get_nbMarron().ToString(), label_nbBrown);
                }
            }
            else
            {
                writeSafe_label(controlStats.get_nbTotal().ToString(), label_nbMnMs);

                if (checkBox_percent.Checked)
                {
                    writeSafe_label(controlStats.get_nbRougePercent().ToString(), label_nbRed);
                    writeSafe_label(controlStats.get_nbJaunePercent().ToString(), label_nbYellow);
                    writeSafe_label(controlStats.get_nbOrangePercent().ToString(), label_nbOrange);
                    writeSafe_label(controlStats.get_nbBleuPercent().ToString(), label_nbBlue);
                    writeSafe_label(controlStats.get_nbMarronPercent().ToString(), label_nbBrown);
                }
                else
                {
                    writeSafe_label(controlStats.get_nbRouge().ToString(), label_nbRed);
                    writeSafe_label(controlStats.get_nbJaune().ToString(), label_nbYellow);
                    writeSafe_label(controlStats.get_nbOrange().ToString(), label_nbOrange);
                    writeSafe_label(controlStats.get_nbBleu().ToString(), label_nbBlue);
                    writeSafe_label(controlStats.get_nbMarron().ToString(), label_nbBrown);
                }
            }
        }

        // Updates the stats structures
        private void updateStats()
        {
            // string "controlResult" = XX X X X X X -> // total - rouge - orange - bleu - marron - jaune
            // sub-string  = string.Substring(0, 12); -> 12 first char
            actualControlStats.majActual(
                Int16.Parse(controlResult.Substring(0, 1)),
                Int16.Parse(controlResult.Substring(2, 1)),
                Int16.Parse(controlResult.Substring(1, 1)),
                Int16.Parse(controlResult.Substring(4, 1)),
                Int16.Parse(controlResult.Substring(3, 1)),
                Int16.Parse(controlResult.Substring(5, 1)));
            controlStats.majSums(
                Int16.Parse(controlResult.Substring(0, 1)),
                Int16.Parse(controlResult.Substring(2, 1)),
                Int16.Parse(controlResult.Substring(1, 1)),
                Int16.Parse(controlResult.Substring(4, 1)),
                Int16.Parse(controlResult.Substring(3, 1)),
                Int16.Parse(controlResult.Substring(5, 1)));
        }

        // Is called when showing this screen
        private void visionControl_MnMs_Activated(object sender, EventArgs e)
        {
            updateScreen();
        }

        private void visionControl_MnMs_Load(object sender, EventArgs e)
        {
            _list_path = new List<string>(); // Liste contenant le chemin d'acces des images
            _list_path_pos = 0; // Position actuelle de l'image dans la liste
            _list_path_size = 0; // Nombre d'images dans le dossier

            string[] list1 = Directory.GetFiles("../Images/MnMs"); // C:/Users/hugoc/Desktop/Projet C#/Dev/Images/MnMs
            for (int i = 0; i < list1.Length; i++)
            {
                // Génération à partir de ce tableau d'une liste de string contenant le nom des fichiers
                if (list1[i].Contains(".bmp"))
                {
                    _list_path.Add(list1[i]);
                }
            }

            _list_path_pos = 0;
            _list_path_size = _list_path.Count();

            // Change l'image affichée
            pictureBox_imageControl.ImageLocation = _list_path[_list_path_pos];

            timerCom_Secu.Start();
        }


        private void nextImage()
        {
            // Empeche de charger un _list_path_pos null (génere une erreur)
            if (_list_path_pos >= _list_path_size - 1)
            {
                _list_path_pos = 0;
            }
            else
            {
                _list_path_pos++;
            }
        }

        bool controlOK = true;
        bool modGo = false;
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (Global.prod_MnMs.getOrderStatus() == "in progress")
            {
                if (controlOK)
                {
                    // Read Coil address 2 et metre sa valeure dans la variable modGo
                    modGo = Global.communicateModbus(1, 1, 2, "");

                    if (modGo)
                    {
                        controlOK = false;
                        modGo = false;

                        // Go to next image
                        nextImage();

                        // Use wrapper to analyze the img
                        controlResult = WrapperTraitement.TraitementMnMs(new Bitmap(_list_path[_list_path_pos]));

                        // Tell Runtime that the vision control is done
                        Global.communicateModbus(2, 1, 3, "true");

                        // string = total - rouge - orange - bleu - marron - jaune
                        updateStats();

                        // Show the controled image in the picture box
                        pictureBox_imageControl.ImageLocation = _list_path[_list_path_pos];

                        // Upadtes screen objects
                        updateScreen();

                        // Update Global level production status
                        Global.update_MnMs_stats(controlStats.get_nbTotal(), controlStats.get_nbRouge(), controlStats.get_nbOrange(), controlStats.get_nbBleu(), controlStats.get_nbJaune(), controlStats.get_nbMarron());

                        modGo = false;
                        controlOK = true;
                    }
                }
            }
        }
    }
}
