using NAVEmailApp.utils.function4;
using System.IO;
using Xunit;

namespace NAVEmailApp.Tests.IntegrationTests;

public class ReminderIntegrationTests
{
    [Fact]
    public void DisplayReminders_ShouldOutputCorrectText()
    {
        // Arrange
        var reminderService = new ReminderService();
        var reminderView = new ReminderView(reminderService);

        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        reminderView.DisplayReminders();

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Adóbevallási emlékeztetők", output);
        Assert.Contains("adóbevallása határideje", output);
    }
}