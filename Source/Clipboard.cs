using System;
using System.Runtime.InteropServices;

namespace Clipboard
{
    public class Clipboard
    {
        private static IClipboard _default = CreateClipboard();

        public static IClipboard Default
        {
            get
            {
                return _default;
            }
        }

        private Clipboard()
        {
        }

        private static IClipboard CreateClipboard()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new Windows.Clipboard();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return new OSX.Clipboard();

            return new NotSupported.Clipboard();;
        }
    }
}
