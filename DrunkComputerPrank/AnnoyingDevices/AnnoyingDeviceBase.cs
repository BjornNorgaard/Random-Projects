using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AnnoyingDevices
{
    public abstract class AnnoyDeviceFactory
    {
        AnnoyDevice annoyDevice;

        public AnnoyDeviceFactory()
        {
            annoyDevice = FactoryMethod();
        }

        public abstract AnnoyDevice FactoryMethod();
    }
}
