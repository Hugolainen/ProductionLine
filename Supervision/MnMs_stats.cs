using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervision
{
    public class MnMs_stats
    {
        private int _nbImg;
        private int _nbTotal;
        private int _nbOrange;
        private int _nbRouge;
        private int _nbMarron;
        private int _nbBleu;
        private int _nbJaune;

        // constructor
        public MnMs_stats()
        {
            _nbImg = 0;
            _nbTotal = 0;
            _nbOrange = 0;
            _nbRouge = 0;
            _nbMarron = 0;
            _nbBleu = 0;
            _nbJaune = 0;
        }

        // Updates the parameters for MnMs_stats structure used as Sum
        public void majSums(int total, int orange, int red, int brown, int blue, int yellow)
        {
            _nbImg++;
            _nbTotal += total;
            _nbOrange += orange;
            _nbRouge += red;
            _nbMarron += brown;
            _nbBleu += blue;
            _nbJaune += yellow;
        }

        // Updates the parameters for MnMs_stats structure used as Real time results 
        public void majActual(int total, int orange, int red, int brown, int blue, int yellow)
        {
            _nbImg++;
            _nbTotal = total;
            _nbOrange = orange;
            _nbRouge = red;
            _nbMarron = brown;
            _nbBleu = blue;
            _nbJaune = yellow;
        }

        // Getters
        public int get_nbImg() { return _nbImg; }
        public int get_nbTotal() { return _nbTotal; }
        public int get_nbOrange() { return _nbOrange; }
        public int get_nbRouge() { return _nbRouge; }
        public int get_nbMarron() { return _nbMarron; }
        public int get_nbBleu() { return _nbBleu; }
        public int get_nbJaune() { return _nbJaune; }

        // Getters for percent values
        public float get_nbOrangePercent() { return 100 * _nbOrange / _nbTotal; }
        public float get_nbRougePercent() { return 100 * _nbRouge / _nbTotal; }
        public float get_nbMarronPercent() { return 100 * _nbMarron / _nbTotal; }
        public float get_nbBleuPercent() { return 100 * _nbBleu / _nbTotal; }
        public float get_nbJaunePercent() { return 100 * _nbJaune / _nbTotal; }
    }
}
