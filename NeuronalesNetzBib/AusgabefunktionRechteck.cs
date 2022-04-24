using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKI.Interfaces;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die die für manche Trainingsmuster wichtige
    /// Rechteck-Ausgabefunktion definiert.
    /// </summary>
    public class AusgabefunktionRechteck : IAusgabefunktion
    {
        /// <summary>
        /// Methode, die für das übergebene Neuron
        /// mit dem Aktivierungswert den Ausgabewert 
        /// berechnet.
        /// </summary>
        public void Ausgabefunktion(Neuron neuron)
        {
            if((neuron.Aktivierung > 0.25) && (neuron.Aktivierung <= 0.75))
            {
                neuron.Ausgabe = 1;
            }
            else
            {
                neuron.Ausgabe = 0;
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
