using System;
using System.Runtime.InteropServices;

namespace Clipboard
{
    public interface IClipboard
    {
        void SetText(string text);
    }
}
