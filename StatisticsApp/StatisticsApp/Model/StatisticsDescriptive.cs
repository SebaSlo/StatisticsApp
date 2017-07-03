using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApp.Model
{
    /// <summary>
    /// Modela los datos de la estadística descriptiva
    /// </summary>
    public class StatisticsDescriptive : ObservableCollection<double>
    {
        /*
         * Esta clase debe encargarse de:
         *      Tomar un arreglo de datos. Los datos representan una muestra.
         *      Calcular las características de esa muestra de datos.
         */
        /*
         * La clase ya es una lista que va a contener los valores. Además, va a tener atributos que caractericen la muestra
         */

        #region InternalStatClass

        private double sum;
        /// <summary>
        /// Suma de todos los valores muestrales
        /// </summary>
        public double Suma
        {
            get { return sum; }
            private set { sum = value; }
        }

        private double mean;
        /// <summary>
        /// Media muestral
        /// </summary>
        public double Mean
        {
            get { return mean; }
            private set { mean = value; }
        }


        private double geometricMean;
        /// <summary>
        /// Media geométrica
        /// </summary>
        public double GeometricMean
        {
            get { return geometricMean; }
            private set { geometricMean = value; }
        }

        private double harmonicMean;

        public double HarmonicMean
        {
            get { return harmonicMean; }
            private set { harmonicMean = value; }
        }

        private double min;

        public double Min
        {
            get { return min; }
            private set { min = value; }
        }

        private double max;

        public double Max
        {
            get { return max; }
            private set { max = value; }
        }

        private double range;

        public double Range
        {
            get { return range; }
            private set { range = value; }
        }

        private double variance;

        public double SampleVariance
        {
            get { return variance; }
            private set { variance = value; }
        }

        private double stdDesv;

        public double SampleStdDesv
        {
            get { return stdDesv; }
            private set { stdDesv = value; }
        }

        private double skewness;
        /// <summary>
        /// Coeficiente de asimetría
        /// </summary>
        public double Skwness
        {
            get { return skewness; }
            private set { skewness = value; }
        }

        private double kurtosis;

        public double Kurtosis
        {
            get { return kurtosis; }
            private set { kurtosis = value; }
        }

        private double iqr;

        public double IQR
        {
            get { return iqr; }
            private set { iqr = value; }
        }

        private double median;

        public double Median
        {
            get { return median; }
            private set { median = value; }
        }

        private double firstQuartile;

        public double FirstQuartile
        {
            get { return firstQuartile; }
            private set { firstQuartile = value; }
        }

        private double thirdQuartile;

        public double ThirdCuartile
        {
            get { return thirdQuartile; }
            private set { thirdQuartile = value; }
        }

        /// <summary>
        /// Ni idea para qué es esto
        /// </summary>
        internal double sumOfError;
        internal double sumOfErrorSquare;
        #endregion

        #region Constructors
        //Empty
        #endregion

        #region Methods

            /// <summary>
            /// Calcula el percentil que se pide por el parámetro
            /// </summary>
            /// <param name="percent">Percentil a calcular.</param>
            /// <returns></returns>
        public double Percentile( int percent )
        {
            return 0D;
        }

        private void AnalyzeSample()
        {
            double _productoria = 1, _invSum = 0;
            foreach ( double item in this )
            {
                //Sumo los valores que se encuentran en los datos internos de la muestra (objeto ObservableCollection).
                Suma += item;
                _productoria *= item;
                _invSum += 1 / item;
            }

            //La media muestral es la suma de los x_i dividido el tamaño de la muestra
            Mean = Suma / this.Count;

            //Mediana: es el percentil 50.
            Median = Percentile(50);

            //La media geométrica es la raíz enésima de la productoria.
            GeometricMean = Math.Pow(_productoria, 1.0 / this.Count);

            //La media armónica es la cantidad de elementos de la muestra dividido la suma de las inversas de los valores muestrales.
            HarmonicMean = this.Count / _invSum;

            //Maximo, Minimo y rango de la muestra
            Min = this.Min();
            Max = this.Max();
            Range = Max - Min;

            //Calculo de la varianza
            double _desvioMedia = 0;
            _desvioMedia = PerformMoment(2);

            if ( this.Count >= 30 ) { SampleVariance = _desvioMedia / this.Count; }
            else { SampleVariance = _desvioMedia / ( this.Count - 1 ); }

            //desvío estándar: raíz cuadrada de la varianza
            SampleStdDesv = Math.Sqrt(SampleVariance);

            //Medida de asimetría: su valor exacto esta dado por la division entre el momento de orden 3 y el desvío al cubo.
            Skwness = PerformMoment(3) / Math.Pow(SampleStdDesv,3);

            //Kurtosis: momento centrado de orden 4 sobre desvio a la cuarta
            Kurtosis = PerformMoment(4) / Math.Pow(SampleStdDesv, 4);

            //Cuartiles
            FirstQuartile = Percentile(25);
            ThirdCuartile = Percentile(75);
            IQR = ThirdCuartile - FirstQuartile; //Rango intercuartil.
        }

        /// <summary>
        /// Calcula el momento centrado del orden establecido por el parámetro
        /// </summary>
        /// <param name="order">Orden que se quiere para el momento</param>
        /// <returns></returns>
        private double PerformMoment( int order )
        {
            double m = 0;
            foreach ( var item in this )
            {
                m += Math.Pow(item - Mean, order);
            }

            return m;
        }
        #endregion
    }
}
