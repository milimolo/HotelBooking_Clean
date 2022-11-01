Feature: CreateBookingBeforeToday

When I book a room before today
I should get an argumentException error.

@tag1
Scenario: Book room before today
	Given The start date is '2022-10-31'
	And The end date is '2022-11-06'
	When I book a room
	Then I should get an argumentException error
