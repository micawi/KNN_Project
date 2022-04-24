using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronalesNetzBib;
using CKI.Interfaces;
using System.Collections;
using NeuronalesNetzBib.Funktionen;

namespace NeuronalesNetzKonsole
{
    /// <summary>
    /// Klasse des Hauptprogramms (Main-Methode).
    /// Hier werden die Testmuster erzeugt, trainiert und die finale Gewichtsmatrix
    /// und der finale Output des Neuronalen Netzes unabhängig vom Erfolg des Trainings
    /// auf der Konsole ausgegeben.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NeuronalesNetz neuronalesNetz = new NeuronalesNetz();
            List<IDoubleTrainingsmuster> trainingsmuster = new List<IDoubleTrainingsmuster>();
            double[] eingabevektor1 = { 0, 0 };
            double[] zielvektor1 = { 0 };
            double[] eingabevektor2 = { 0, 1 };
            double[] zielvektor2 = { 1 };
            double[] eingabevektor3 = { 1, 0 };
            double[] zielvektor3 = { 1 };
            double[] eingabevektor4 = { 1, 1 };
            double[] zielvektor4 = { 0 };
            TrainingsMuster trainingsmuster1 = new TrainingsMuster(eingabevektor1, zielvektor1);
            TrainingsMuster trainingsmuster2 = new TrainingsMuster(eingabevektor2, zielvektor2);
            TrainingsMuster trainingsmuster3 = new TrainingsMuster(eingabevektor3, zielvektor3);
            TrainingsMuster trainingsmuster4 = new TrainingsMuster(eingabevektor4, zielvektor4);
            trainingsmuster.Add(trainingsmuster1);
            trainingsmuster.Add(trainingsmuster2);
            trainingsmuster.Add(trainingsmuster3);
            trainingsmuster.Add(trainingsmuster4);


            neuronalesNetz.SetzeAnzahlNeuronenUndMatrix(2, 1);
            bool success = false;
            int retry = 0;
            int iterationen = 0;

            IFunktion aktivierungsFunktionLinear = new LineareFunktion();
            IFunktion ausgabeFunktionLinear = new LineareFunktion();
            IFunktion ausgabeFunktionSchwellenwert = new SchwellenwertFunktion();
            IFunktion ausgabeFunktionRechteck = new AusgabefunktionRechteck();

            neuronalesNetz.SetzeFunktionenEingabeschicht(aktivierungsFunktionLinear, ausgabeFunktionLinear);
            neuronalesNetz.SetzeFunktionenAusgabeschicht(aktivierungsFunktionLinear, ausgabeFunktionRechteck);

            while (!success && retry < 15)
            {
                success = neuronalesNetz.Trainieren(trainingsmuster, 0.1, 0.05, 5000, out iterationen);
                retry++;
            }

            Console.WriteLine("Training erfolgreich: " + success + "; Wiederholungen: " + retry + "\n--------\n");

            foreach (TrainingsMuster muster in trainingsmuster)
            {
                Console.WriteLine("Pattern: " + ArrayToString(muster.Eingabevektor) + "; Target: " + ArrayToString(muster.Zielvektor));
                Console.WriteLine("Output:" + ArrayToString(neuronalesNetz.BerechneAusgabe(muster.Eingabevektor).ToArray()) + "\n");
            }

            Console.WriteLine(
                "Matrix: [" + 
                neuronalesNetz.Matrix[0, 2].ToString("0.00") + ", " + 
                neuronalesNetz.Matrix[1, 2].ToString("0.00") + "]");
            Console.WriteLine("Iterationen: " + iterationen);

            Console.ReadLine();
        }

        static string ArrayToString(double[] enumerable)
        {
            string result = "[";
            foreach (var item in enumerable)
            {
                result += item.ToString() + ",";
            }
            return result.TrimEnd(",".ToCharArray()) + "]";
        }
    }
}
