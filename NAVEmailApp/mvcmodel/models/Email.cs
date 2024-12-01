using System;

namespace NAVEmailApp.mvcmodel;

public record Email
{
    public Email(string Sender, string[] Recipients, string Subject, DateTime Date, string Message)
    {
        if (Recipients.Length > 2000)
        {
            throw new ArgumentException("A single email can only have up to 2,000 recipients");
        }
        this.Sender = Sender;
        this.Recipients = Recipients;
        this.Subject = Subject;
        this.Date = Date;
        this.Message = Message;
    }

    public string Sender { get; set; }
    public string[] Recipients { get; set; }
    public string Subject { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
}