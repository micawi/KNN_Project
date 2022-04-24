using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klass die die Neuronen definiert, aus denen das neuronale
    /// Netz gebildet wird.
    /// </summary>
    public class Neuron
    {
        private int _index;
        /// <summary>
        /// Eigenschaft, die den beim Initialisieren des Netzes zugewiesenen
        /// Index des einzelnen Neurons enthält.
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }
        private double _nettoInput;
        /// <summary>
        /// Eigenschaft, die den Eingangswert für das Neuron
        /// enthält.
        /// </summary>
        public double NettoInput
        {
            get
            {
                return _nettoInput;
            }
            set
            {
                _nettoInput = value;
            }
        }
        private double _aktivierung;
        /// <summary>
        /// Eigenschaft, die den durch die mit dem NettoInput 
        /// berechneten Wert der Aktivierungsfunkton enthält.
        /// </summary>
        public double Aktivierung
        {
            get
            {
                return _aktivierung;
            }
            set
            {
                _aktivierung = value;
            }
        }
        private double _ausgabe;
        /// <summary>
        /// Eigenschaft, die den mit dem Aktivierungswert berechneten Ausgabewert
        /// des Neurons enthält.
        /// </summary>
        public double Ausgabe
        {
            get
            {
                return _ausgabe;
            }
            set
            {
                _ausgabe = value;
            }
        }
        private IAktivierungsfunktion _aktivierungsfunktion;
        /// <summary>
        /// Eigenschaft, die die für dieses Neuron zu verwendende Aktivierungsfunktion
        /// enthält.
        /// </summary>
        public IAktivierungsfunktion Aktivierungsfunktion
        {
            get
            {
                return _aktivierungsfunktion;
            }
            set
            {
                _aktivierungsfunktion = value;
            }
        }
        private IAusgabefunktion _ausgabefunktion;
        /// <summary>
        /// Eigenschaft, die die für dieses Neuron zu verwendende Ausgabefunktion
        /// enthält.
        /// </summary>
        public IAusgabefunktion Ausgabefunktion
        {
            get
            {
                return _ausgabefunktion;
            }
            set
            {
                _ausgabefunktion = value;
            }
        }
        /// <summary>
        /// Konstruktor der Klasse, die den Index 
        /// des Neurons initialisert.
        /// </summary>
        public Neuron(int index)
        {
            Index = index;
        }
    }
}
