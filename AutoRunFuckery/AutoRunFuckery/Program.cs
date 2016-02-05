using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRunFuckery
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(2000);
            MessageBox.Show("Something something, it works!", "Caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
