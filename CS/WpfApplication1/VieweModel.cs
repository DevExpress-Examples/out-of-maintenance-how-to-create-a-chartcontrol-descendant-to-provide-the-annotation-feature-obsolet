using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WpfApplication1
{
    public class ViewModel : IDisposable
    {
        public void Dispose()
        {
            if (_Data != null)
            {
                _Data.Dispose();
                _Data = null;
            }
        }
        public ViewModel()
        {

        }

        // Fields...
        private DataTable _Data;

        public DataTable Data
        {
            get
            {
                if (_Data == null)
                    _Data = CreateData(10);
                return _Data;
            }
            set
            {
                _Data = value;
            }
        }

        DataTable CreateData(int rows)
        {
            Random _r = new Random();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ser", typeof(int));
            dt.Columns.Add("Arg", typeof(int));
            dt.Columns.Add("Value", typeof(int));
            for (int i = 0; i < rows; i++)
            {
                dt.Rows.Add(0, i, _r.Next(100));
                dt.Rows.Add(1, i, _r.Next(100));
            }
            return dt;
        }

    }
}
