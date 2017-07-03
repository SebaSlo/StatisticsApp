
using StatisticsApp.Helpers;

namespace StatisticsApp.Model
{
    /// <summary>
    /// This class represents an item for show in the view
    /// Esta clase representa un item para mostrarlo en la interfaz de usuario
    /// </summary>
    internal class ItemDescriptive:ObservableObject
    {
        /// <summary>
        /// Detalle del item. Se muestra su valor en la UI
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Valor que se muestra
        /// </summary>
        public double Value { get; set; }


        /// <summary>
        /// Especifica si el ítem fue seleccionado
        /// </summary>
        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }
    }
}