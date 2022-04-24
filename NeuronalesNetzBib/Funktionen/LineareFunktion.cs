using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib.Funktionen
{
    /// <summary>
    /// Klasse, die durch Implementierung der zwei Interfaces 
    /// die Lineare Funktion sowohl als Aktivierungs- als auch
    /// als Ausgabefunktion zur Verfügung stellt.
    /// definiert.
    /// </summary>
    public class LineareFunktion : IAusgabefunktion, IAktivierungsfunktion
    {
        /// <summary>
        /// Methode, die für das übergebene Neuron
        /// mit dem Netto-Input den Aktivierungswert 
        /// berechnet.
        /// </summary>
        public void Aktivierungsfunktion(Neuron neuron)
        {
            neuron.Aktivierung = BerechneFunktionswert(neuron.NettoInput);
        }
        /// <summary>
        /// Methode, die für das übergebene Neuron
        /// mit dem Aktivierungswert den Ausgabewert
        /// berechnet.
        /// </summary>
        public void Ausgabefunktion(Neuron neuron)
        {
            neuron.Ausgabe = BerechneFunktionswert(neuron.Aktivierung);
        }
        /// <summary>
        /// Effektiv unbenutzte Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneAbleitungswert(double x)
        {
            return 1;
        }
        /// <summary>
        /// Effektiv unbenutzte Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneFunktionswert(double x)
        {
            return x;
        }
    }
}
