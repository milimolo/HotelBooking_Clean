using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using System;
using TechTalk.SpecFlow;

namespace HotelBooking.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class CreateBookingDoubleBookingStepDefinitions
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

        public CreateBookingDoubleBookingStepDefinitions()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            FakeBookingRepository bookRepo = new FakeBookingRepository(start, end);
            FakeRoomRepository roomRepo = new FakeRoomRepository();
            bookingManager = new BookingManager(bookRepo, roomRepo);
        }

        [Given(@"I have typed a '([^']*)'")]
        public void GivenIHaveTypedA(string p0)
        {
            startDate = DateTime.Parse(p0);
        }

        [Given(@"I have also typed a '([^']*)'")]
        public void GivenIHaveAlsoTypedA(string p0)
        {
            endDate = DateTime.Parse(p0);
        }

        [When(@"I use book room")]
        public void WhenIUseBookRoom()
        {
            var booking = new Booking
            {
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

        [Then(@"The booking result should be false")]
        public void ThenTheBookingResultShouldBeFalse()
        {
            Assert.False(roomBooked);
        }
    }
}
