using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKI.Interfaces;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Interface, das für die verschiedenen Ausgabefunktions-
    /// Klassen das Methodengerüst bereitstellt.
    /// </summary>
    public interface IAusgabefunktion : IFunktion
    {
        void Ausgabefunktion(Neuron neuron);
    }
}
