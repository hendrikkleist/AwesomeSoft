// See https://aka.ms/new-console-template for more information
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.FrontEnd.Core;

PeopleEndpoints peopleEndpoints = new PeopleEndpoints();
MeetingRoomEndpoints meetingRoomEndpoints = new MeetingRoomEndpoints();
BookingEndpoints bookingEndpoints = new BookingEndpoints();


var running = true;

while (running)
{
    Console.WriteLine("1. Populate people");
    Console.WriteLine("2. Populate meeting rooms");
    Console.WriteLine("3. Schedule for all rooms");
    Console.WriteLine("4. Choose person and see options");
    Console.WriteLine("q or Q quit");
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();
    if (choice.Trim().StartsWith('1'))
    {
        await PopulatePeopleAsync();
    }
    else if (choice.Trim().StartsWith('2'))
    {
        await PopulateMeetingRoomsAsync();
    }
    else if (choice.Trim().StartsWith('3'))
    {
        await ShowAllMeetingRooms();
    }
    else if (choice.Trim().StartsWith('4'))
    {
        var peopleList = await ShowAllPeople();
        Console.Write("Choose person id:");
        var personId = Console.ReadLine();
        var person = peopleList.First(x => x.Id == int.Parse(personId));


        Console.WriteLine("1: Show bookings");
        Console.WriteLine("2: Book a room");
        choice = Console.ReadLine();
        if (choice.Trim().StartsWith('1'))
        {
            var personalBookings = await peopleEndpoints.GetBookings(person);
            foreach (var booking in personalBookings)
            {
                Console.WriteLine($"ID: {booking.Id}, Day: {booking.Day}, Meeting room: {booking.MeetingRoom}, Slot: {booking.SlotIndex}, ");
            }
        }
        await CreateBooking(meetingRoomEndpoints, bookingEndpoints, person);

    }
    else if (choice.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        running = false;
    }
}

string GetDayFromNumber(string? day)
{
    switch (day)
    {
        case "0": return "Monday";
        case "1": return "Tuesday";
        case "2": return "Wednesday";
        case "3": return "Thursday";
        case "4": return "Friday";
        default: return "Monday";
    }
}

async Task<List<Person>> ShowAllPeople()
{
    var people = await peopleEndpoints.GetPeople();
    for (int i = 0; i < people.Count; i++)
    {
        Console.WriteLine($"Id: {people[i].Id}: {people[i].FirstName} {people[i].LastName}");
    }
    return people;
}

async Task ShowAllMeetingRooms()
{
    var meetingRooms = await meetingRoomEndpoints.GetMeetingRooms();
    foreach (var meetingRoom in meetingRooms)
    {
        var result = await bookingEndpoints.GetScheduleForRoom(meetingRoom.Id);
        Console.WriteLine($"Meeting room {meetingRoom.RoomNumber}");
        Console.WriteLine("Monday");
        foreach (var item in result.Monday)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Tuesday");

        foreach (var item in result.Tuesday)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Wednesday");

        foreach (var item in result.Wednesday)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Thursday");

        foreach (var item in result.Thursday)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Friday");

        foreach (var item in result.Friday)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

    }
}

var people = await peopleEndpoints.GetPeople();

foreach (var person in people)
{
    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
}


async Task PopulatePeopleAsync()
{
    await peopleEndpoints.CreatePerson(1, "Hendrik", "Kleist");
    await peopleEndpoints.CreatePerson(2, "Liam", "Kleist");
    await peopleEndpoints.CreatePerson(3, "Lauge", "Kleist");
}

async Task PopulateMeetingRoomsAsync()
{
    await meetingRoomEndpoints.CreateMeetingRoom(new MeetingRoom() { Id = 1, RoomNumber = 1 });
    await meetingRoomEndpoints.CreateMeetingRoom(new MeetingRoom() { Id = 2, RoomNumber = 2 });
    await meetingRoomEndpoints.CreateMeetingRoom(new MeetingRoom() { Id = 3, RoomNumber = 3 });
    await meetingRoomEndpoints.CreateMeetingRoom(new MeetingRoom() { Id = 4, RoomNumber = 4 });
}

async Task CreateBooking(MeetingRoomEndpoints meetingRoomEndpoints, BookingEndpoints bookingEndpoints, Person person)
{
    Console.WriteLine("0 for Monday");
    Console.WriteLine("1 for Tuesday");
    Console.WriteLine("2 for Wednesday");
    Console.WriteLine("3 for Thursday");
    Console.WriteLine("4 for Friday");
    Console.Write("Enter day:");
    var day = Console.ReadLine();
    var dayAsString = GetDayFromNumber(day);
    var meetingRooms = await meetingRoomEndpoints.GetMeetingRooms();
    foreach (var meetingRoom in meetingRooms)
    {
        Console.WriteLine($"Id: {meetingRoom.Id}");
    }
    Console.Write("Choose room id:");
    var meetingRoomId = Console.ReadLine();
    var bookingMeetingRoom = meetingRooms.First(x => x.Id == int.Parse(meetingRoomId));
    Console.WriteLine("Slot 0 for 8 to 9");
    Console.WriteLine("Slot 1 for 9 to 10");
    Console.WriteLine("Slot 2 for 10 to 11");
    Console.WriteLine("Slot 3 for 11 to 12");
    Console.WriteLine("Slot 4 for 12 to 13");
    Console.WriteLine("Slot 5 for 13 to 14");
    Console.WriteLine("Slot 6 for 13 to 15");
    Console.WriteLine("Slot 7 for 15 to 16");
    Console.Write("Choose slot:");
    var slot = Console.ReadLine();
    var booking = new Booking()
    {
        Day = dayAsString,
        SlotIndex = int.Parse(slot),
        BookerId = person.Id,
        Booker = person,
        MeetingRoomId = int.Parse(meetingRoomId),
        MeetingRoom = bookingMeetingRoom
    };
    if (await bookingEndpoints.CreateBooking(booking))
    {
        Console.WriteLine("Booking created");
    }
    else
    {
        Console.WriteLine("Booking not created");
    }
}