using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using System;
using TechTalk.SpecFlow;

namespace HotelBooking.SpecFlowTests.StepDefinitions
{

    [Binding]
    public class CreateBookingStepDefinitions
    {
        DateTime startDate, endDate;

        private IBookingManager bookingManager;

        bool roomBooked;

        Room room = new Room
        {
            Id = 1,
            Description = "bam bam bam"
        };
        Customer customer = new Customer
        {
            Id = 1,
            Email = "bambam@gmail.dk",
            Name = "John Bam"
        };

        public CreateBookingStepDefinitions()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            FakeBookingRepository bookRepo = new FakeBookingRepository(start, end);
            FakeRoomRepository roomRepo = new FakeRoomRepository();
            bookingManager = new BookingManager(bookRepo, roomRepo);
        }

        [Given(@"I have entered a (.*)")]
        public void GivenIHaveEnteredA(int p0)
        {
            startDate = DateTime.Today.AddDays(p0);
        }

        [Given(@"I have also entered a (.*)")]
        public void GivenIHaveAlsoEnteredA(int p0)
        {
            endDate = DateTime.Today.AddDays(p0);
        }

        [When(@"I press book room")]
        public void WhenIPressBookRoom()
        {
            
            var booking = new Booking{
                Id = 1,
                Customer = customer,
                CustomerId = 1,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = true,
                Room = room,
                RoomId = 1,
            };
            roomBooked = bookingManager.CreateBooking(booking);
        }
        [Then(@"The result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            Assert.True(roomBooked);
        }
    }
}
