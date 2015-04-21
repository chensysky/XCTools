using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;
using xctool.Model;
using xctool.Events;

namespace xctool
{
    public partial class Main : Form
    {
        private Drive _drive;
        private OrderList _orderlist;

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            _drive = new Drive();
            _drive.Dock = DockStyle.Fill;
            _orderlist = new OrderList();
            _orderlist.Dock = DockStyle.Bottom;
            _orderlist.OrderEvent += new OrderEventHander(new Action<object, OrderEventArgs>((obj, args) =>
            {
                switch (args.Action)
                {
                    case OrderAction.Add:
                        _orderlist.AddOrder(_drive.GetOrderList());
                        break;
                    case OrderAction.Start:
                        _drive.SetState(false);
                        break;
                    case OrderAction.Finsh:
                        _drive.SetOrderSuccess(((OrderCompleteEventArgs)args.Args).OrderInfo);
                        break;
                    case OrderAction.Cancel:
                        _drive.SetState(true);
                        break;
                    default:
                        break;
                }
            }));
            tab_xc.Controls.Add(_drive);
            tab_xc.Controls.Add(_orderlist);
        }

    }
}
