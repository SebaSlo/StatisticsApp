using StatisticsApp.Helpers;
using StatisticsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example
            /*double[] d = new double[] { 1.1, 2, 3.3, 4, 5, 4, 3.3, 2, 1, 2, 3.2, 4, 3.3, 2, 3.2, 4, 3, 2, 3, 3, 4, 3, 2, 1 };
            StatDescriptive.Descriptive ds = new StatDescriptive.Descriptive(d);
            ds.Analyze();

            Console.WriteLine(ds.Result.GeometricMean); //media geometrica
            Console.WriteLine(ds.Result.HarmonicMean); //media armonica
            Console.WriteLine(ds.Result.IQR); //rango intercuartil
            //Media cuadratia
            Console.WriteLine(ds.Result.ThirdQuartile);//tercer cuartil

            VTClasses.FrequencyTable<double> vt = new VTClasses.FrequencyTable<double>(d);

            /*Falta implementar:
             * GeometricMean
             * HarmonicMean
             * CuadratiMean
             * Percentile
             * */
            /*
           Console.WriteLine("Descripcion: " + vt.Description);
           Console.WriteLine("Moda: " + vt.Mode);
           Console.WriteLine("Mediana: " + vt.Mean);
           Console.WriteLine("Muestra?: " + vt.Skewness);
           */
            #endregion

        }
    }
}