using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib
{
    public class RechteckFunktion : IAusgabefunktion
    {
        public void Ausgabefunktion(Neuron neuron)
        {
            if(neuron.Aktivierung > 0.25 && neuron.Aktivierung <= 0.75)
            {
                neuron.Ausgabe = 1;
            }
            else
            {
                neuron.Ausgabe = 0;
            }
        }
    }
}
