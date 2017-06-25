using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApp.Helpers
{
    
    public class GroupedData<Tkey, TValue>:ObservableCollection<TValue>
    {
        public Tkey Type { get; set; }

        public GroupedData(){}
        public GroupedData(IEnumerable<TValue> list){
            foreach (var item in list)
            {
                this.Add(item);
            }
        }
    }
}
