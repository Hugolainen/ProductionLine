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
    public partial class visionControl_Security : Form
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

        private string controlResult = "OK";

        private List<string> _list_path;
        private int _list_path_pos;
        private int _list_path_size;

        private int nbImage;
        private int nbWarning;
        private int nbDanger;

        System.Timers.Timer timerCom_Secu = new System.Timers.Timer();

        public visionControl_Security()
        {
            InitializeComponent();
            nbImage = 0;
            nbWarning = 0;
            nbDanger = 0;

            pictureBox_imageControl.SizeMode = PictureBoxSizeMode.StretchImage;

            // Timer
            timerCom_Secu.Interval = 100;
            timerCom_Secu.Elapsed += new ElapsedEventHandler(TimerEventProcessor);
        }


        // Close this screen and recenter to the MnMs field one
        private void button_close_Click(object sender, EventArgs e)
        {
            Global.closeVisionControl_Security();
        }

        // Initialisation of the screen
        private void visionControl_Security_Load(object sender, EventArgs e)
        {
            _list_path = new List<string>(); // Liste contenant le chemin d'acces des images
            _list_path_pos = 0; // Position actuelle de l'image dans la liste
            _list_path_size = 0; // Nombre d'images dans le dossier

            string[] list1 = Directory.GetFiles("../Images/Security"); // C:/Users/hugoc/Desktop/Projet C#/Dev/Images/Security
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

            pictureBox_imageControl.ImageLocation = _list_path[_list_path_pos];

            timerCom_Secu.Start();
        }
        
        // Called every time this screen is shown
        private void visionControl_Security_Activated(object sender, EventArgs e)
        {
            updateScreen();
        }


        // Updates the objects on this screen
        private void updateScreen()
        {
            writeSafe_label(controlResult, label_securityLevel); // label_securityLevel.Text = controlResult;
            writeSafe_label(nbWarning.ToString(), label_nbWarning);
            writeSafe_label(nbImage.ToString(), label_nbImageControlled);
            writeSafe_label(nbDanger.ToString(), label_nbDanger);

            if (controlResult == "warning")
            {
                pictureBox_securityLevel.BackColor = Color.Orange;
                label_securityLevel.BackColor = Color.Orange;
                writeSafe_label("Warning", label_securityLevel);
            }
            else if (controlResult == "danger")
            {
                pictureBox_securityLevel.BackColor = Color.Red;
                label_securityLevel.BackColor = Color.Red;
                writeSafe_label("Danger", label_securityLevel);
            }
            else
            {
                pictureBox_securityLevel.BackColor = Color.Green;
                label_securityLevel.BackColor = Color.Green;
                writeSafe_label("OK", label_securityLevel);
            }
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
                    // Read Coil address 4 et metre sa valeure dans la variable modGo
                    modGo = Global.communicateModbus(1, 1, 4, "");

                    // check modbus
                    if (modGo)
                    {
                        modGo = false;
                        controlOK = false;

                        // Go to next image
                        nextImage();

                        // Use wrapper to analyze the img  
                        Bitmap imgToTest = new Bitmap(_list_path[_list_path_pos]);
                        controlResult = WrapperTraitement.TraitementSecurity(imgToTest); // OK - warning - danger

                        // Load the controled image in the pictureBox
                        pictureBox_imageControl.ImageLocation = _list_path[_list_path_pos];

                        nbImage++;

                        if (controlResult == "warning")
                        {
                            nbWarning++;
                            Global.prodSecurity_dangerStatus = "Warning";

                            // Write coil address 1 à false
                            Global.communicateModbus(2, 1, 1, "true");
                        }
                        else if (controlResult == "danger")
                        {
                            nbDanger++;
                            Global.prodSecurity_dangerStatus = "danger";

                            // Write coil address 1 à true
                            bool test;
                            test = Global.communicateModbus(2, 1, 1, "true");
                        }
                        else
                        {
                            Global.prodSecurity_dangerStatus = "OK";

                            // Write coil address 1 à false
                            Global.communicateModbus(2, 1, 1, "false");
                        }

                        Global.communicateModbus(2, 1, 5, "true");

                        updateScreen();

                        controlOK = true;
                    }
                }
            }
        }
    }
}
