using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xctool.Model
{
    public class OrderInfo
    {
        private string techername;

        public string TecherName
        {
            get { return techername; }
            set { techername = value; }
        }
        private string techno;

        public string TechNo
        {
            get { return techno; }
            set { techno = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private int time;

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        private int timeline;

        public int Timeline
        {
            get { return timeline; }
            set { timeline = value; }
        }

        private string rowcolid;

        public string RowColId
        {
            get { return rowcolid; }
            set { rowcolid = value; }
        }

        private bool sucess;

        public bool Sucess
        {
            get { return sucess; }
            set { sucess = value; }
        }

        private float postfrequency;

        public float PostFrequency
        {
            get { return postfrequency; }
            set { postfrequency = value; }
        }


        /// <summary>
        /// 比较对象
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.rowcolid.GetHashCode();
        }

        /// <summary>
        ///用于比较对象 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            OrderInfo info = obj as OrderInfo;
            if (info != null)
            {
                if (info.GetHashCode() == this.GetHashCode())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
