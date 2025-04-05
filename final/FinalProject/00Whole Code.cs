using System;
using System.Collections.Generic;

// Base class for event types
public abstract class CalendarEvent
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }

    public CalendarEvent(string title, DateTime date, string location)
    {
        Title = title;
        Date = date;
        Location = location;
    }

    public abstract void DisplayDetails();  // Abstract method for event display
}

// Derived class for Regular events
public class RegularEvent : CalendarEvent
{
    public RegularEvent(string title, DateTime date, string location)
        : base(title, date, location) { }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Regular Event: {Title} at {Location} on {Date.ToShortDateString()}");
    }
}

// Derived class for Meeting events
public class MeetingEvent : CalendarEvent
{
    public string Agenda { get; set; }

    public MeetingEvent(string title, DateTime date, string location, string agenda)
        : base(title, date, location)
    {
        Agenda = agenda;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Meeting Event: {Title} at {Location} on {Date.ToShortDateString()}\nAgenda: {Agenda}");
    }
}

// Class to manage the Calendar/Planner
public class Planner
{
    private List<CalendarEvent> events;

    public Planner()
    {
        events = new List<CalendarEvent>();
    }

    public void AddEvent(CalendarEvent calendarEvent)
    {
        events.Add(calendarEvent);
    }

    public void DisplayEvents()
    {
        foreach (var calendarEvent in events)
        {
            calendarEvent.DisplayDetails();
        }
    }

    public void SearchEventByTitle(string title)
    {
        foreach (var calendarEvent in events)
        {
            if (calendarEvent.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                calendarEvent.DisplayDetails();
            }
        }
    }

    public List<CalendarEvent> GetEventsForDay(DateTime day)
    {
        List<CalendarEvent> dailyEvents = new List<CalendarEvent>();
        foreach (var calendarEvent in events)
        {
            if (calendarEvent.Date.Date == day.Date)
            {
                dailyEvents.Add(calendarEvent);
            }
        }
        return dailyEvents;
    }
}

// Class to manage Users
public class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }

    public void CreateEvent(Planner planner, string title, DateTime date, string location, string agenda = null)
    {
        if (agenda == null)
        {
            planner.AddEvent(new RegularEvent(title, date, location));
        }
        else
        {
            planner.AddEvent(new MeetingEvent(title, date, location, agenda));
        }
    }

    public void ViewEvents(Planner planner)
    {
        planner.DisplayEvents();
    }

    public void SearchEvents(Planner planner, string title)
    {
        planner.SearchEventByTitle(title);
    }
}

// Abstract class for Notifications
public abstract class Notification
{
    public string Message { get; set; }

    public Notification(string message)
    {
        Message = message;
    }

    public abstract void SendNotification();
}

// Derived class for Email Notifications
public class EmailNotification : Notification
{
    public string EmailAddress { get; set; }

    public EmailNotification(string message, string emailAddress)
        : base(message)
    {
        EmailAddress = emailAddress;
    }

    public override void SendNotification()
    {
        Console.WriteLine($"Sending email to {EmailAddress} with message: {Message}");
    }
}

// Derived class for SMS Notifications
public class SMSNotification : Notification
{
    public string PhoneNumber { get; set; }

    public SMSNotification(string message, string phoneNumber)
        : base(message)
    {
        PhoneNumber = phoneNumber;
    }

    public override void SendNotification()
    {
        Console.WriteLine($"Sending SMS to {PhoneNumber} with message: {Message}");
    }
}

// Main class
class Program
{
    static void Main(string[] args)
    {
        // Create a new planner and a user
        Planner planner = new Planner();
        User user = new User("John Doe");

        // User creates some events
        user.CreateEvent(planner, "Project Meeting", DateTime.Now.AddDays(1), "Conference Room", "Discuss project milestones");
        user.CreateEvent(planner, "Birthday Party", DateTime.Now.AddDays(2), "Park");

        // View all events
        Console.WriteLine("All Events:");
        user.ViewEvents(planner);

        // Search for an event by title
        Console.WriteLine("\nSearch for 'Meeting':");
        user.SearchEvents(planner, "Meeting");

        // Notify the user about an event
        Console.WriteLine("\nSending Notifications:");
        EmailNotification email = new EmailNotification("Reminder: Your event is tomorrow!", "john.doe@example.com");
        email.SendNotification();

        SMSNotification sms = new SMSNotification("Reminder: Your event is tomorrow!", "123-456-7890");
        sms.SendNotification();

        // Display events for today
        Console.WriteLine("\nEvents for Today:");
        var eventsToday = planner.GetEventsForDay(DateTime.Now);
        foreach (var e in eventsToday)
        {
            e.DisplayDetails();
        }
    }
}
