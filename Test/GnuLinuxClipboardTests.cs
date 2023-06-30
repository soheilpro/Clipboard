using Xunit;

namespace Test;

public class GnuLinuxClipboardTests
{
    [Fact]
    public void TestSetText()
    {
        var clipboard = Clipboard.Clipboard.Default;
        clipboard.SetText("");
        Assert.Equal("\n\n", clipboard.GetText());
        clipboard.SetText("testing");
        Assert.Equal("testing\n\n", clipboard.GetText());
    }
}
