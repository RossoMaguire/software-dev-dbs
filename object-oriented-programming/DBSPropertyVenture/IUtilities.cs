using System;
using System.Collections.Generic;
using System.Text;

namespace DBSPropertyVenture
{
    public interface IUtilities
    {
        public void notNumberError();

        public void notOptionError();

        public string formatAddressOnNewLines(string addrToFormat);
    }
}
