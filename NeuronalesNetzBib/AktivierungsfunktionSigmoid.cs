using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die die Sigmoid-Aktivierungsfunktion
    /// definiert.
    /// </summary>
    public class AktivierungsfunktionSigmoid : IAktivierungsfunktion
    {
        /// <summary>
        /// Methode, die für das übergebene Neuron
        /// mit dem Netto-Input den Aktivierungswert 
        /// berechnet.
        /// </summary>
        public void Aktivierungsfunktion(Neuron neuron)
        {
            neuron.Aktivierung = 1 / (1 + Math.Exp(-neuron.NettoInput));
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
