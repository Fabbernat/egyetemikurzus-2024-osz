using System.Diagnostics;
using Xunit;

namespace NAVEmailApp.Tests.SystemTests;

public class SystemTests
{
    [Fact]
    public void Main_ShouldRunAndAcceptUserInput()
    {
        // Arrange
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "NAVEmailApp.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        };

        using var process = new Process { StartInfo = processStartInfo };
        process.Start();

        using var writer = process.StandardInput;
        writer.WriteLine("4"); // Choose Adóbevallási emlékeztető

        // Act
        process.WaitForExit();

        // Assert
        var output = process.StandardOutput.ReadToEnd();
        Assert.Contains("Adóbevallási emlékeztetők", output);
    }
}