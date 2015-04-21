using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xctool.Events
{
    public class OrderEventArgs : EventArgs
    {
        private OrderAction _action;

        public OrderAction Action
        {
            get { return _action; }
            set { _action = value; }
        }
        private object _args;

        public object Args
        {
            get { return _args; }
            set { _args = value; }
        }

        public  OrderEventArgs(OrderAction action, object args)
        {
            _action = action;
            _args = args;
        }
    }

    public enum OrderAction
    {
        Add, Start,Finsh,Complete,Cancel,Stop
    }
}
