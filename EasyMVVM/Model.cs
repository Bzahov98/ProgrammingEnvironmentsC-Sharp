using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasyMVVM
{
    public class Model
    {
        // Using a private data store is a good idea private
        ObservableCollection<string> _data = new ObservableCollection<string>();
        public ObservableCollection<string> GetData()
        {
            // these steps represent the same data to be returned each time GetData is called.
            // typically you'd query a database or put other buisness logic here
            _data.Add("First Entry");
            _data.Add("Second Entry");
            _data.Add("Third Entry");
            return _data;
        }
    }
}
