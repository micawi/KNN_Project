using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKI.Interfaces;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die das einzelne Trainingsmuster mit
    /// den drei konstituierenden Eigenschaften definiert.
    /// </summary>
    public class TrainingsMuster : IDoubleTrainingsmuster
    {
        private double[] _eingabevektor;
        /// <summary>
        /// Eigenschaft, die den Eingabevektor für das 
        /// Neuronale Netz enthält, dessen einzelne Arraywerte
        /// dann auf einzelne Neuronen verteilt werden.
        /// </summary>
        public double[] Eingabevektor
        {
            get
            {
                return _eingabevektor;
            }
            set
            {
                _eingabevektor = value;
            }
        }
        private double[] _zielvektor;
        /// <summary>
        /// Eigenschaft, die den für den gegebenen EingabeVektor
        /// gewünschten Targetvektor enthält. Die Ausgabeneuronen
        /// diesen Vektor zusammen produzieren zu lassen ist das
        /// Ziel des Trainings.
        /// </summary>
        public double[] Zielvektor
        {
            get
            {
                return _zielvektor;
            }
            set
            {
                _zielvektor = value;
            }
        }
        private double[] _tatsaechlicheAusgabe;
        /// <summary>
        /// Eigenschaft, die die tatsächlich berechnete Ausgabe des 
        /// Neuronalen Netzes für den gegebenen EingabeVektor
        /// enthalten soll. 
        /// Effektiv unbenutzt.
        /// </summary>
        public double[] TatsaechlicheAusgabe
        {
            get
            {
                return _tatsaechlicheAusgabe;
            }
            set
            {
                _tatsaechlicheAusgabe = value;
            }
        }
        /// <summary>
        /// Konstruktor der Klasse, die die zwei
        /// direkt für das Neuronale Netz
        /// relevanten Eigenschaften initialisiert.
        /// </summary>
        /// <param name="eingabevektor">Pattern</param>
        /// <param name="zielvektor">Target</param>
        public TrainingsMuster(double[] eingabevektor, double[] zielvektor)
        {
            Eingabevektor = eingabevektor;
            Zielvektor = zielvektor;
        }
    }
}
