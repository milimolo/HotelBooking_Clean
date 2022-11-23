Feature: CreateBookingDoubleBooking

In order to avoid double booking
I cannot book a room that is already booked.
I cannot book a room when start date is later than end date.

@tag1
Scenario Outline: Double book a room
	Given I have typed a <startDate>
	And I have also typed a <endDate>
	When I use book room
	Then The booking result should be false

	Examples: 
	| startDate | endDate   |
	| 1			| 12		|
	| 11		| 24		|
