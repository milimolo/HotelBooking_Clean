using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using System;
using TechTalk.SpecFlow;

namespace HotelBooking.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class CreateBookingBeforeTodayStepDefinitions
    {
        DateTime startDate, endDate;

        private IBookingManager bookingManager;

        Action act;

        public CreateBookingBeforeTodayStepDefinitions()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            FakeBookingRepository bookRepo = new FakeBookingRepository(start, end);
            FakeRoomRepository roomRepo = new FakeRoomRepository();
            bookingManager = new BookingManager(bookRepo, roomRepo);
        }

        [Given(@"The start date is '([^']*)'")]
        public void GivenTheStartDateIs(string p0)
        {
            startDate = DateTime.Parse(p0); ;
        }

        [Given(@"The end date is '([^']*)'")]
        public void GivenTheEndDateIs(string p0)
        {
            endDate = DateTime.Parse(p0);
        }

        [When(@"I book a room")]
        public void WhenIBookARoom()
        {
            act = () => bookingManager.FindAvailableRoom(startDate, endDate);
        }

        [Then(@"I should get an argumentException error")]
        public void ThenIShouldGetAnArgumentExceptionError()
        {
            Assert.Throws<ArgumentException>(act);
        }
    }
}
