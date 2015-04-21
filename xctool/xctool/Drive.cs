using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPTable.Models;
using XPTable.Events;
using xctool.Service;
using xctool.Model;

namespace xctool
{
    public partial class Drive : UserControl
    {

        DriveService _driveService = new DriveService();
        DataTable _dt;
        Dictionary<string, Cell> _sel = new Dictionary<string, Cell>();
        string _queryDate;
        string _driveType;

        /// <summary>
        /// 初始化
        /// </summary>
        public Drive()
        {
            InitializeComponent();

            //
            panel_msg.Width = flowLayoutPanel.Width - panel_query.Width - 15;
            
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drive_Load(object sender, EventArgs e)
        {
            btn_query.Enabled = false;
            //选中事件
            xptable.CellCheckChanged += new XPTable.Events.CellCheckBoxEventHandler(new Action<object, CellCheckBoxEventArgs>((obj, args) =>
            {
                if (args.Cell.Data != null)
                {
                    if (args.Cell.Checked)
                    {
                        _sel.Add(args.Cell.Data.ToString(), args.Cell);
                    }
                    else
                    {
                        if (_sel.ContainsKey(args.Cell.Data.ToString()))
                        {
                            _sel.Remove(args.Cell.Data.ToString());
                        }
                    }
                }
            }));

            //
            DriveInit();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void DriveInit()
        {
            ShowMsg("开始初始化数据......");
            //初始化数据源
            _driveService.Init(() => { this.Invoke(new Action(() => { ShowMsg("数据初始化完成！"); this.btn_query.Enabled = true; })); },
                               error => { if (MessageBox.Show(error,"大哥,服务器不叼你，还继续试么？", MessageBoxButtons.OKCancel) == DialogResult.OK) DriveInit(); else Application.Exit(); });
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            ShowMsg("开始加载查询数据....."); 
            xptable.Clear();
            _sel.Clear();
            _queryDate= datepicker.Value.ToString("yyy-MM-dd");
            _driveType = GetDriveType();
            bool hasNewDate = false;
            _driveService.Query(_driveType, _queryDate, new Action<DataTable, bool>((m, istech) =>
            {
                #region 成功返回
            
                _dt = m;
                //对当前时间的支持
                if (istech)
                {
                    string maxdate = _dt.Rows[_dt.Rows.Count - 1][2].ToString();
                    maxdate = maxdate.Substring(0, 10);
                    if ((Convert.ToDateTime(_queryDate) - Convert.ToDateTime(maxdate)).Days > 0)
                    {
                        DataRow dr = _dt.NewRow();
                        foreach (DataColumn col in _dt.Columns)
                        {
                            if (col.ColumnName == "教练员" || col.ColumnName == "车型" || col.ColumnName == "教练号" || col.ColumnName == "日期")
                                dr[col.ColumnName] = _dt.Rows[_dt.Rows.Count - 1][col.ColumnName];
                            else
                                dr[col.ColumnName] = "yunyue";
                        }
                        dr[2] = _queryDate;
                        _dt.Rows.Add(dr);
                        hasNewDate = true;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    xptable.BeginUpdate();
                    List<Column> cols = new List<Column>();
                    foreach (DataColumn col in m.Columns)
                    {
                        if (col.ColumnName == "教练员" || col.ColumnName == "车型" || col.ColumnName == "教练号" || col.ColumnName == "日期")
                            cols.Add(new TextColumn(col.ColumnName, col.ColumnName == "日期" ? 150 : col.ColumnName == "教练号" ? 100 : 80));
                        else
                            cols.Add(new CheckBoxColumn(col.ColumnName, null, 75, true));
                    }
                    xptable.ColumnModel = new ColumnModel(cols.ToArray());

                    //
                    List<Row> rows = new List<Row>();
                    int r = 0;
                    foreach (DataRow dr in m.Rows)
                    {
                        List<Cell> cells = new List<Cell>();
                        int c = 0;
                        foreach (DataColumn col in m.Columns)
                        {
                            string value = dr[col.ColumnName].ToString();
                            if (value == "yunyue")
                            {
                                Cell cell = new Cell("可预约", false, Color.Black, Color.Red, new Font("宋体", 12, FontStyle.Bold));
                                cell.Data = r + "|" + c;
                                cells.Add(cell);
                            }
                            else
                            {
                                if (col.ColumnName == "教练员" || col.ColumnName == "车型" || col.ColumnName == "教练号" || col.ColumnName == "日期")
                                {
                                    cells.Add(new Cell(value, false, Color.Black, ((hasNewDate && (r == _dt.Rows.Count - 1)) ? Color.AliceBlue : Color.Transparent), new Font("宋体", 12, FontStyle.Regular)));
                                }
                                else
                                {
                                    cells.Add(new Cell(value, false, Color.Gray, Color.Transparent, new Font("宋体", 10, FontStyle.Italic)));
                                }
                            }
                            c++;
                        }

                        Row row = new Row(cells.ToArray());
                        rows.Add(row);
                        r++;
                    }
                    TableModel table = new TableModel(rows.ToArray());
                    table.RowHeight = 30;
                    xptable.TableModel = table;
                    xptable.EndUpdate();
                }));

                //
                ShowMsg("加载数据完成......");
                #endregion
            }),
            error => {
                if (MessageBox.Show(error,"大哥,服务器不叼你，还继续试么？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    btn_query_Click(sender, e);
                }
            });
        }

        /// <summary>
        /// 得到类型
        /// </summary>
        /// <returns></returns>
        private string GetDriveType()
        {
            if (rbtn_cn.Checked)
            {
                return rbtn_cn.Text;
            }
            else if (rbtn_cw.Checked)
            {
                return rbtn_cw.Text;
            }
            else if (rbtn_df.Checked)
            {
                return rbtn_df.Text;
            }
            else if (rbtn_kh.Checked)
            {
                return rbtn_kh.Text;
            }
            else if (rbtn_zc.Checked)
            {
                return rbtn_zc.Text;
            }
            else
            {
                return rbtn_cn.Text;
            }
        }

        /// <summary>
        /// 返回需要预约的列表
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> GetOrderList()
        {
            List<OrderInfo> infolist = new List<OrderInfo>();
            foreach (string key in _sel.Keys)
            {
                string[] rcs=key.Split('|');
                int row = Convert.ToInt32(rcs[0]);
                int col = Convert.ToInt32(rcs[1]);
                OrderInfo info = new OrderInfo();
                info.Date = _queryDate;
                info.Type = _driveType;
                info.TecherName = _dt.Rows[row][0].ToString();
                info.TechNo = _dt.Rows[row][_dt.Columns.Count - 1].ToString();
                info.Time = Convert.ToInt32(_dt.Columns[col].ColumnName.Substring(0, 2));
                info.Timeline = (info.Time < 18) ? info.Time + 1 : info.Time + 2;
                info.RowColId = key;
                infolist.Add(info);
            }
            return infolist;
        }

        /// <summary>
        /// 设置预定成功
        /// </summary>
        /// <returns></returns>
        public void SetOrderSuccess(OrderInfo info)
        {
            if (_sel.ContainsKey(info.RowColId))
            {
                xptable.BeginUpdate();
                _sel[info.RowColId].BackColor = Color.Green;
                xptable.EndUpdate();
            }
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        public void SetState(bool queryable)
        {
            btn_query.Enabled = queryable;
        }

        //
        private void Drive_Resize(object sender, EventArgs e)
        {
            //
            panel_msg.Width = flowLayoutPanel.Width - panel_query.Width - 15;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            if (lab_msg.InvokeRequired)
            {
                lab_msg.Invoke(new Action(() =>
                {
                    lab_msg.Text = msg;
                }));
            }
            else
            {
                lab_msg.Text = msg;
            }
        }

    }
}
