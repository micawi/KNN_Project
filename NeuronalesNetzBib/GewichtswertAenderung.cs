using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die die erforderlichen Daten für
    /// eine erfolgreiche Anpassung der Gewichtsmatrix,
    /// also den Lernprozess, enthält.
    /// </summary>
    public class GewichtswertAenderung
    {
        private int _j;
        /// <summary>
        /// Eigenschaft, die die Zielspalte für die 
        /// Anpassung der Matrix enthält.
        /// </summary>
        public int J
        {
            get
            {
                return _j;
            }
            set
            {
                _j = value;
            }
        }
        private int _i;
        /// <summary>
        /// Eigenschaft, die die Zielzeile für die 
        /// Anpassung der Matrix enthält.
        /// </summary>
        public int I
        {
            get
            {
                return _i;
            }
            set
            {
                _i = value;
            }
        }
        private double _wert;
        /// <summary>
        /// Eigenschaft, die die Wertanpassung für
        /// den durch die Eigenschaften I und J
        /// definierten Matrixslot enthält.
        /// </summary>
        public double Wert
        {
            get
            {
                return _wert;
            }
            set
            {
                _wert = value;
            }
        }
        /// <summary>
        /// Konstruktor der Klasse, die
        /// sofort alle Parameter für
        /// die Wertanpassung initialisiert.
        /// </summary>
        /// <param name="i">Zielzeile</param>
        /// <param name="j">Zielspalte</param>
        /// <param name="wert">Wertanpassung</param>
        public GewichtswertAenderung(int i, int j, double wert)
        {
            I = i;
            J = j;
            Wert = wert;
        }
    }
}
