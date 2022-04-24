using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die die "Linear bis Sättigung"-Aktivierungsfunktion
    /// definiert.
    /// </summary>
    public class AktivierungsfunktionLinearSaettigung : IAktivierungsfunktion
    {
        /// <summary>
        /// Methode, die für das übergebene Neuron
        /// mit dem Netto-Input den Aktivierungswert 
        /// berechnet.
        /// </summary>
        public void Aktivierungsfunktion(Neuron neuron)
        {
            double nettoInputAbsolute = Math.Abs(neuron.NettoInput);
            if(nettoInputAbsolute <= 1 && nettoInputAbsolute >= 0)
            {
                neuron.Aktivierung = neuron.NettoInput;
            }
            else if(neuron.NettoInput > 1)
            {
                neuron.Aktivierung = 1;
            }
            else
            {
                neuron.Aktivierung = 0;
            }
        }
        /// <summary>
        /// Platzhalter-Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneAbleitungswert(double x)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Platzhalter-Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneFunktionswert(double x)
        {
            throw new NotImplementedException();
        }
    }
}
