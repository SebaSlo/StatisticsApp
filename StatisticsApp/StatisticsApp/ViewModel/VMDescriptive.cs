using StatisticsApp.Helpers;
using StatisticsApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatisticsApp.ViewModel
{
    class VMDescriptive : VMBase
    {

        private ObservableCollection<GroupedData<string, ItemDescriptive>> dataDescriptive;
        public ObservableCollection<GroupedData<string, ItemDescriptive>> DataDescriptive { get { return dataDescriptive; } set { SetProperty(ref dataDescriptive, value); } }

        private double[] userData;

        private string userDataString;
        public string UserDataString
        {
            get { return userDataString; }
            set
            {
                SetProperty(ref userDataString, value);
                (LoadUserData as Command).RaiseCanExecuteChanged();
            }
        }


        private bool emptyData;
        public bool EmptyData
        {
            get { return emptyData; }
            set { SetProperty(ref emptyData, value);}
        }


        private ICommand loadUserData;
        public ICommand LoadUserData
        {
            get { return loadUserData; }
            set { loadUserData = value; }
        }

        #region Constructors
        public VMDescriptive()
        {
            Title = "Estadística Descriptiva";
            EmptyData = false;
            LoadUserData = new Command(LoadValuesFromUserData, ()=> { return !string.IsNullOrEmpty(UserDataString); });
#if DEBUG
            //Carga valores de ejemplo para ver el funcionamiento de la app
            //CargarValores();
#endif
        }

        /// <summary>
        /// Calcula los valores de estadistica descriptiva de los datos que e usuario carg ya sea por un archivo o por el editor.
        /// </summary>
        private void LoadValuesFromUserData()
        {
            try
            {
                //Modificar el vector de string y tranformarlo en doubles
                this.StringToDoubleArray(this.UserDataString);
                //calcular la tabla de frecuencias
                DataDescriptive = new ObservableCollection<GroupedData<string, ItemDescriptive>>();
                FrequencyTable<double> data = new FrequencyTable<double>(userData);
                if (data != null) EmptyData = true;

                //Tendencia central
                DataDescriptive.Add(
                    new GroupedData<string, ItemDescriptive>(new ItemDescriptive[]
                    {
                    new ItemDescriptive(){Detail="Media Aritmética",Value=data.Mean},
                    new ItemDescriptive(){Detail="Media Geométrica - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Media Armónica - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Media Cuadrática - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Mediana",Value=data.Median},
                    new ItemDescriptive(){Detail="Moda",Value=data.Mode},
                    })
                    { Type = "Medidas de tendencia central" });

                //Dispersion
                DataDescriptive.Add(
                    new GroupedData<string, ItemDescriptive>(new ItemDescriptive[]
                    {
                    new ItemDescriptive(){Detail="Rango",Value=data.Range},
                    new ItemDescriptive(){Detail="Desviación Media",Value=data.StandardDevSample},
                    new ItemDescriptive(){Detail="Varianza",Value=data.VarianceSample},
                    new ItemDescriptive(){Detail="Desviación Estándar",Value=data.StandardDevSample},
                    new ItemDescriptive(){Detail="Coeficiente de Variación",Value=data.StandardDevSample/data.Mean}
                    })
                    { Type = "Medidas de dispersión" });

                //Medidas de forma
                DataDescriptive.Add(
                    new GroupedData<string, ItemDescriptive>(
                        new ItemDescriptive[]
                        {
                        new ItemDescriptive()
                        {
                            Detail="Asimetría", Value=data.Skewness
                        },
                        new ItemDescriptive()
                        {
                            Detail="Curtosis", Value=data.Kurtosis
                        }
                        })
                    { Type = "Medidas de forma" });
            }
            catch (FormatException e)
            {
                UserDataString = e.Message;
            }            
        }
        #endregion

        #region Methods
        /// <summary>
        /// DEBUG: utiliza valores de prueba para mostrar datos ficticios en la app
        /// </summary>
        private void CargarValores()
        {
            FrequencyTable<double> data = new FrequencyTable<double>(new double[] { 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5, 1, 2, 1, 1, 2, 3, 3, 4, 4, 5, 3, 4, 2, 3, 4, 5, 6, 5, 4, 3, 2, 3, 4, 5 });


            //Tendencia central
            DataDescriptive.Add(
                new GroupedData<string, ItemDescriptive>(new ItemDescriptive[]
                {
                    new ItemDescriptive(){Detail="Media Aritmética",Value=data.Mean},
                    new ItemDescriptive(){Detail="Media Geométrica - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Media Armónica - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Media Cuadrática - No implementado",Value=0},
                    new ItemDescriptive(){Detail="Mediana",Value=data.Median},
                    new ItemDescriptive(){Detail="Moda",Value=data.Mode},
                })
                { Type = "Medidas de tendencia central" }
                );
            //Dispersion
            DataDescriptive.Add(
                new GroupedData<string, ItemDescriptive>(new ItemDescriptive[]
                {
                    new ItemDescriptive(){Detail="Rango",Value=data.Range},
                    new ItemDescriptive(){Detail="Desviación Media",Value=data.StandardDevSample},
                    new ItemDescriptive(){Detail="Varianza",Value=data.VarianceSample},
                    new ItemDescriptive(){Detail="Desviación Estándar",Value=data.StandardDevSample},
                    new ItemDescriptive(){Detail="Coeficiente de Variación",Value=data.StandardDevSample/data.Mean}
                })
                { Type = "Medidas de dispersión" }
                );

            //Medidas de forma
            DataDescriptive.Add(
                new GroupedData<string, ItemDescriptive>(
                    new ItemDescriptive[]
                    {
                        new ItemDescriptive()
                        {
                            Detail="Asimetría", Value=data.Skewness
                        },
                        new ItemDescriptive()
                        {
                            Detail="Curtosis", Value=data.Kurtosis
                        }
                    }
                    )
                {
                    Type = "Medidas de forma"
                }
                );
        }

        /// <summary>
        /// Convierte la matriz de strings en números. Si contiene letras, lanza una excepcion FormatException
        /// </summary>
        /// <param name="s">Matriz a convertir</param>
        private void StringToDoubleArray(string s)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";

            s=s.Trim();
            s = s.Replace(".", nfi.NumberDecimalSeparator);
            var aux = s.Split(' ');

            userData = new double[aux.Length];
            for (int i = 0; i < aux.Length; i++)
            {
                try
                {
                    userData[i] = Double.Parse(aux[i],nfi);
                }
                catch (FormatException e)
                {
                    throw new FormatException("Utilice Sólo números. " + e.Message);
                }
            }

        }
        #endregion
    }
}
