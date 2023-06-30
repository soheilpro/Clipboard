using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Clipboard.GnuLinux;

internal class Clipboard : IClipboard
{
    public void SetText(string text)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text));
        RunInShell($"echo '{text}' | {ClipboardCopyCmd}");
    }

    public string GetText() => RunInShell(ClipboardPasteCmd);

    static string ClipboardCopyCmd => IsWsl ? "clip.exe" : "xsel -ib";

    static string ClipboardPasteCmd => IsWsl ? throw new NotSupportedException() : "xsel -b";

    static bool IsWsl => Environment.GetEnvironmentVariable("WSL_DISTRO_NAME") != null;

    /// <Summary>
    /// Credit to the CopyText project TextCopy
    /// </Summary>
    static string RunInShell(string commandLine)
    {
        StringBuilder errorBuilder = new();
        StringBuilder outputBuilder = new();
        var arguments = $"-c \"{commandLine}\"";
        using Process process = new()
        {
            StartInfo = new()
            {
                FileName = "bash",
                         Arguments = arguments,
                         RedirectStandardOutput = true,
                         RedirectStandardError = true,
                         UseShellExecute = false,
                         CreateNoWindow = false,
            }
        };
        process.Start();
        process.OutputDataReceived += (_, args) => { outputBuilder.AppendLine(args.Data); };
        process.BeginOutputReadLine();
        process.ErrorDataReceived += (_, args) => { errorBuilder.AppendLine(args.Data); };
        process.BeginErrorReadLine();
        if (!process.DoubleWaitForExit())
            throw new($"Process timed out. " +
                    $"Command line: bash {arguments}. Output: {outputBuilder} Error: {errorBuilder}");
        if (process.ExitCode == 0)
            return outputBuilder.ToString();
        throw new($"Could not execute process. " +
                $"Command line: bash {arguments}. Output: {outputBuilder} Error: {errorBuilder}");
    }

}

internal static class ProcessEx
{
    //To work around https://github.com/dotnet/runtime/issues/27128
    public static bool DoubleWaitForExit(this Process process)
    {
        var result = process.WaitForExit(500);
        if (result)
            process.WaitForExit();
        return result;
    }
}
