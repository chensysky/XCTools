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
    public partial class Order : UserControl
    {
        public event OrderCompleteEventHander OrderCompleteEvent;
        public event OrderEventHander OrderEvent;

        private OrderInfo _info;

        public Order(OrderInfo info)
        {
            InitializeComponent();
            this._info = info;
            InitOrder();
        }

        /// <summary>
        /// 初始化预约信息
        /// </summary>
        public void InitOrder()
        {
            lab_date.Text = _info.Date + "    " + _info.Time + "时";
            lab_techer.Text = _info.TecherName;
            lab_type.Text = _info.Type;
        }

        /// <summary>
        /// 开始预约
        /// </summary>
        public void Start()
        {
            Action<OrderInfo> orderAction = new Action<OrderInfo>((info) => { 
                //               
                OrderService os=new OrderService(info);
                os.Init(()=>{
                    os.Submit(new Action<string>((result) => {
                        
                    }));
                });
            });
            orderAction.BeginInvoke(_info, null, null);
            OrderCompleteEvent(this, new OrderCompleteEventArgs(_info));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_del_Click(object sender, EventArgs e)
        {
            OrderEvent(this, new OrderEventArgs(OrderAction.Cancel, _info));
        }


    }


}
