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
            Thread.Sleep(1000);
            MessageBox.Show("Dette er Sørens USB stick!", "Important message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
