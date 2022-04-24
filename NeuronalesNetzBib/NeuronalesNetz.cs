using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKI.Interfaces;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Zentrale Klasse des Programms;
    /// stellt das Neuronale Netz mit den dazugehörigen Neuronen und
    /// die für das Training des Netzes benötigten Methoden und Eigenschaften
    /// dar.
    /// </summary>
    public class NeuronalesNetz : IFeedForwardNetz, IFunktion
    {
        private IGewichtsmatrix _matrix;
        /// <summary>
        /// Eigenschaft, die die Gewichtsmatrix dieses Neuronalen Netzes
        /// enthält.
        /// </summary>
        public IGewichtsmatrix Matrix
        {
            get
            {
                return _matrix;
            }
            set
            {
                _matrix = value;
            }
        }
        /// <summary>
        /// Eigenschaft, die die zum Netz zugehörigen Neuronen (Klasse Neuron)
        /// in Form einer Liste enthält.
        /// </summary>
        public List<Neuron> Neurons = new List<Neuron>();
        private int[] _anzahlNeuronen;
        /// <summary>
        /// Eigenschaft, die jeweils die Anzahl der Neuronen in der Eingabeschicht 
        /// (Index [0]) und der Ausgabeschicht (Index [1]) enthält.
        /// </summary>
        public int[] AnzahlNeuronen
        {
            get
            {
                return _anzahlNeuronen;
            }
            set
            {
                _anzahlNeuronen = value;
            }
        }
        private int[] _matrixDimensionen;
        /// <summary>
        /// Eigenschaft, die jeweils von der zum Netz gehörigen Matrix die Anzahl
        /// der Zeilen (Index [0]) und Spalten (Index [1]) enthält.
        /// </summary>
        public int[] MatrixDimensionen
        {
            get
            {
                return _matrixDimensionen;
            }
            set
            {
                _matrixDimensionen = value;
            }
        }
        /// <summary>
        /// Platzhalter-Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneAbleitungswert(double x)
        {
            return 0;
        }
        /// <summary>
        /// Methode, in der für den gegebenen eingabeVektor
        /// durch die Neuronen in Eingabe- und Ausgabeschicht
        /// ein ausgabeVektor berechnet wird, der zurückgegeben wird.
        /// </summary>
        public List<double> BerechneAusgabe(double[] eingabeVektor)
        {
            List<double> ausgabeVektor = new List<double>();
            foreach (Neuron neuron in Neurons)
            {
                neuron.NettoInput = 0;
            }
            for(int i = 0; i < AnzahlNeuronen[0]; i++)
            {
                Neurons[i].NettoInput = eingabeVektor[i];
                Neurons[i].Aktivierungsfunktion.Aktivierungsfunktion(Neurons[i]);
                Neurons[i].Ausgabefunktion.Ausgabefunktion(Neurons[i]);
            }
            for (int i = AnzahlNeuronen[0]; i < Neurons.Count(); i++)
            {
                for (int j = 0; j < AnzahlNeuronen[0]; j++)
                {
                    Neurons[i].NettoInput += Neurons[j].Ausgabe * Matrix[j, i];
                }
            }
            foreach (Neuron neuron in Neurons)
            {
                if (neuron.Index >= AnzahlNeuronen[0])
                {
                    neuron.Aktivierungsfunktion.Aktivierungsfunktion(neuron);
                    neuron.Ausgabefunktion.Ausgabefunktion(neuron);
                    ausgabeVektor.Add(neuron.Ausgabe);
                }
            }
            return ausgabeVektor;
        }
        /// <summary>
        /// Platzhalter-Methode aus Interface IFunktion.
        /// </summary>
        public double BerechneFunktionswert(double x)
        {
            return 0;
        }

        /// <summary>
        /// Methode, in der die Matrix des Neuronalen Netzes
        /// mit (pseudo)zufälligen Werten initialisiert wird.
        /// </summary>
        public void InitialisiereMatrix()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int x = 0; x < AnzahlNeuronen[0]; x++)
            {
                for (int y = AnzahlNeuronen[0]; y < AnzahlNeuronen[0] + AnzahlNeuronen[1]; y++)
                {
                    Matrix[x, y] = rnd.NextDouble();
                }
            }
        }
        /// <summary>
        /// Methode, mit der die Größe des Neuronalen Netzes festgelegt und dieses durch 
        /// Erzeugen der Neuronen und der Matrix initialisiert wird.
        /// </summary>
        public void SetzeAnzahlNeuronenUndMatrix(int eingabeSchicht, int ausgabeSchicht)
        {
            AnzahlNeuronen = new int[] { eingabeSchicht, ausgabeSchicht };
            MatrixDimensionen = new int[] { eingabeSchicht + ausgabeSchicht, eingabeSchicht + ausgabeSchicht};
            Gewichtsmatrix gewichtsmatrix = new Gewichtsmatrix(MatrixDimensionen[0], MatrixDimensionen[1]);
            Matrix = gewichtsmatrix;
            for (int i = 0; i < AnzahlNeuronen.Sum(); i++)
            {
                Neurons.Add(new Neuron(i));
            }
        }
        /// <summary>
        /// Methode, mit der die zu verwendende Aktivierungsfunktion und Ausgabefunktion
        /// der Ausgabeneuronen festgelegt wird.
        /// </summary>
        public void SetzeFunktionenAusgabeschicht(IFunktion AktivierungsFunktion, IFunktion AusgabeFunktion)
        {
            for (int i = AnzahlNeuronen[0]; i < Neurons.Count(); i++)
            {
                Neurons[i].Aktivierungsfunktion = (IAktivierungsfunktion)AktivierungsFunktion;
                Neurons[i].Ausgabefunktion = (IAusgabefunktion)AusgabeFunktion;
            }
        }
        /// <summary>
        /// Methode, mit der die zu verwendende Aktivierungsfunktion und Ausgabefunktion
        /// der Eingabeneuronen festgelegt wird.
        /// </summary>
        public void SetzeFunktionenEingabeschicht(IFunktion AktivierungsFunktion, IFunktion AusgabeFunktion)
        {
            for (int i = 0; i < AnzahlNeuronen[0]; i++)
            {
                Neurons[i].Aktivierungsfunktion = (IAktivierungsfunktion)AktivierungsFunktion;
                Neurons[i].Ausgabefunktion = (IAusgabefunktion)AusgabeFunktion;
            }
        }
        /// <summary>
        /// Methode, die das angegebene Trainingsmuster mit den gewünschten Parametern Lernrate,
        /// Toleranz und maximale Iterationen zu trainieren versucht.
        /// Gibt zurück, ob Training erfolgreich war.
        /// </summary>
        public bool Trainieren(List<IDoubleTrainingsmuster> trainingsmuster, double lernrate, double toleranz, int maxIterationen, out int iterationen)
        {
            InitialisiereMatrix();

            bool trainingErfolgreich = false;
            iterationen = 0;
            for (int i = 0; i < maxIterationen; i++)
            {
                List<bool> listTrainingErfolgreich = new List<bool>();
                foreach (IDoubleTrainingsmuster currTrainingsmuster in trainingsmuster)
                {
                    List<double> ausgabeVektor = BerechneAusgabe(currTrainingsmuster.Eingabevektor);
                    List<double> deltaList = new List<double>();
                    for(int j = 0; j < ausgabeVektor.Count(); j++)
                    {
                        deltaList.Add(currTrainingsmuster.Zielvektor[j] - ausgabeVektor[j]);
                    }
                    bool deltaZuGroß = false;
                    for(int j = 0; j < deltaList.Count(); j++)
                    {
                        if(Math.Abs(deltaList[j]) > Math.Abs(toleranz))
                        {
                            deltaZuGroß = true;
                            listTrainingErfolgreich.Add(deltaZuGroß);
                            break;
                        }
                    }
                    if (deltaZuGroß == true)
                    {
                        List<GewichtswertAenderung> wertAenderung = new List<GewichtswertAenderung>();
                        for (int a = 0; a < AnzahlNeuronen[0]; a++)
                        {
                            for (int b = AnzahlNeuronen[0]; b < AnzahlNeuronen.Sum(); b++)
                            {
                                double wert = lernrate * currTrainingsmuster.Eingabevektor[a] * deltaList[AnzahlNeuronen[0] - b];
                                wertAenderung.Add(new GewichtswertAenderung(a, b, wert));
                            }
                        }
                        for (int j = 0; j < wertAenderung.Count(); j++)
                        {
                            Matrix[wertAenderung[j].I, wertAenderung[j].J] += wertAenderung[j].Wert;
                        }
                    }
                    else
                    {
                        listTrainingErfolgreich.Add(deltaZuGroß);
                        continue;
                    }
                }
                for (int x = 0; x < listTrainingErfolgreich.Count(); x++)
                {
                    if (listTrainingErfolgreich[x] == true)
                    {
                        iterationen++;
                        break;
                    }
                    if (x == listTrainingErfolgreich.Count() - 1)
                    {
                        trainingErfolgreich = true;
                    }
                }
                if (trainingErfolgreich == true)
                {
                    break;
                }
            }
            return trainingErfolgreich;
        }
    }
}
