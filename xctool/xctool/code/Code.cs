using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;


namespace xctool
{
    public class Code
    {
        private Dictionary<string, List<Bitmap>> _bits = new Dictionary<string, List<Bitmap>>();
        private List<Bitmap> _cmap;
        private string _code = "";
        
        public string GetCode(Bitmap bitmap,Bitmap rbitmap)
        {
            var bnew = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bnew);
            g.DrawImage(bitmap, 0, 0);
            g.Dispose();
          
            //灰度化
            bnew = Grayscale.CommonAlgorithms.RMY.Apply(bnew);
            //二值化
            bnew = new Threshold(50).Apply(bnew);
            //反色
            bnew = new Invert().Apply(bnew);
            //去噪点 
            //bnew = new BlobsFiltering(3, 3, bnew.Width, bnew.Height).Apply(bnew);
            //连接区匹配
            ConnectedComponentsLabeling f = new ConnectedComponentsLabeling();
            f.Apply(bnew);
            //滤噪点
            Rectangle[] regs = f.BlobCounter.GetObjectsRectangles();
            Rectangle[] regs2 = regs.OrderByDescending(m => m.Size.Height).Take(4).ToArray();
            _cmap = new List<Bitmap>();
            foreach (Rectangle reg in regs2)
            {
                Bitmap rb = bitmap.Clone(reg, PixelFormat.Format24bppRgb);
                _code += Match(rb);
                _cmap.Add(rb);
            }
            
            //
            Graphics g2 = Graphics.FromImage(rbitmap);
            g2.DrawImage(bnew, 0, 0);
            g2.DrawRectangles(new Pen(Color.Red), regs2);
            g2.Dispose();

            return _code;
        }

        /// <summary>
        /// 增加经验
        /// </summary>
        /// <param name="result"></param>
        public void SetBit(string result)
        {
            char[] rs = result.ToCharArray();
            char[] cs = _code.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                if (rs[i] != cs[i])
                {
                    if (_bits.Keys.Contains(rs[i].ToString()))
                    {
                        _bits[rs[i].ToString()].Add(_cmap[i]);
                    }
                    else
                    { 
                        List<Bitmap> bl=new List<Bitmap>();
                        bl.Add(_cmap[i]);
                        _bits.Add(rs[i].ToString(), bl);
                    }
                }
            }
        }

        /// <summary>
        /// 匹配
        /// </summary>
        /// <returns></returns>
        private string Match(Bitmap bitmap)
        {
            Dictionary<string, float> dm = new Dictionary<string, float>();
            foreach (KeyValuePair<String, List<Bitmap>> dic in _bits)
            {
                foreach (Bitmap b in dic.Value)
                {
                    ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0);
                    // compare two images
                    TemplateMatch[] matchings = tm.ProcessImage(bitmap, b);
                    if (matchings.Length > 0)
                    {
                        if (matchings[0].Similarity < 9.0f)
                        {
                            dm.Add(dic.Key, matchings[0].Similarity);
                        }
                        else
                        {
                            return dic.Key;
                        }
                    }
                }
            }

            return dm.Count > 0 ? dm.OrderByDescending(m => m.Value).FirstOrDefault().Key : "#";
        }

    }


}
