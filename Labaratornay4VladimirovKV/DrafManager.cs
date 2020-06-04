using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labaratornay4VladimirovKV
{
    class DrafManager
    {
        public static Brush RandomColorBrush()
        {
            int R, G, B;
            var random = new Random();
            R = random.Next(0, 255);
            G = random.Next(0, 255);
            B = random.Next(0, 255);
            Brush brush = new SolidBrush(Color.FromArgb(R, G, B));
            return brush;
        }
    }
}
