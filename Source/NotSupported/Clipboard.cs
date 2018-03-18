using System;
using System.Runtime.InteropServices;

namespace Clipboard.NotSupported
{
    internal class Clipboard : IClipboard
    {
        public void SetText(string text)
        {
            throw new NotSupportedException();
        }
    }
}
