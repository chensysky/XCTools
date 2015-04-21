using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using xctool.Model;
using xctool.Events;
using xctool.Service;

namespace xctool
{
    public partial class OrderList : UserControl
    {
        public event OrderEventHander OrderEvent;
        private List<OrderInfo> _infolist=new List<OrderInfo>();
        private List<Order> _orderlist = new List<Order>();
        private float _postfrequency = 2;

        public OrderList()
        {
            InitializeComponent();
            this.Height = 80;
        }

        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            this.Height = 340;
            panel_order.Height = 300;
            panel_order.AutoScroll = true;
            OrderEvent(this, new OrderEventArgs(OrderAction.Add, null));
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            foreach (Order order in _orderlist)
            {
                order.Start();
                Thread.Sleep(1000);
            }
            OrderEvent(this, new OrderEventArgs(OrderAction.Start, null));
        }

        /// <summary>
        /// 添加预订
        /// </summary>
        /// <param name="infolist"></param>
        public void AddOrder(List<OrderInfo> infolist)
        {
            foreach (OrderInfo info in infolist)
            {
                info.PostFrequency = _postfrequency;
                //
                if(!_infolist.Contains(info))
                {
                    Order order = new Order(info);
                    order.OrderCompleteEvent += new OrderCompleteEventHander(new Action<object, OrderCompleteEventArgs>((obj, args) => {
                        OrderEvent(this, new OrderEventArgs(OrderAction.Finsh, args));
                    }));
                    order.OrderEvent += new OrderEventHander(new Action<object, OrderEventArgs>((obj, args) => {
                        if (args.Action == OrderAction.Cancel)
                        {
                            this.Invoke(new Action(() =>
                            {
                                panel_order.Controls.Remove((Order)obj);
                                if (_infolist.Contains((OrderInfo)args.Args))
                                {
                                    _infolist.Remove((OrderInfo)args.Args);
                                }
                            }));
                        }
                        OrderEvent(this, new OrderEventArgs(args.Action, args));
                    }));
                    panel_order.Controls.Add(order);
                    _orderlist.Add(order);
                    _infolist.Add(info);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            OrderEvent(this, new OrderEventArgs(OrderAction.Cancel, null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_num_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(txt_num.Text.Trim(), out _postfrequency))
            {
                txt_num.Text = "2";
                _postfrequency = 2;
            }
        }

 





    }
}
