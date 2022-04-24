using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKI.Interfaces;

namespace NeuronalesNetzBib
{
    /// <summary>
    /// Klasse, die die Gewichtsmatrix für das Neuronale Netz
    /// definiert.
    /// </summary>
    public class Gewichtsmatrix : IGewichtsmatrix
    {
        private int _spalten;
        /// <summary>
        /// Eigenschaft, die die Anzahl der Spalten der Matrix enthält.
        /// </summary>
        public int Spalten
        {
            get
            {
                return _spalten;
            }
            set
            {
                _spalten = value;
            }
        }
        private int _zeilen;
        /// <summary>
        /// Eigenschaft, die die Anzahl der Zeilen der Matrix enthält.
        /// </summary>
        public int Zeilen
        {
            get
            {
                return _zeilen;
            }
            set
            {
                _zeilen = value;
            }
        }
        double[,] _matrix;
        /// <summary>
        /// Methode, die den Lese- und Schreibzugriff auf
        /// die Matrixwerte ermöglicht.
        /// </summary>
        /// <param name="x">Zeilen-Zugriff</param>
        /// <param name="y">Spalten-Zugriff</param>
        public double this[int x, int y]
        {
            get
            {
                return _matrix[x, y];
            }
            set
            {
                _matrix[x, y] = value;
            }
        }
        /// <summary>
        /// Konstruktor der Klasse, der die Matrix im wahrsten Sinne
        /// des Wortes aus den angegebenen Zeilen und Spalten
        /// konstruiert und mit allen Slots auf 0 initialisert.
        /// </summary>
        public Gewichtsmatrix(int zeilen, int spalten)
        {
            Zeilen = zeilen;
            Spalten = spalten;
            _matrix = new double[zeilen, spalten];
            for(int i = 0; i < zeilen; i++)
            {
                for(int j = 0; j < spalten; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }
    }
}
