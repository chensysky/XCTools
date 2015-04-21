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
        private bool _over = false;
        private int _count = 1;

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
            ShowMsg("开始预约");
            Action<OrderInfo> orderAction = null; 
            orderAction = new Action<OrderInfo>((info) =>
            { 
                //               
                OrderService os=new OrderService(info);
                os.Init(() =>
                {
                    ShowMsg("第" + _count + "次预约信息加载完成");
                    ShowMsg("第" + _count + "次提交预约");
                    os.Submit(() =>
                    {
                        ShowMsg("预约成功");
                        this.Invoke(new Action(() => { this.group_order.BackColor = Color.Green; }));
                        OrderCompleteEvent(this, new OrderCompleteEventArgs(_info));
                    }, error =>
                    {
                        ShowMsg("第" + _count + "次预约失败，错误如下：");
                        ShowMsg(error);
                        if (!_over)
                        {
                            Thread.Sleep(500);
                            _count++;
                            orderAction(_info);
                        }
                    });
                }, (error) => {
                    ShowMsg("第" + _count + "次预约信息加载失败，错误如下：");
                    ShowMsg(error);
                    if (!_over)
                    {
                        Thread.Sleep(500);
                        _count++;
                        orderAction(_info);
                    }
                });
            });
            orderAction.BeginInvoke(_info, null, null);
            ShowMsg("开始加载预约信息");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_del_Click(object sender, EventArgs e)
        {
            _over = true;
            OrderEvent(this, new OrderEventArgs(OrderAction.Cancel, _info));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            if (txt_msg.InvokeRequired)
            {
                txt_msg.Invoke(new Action(() =>
                {
                    txt_msg.Text += "------------\r\n" + msg + "\r\n------------\r\n";
                }));
            }
            else
            {
                txt_msg.Text += "------------\r\n" + msg + "\r\n------------\r\n";
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_stop_Click(object sender, EventArgs e)
        {
            _over = true;
            this.lab_stop.ForeColor = Color.Red;
            this.lab_stop.Visible = false;
        }
    }


}
