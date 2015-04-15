using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xctool.Model;

namespace xctool.Events
{
    public  class OrderCompleteEventArgs:EventArgs
    {
        private OrderInfo _info;

        public OrderInfo OrderInfo
        {
            get { return _info; }
            set { _info = value; }
        }

        private bool _success;

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        private Exception _exp;

        public Exception Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }

        public  OrderCompleteEventArgs(OrderInfo info)
        {
            _info = info;
            _success = true;
        }

        public  OrderCompleteEventArgs(OrderInfo info,Exception ex)
        {
            _info = info;
            _success = false;
            _exp = ex;
        }
    }
}
