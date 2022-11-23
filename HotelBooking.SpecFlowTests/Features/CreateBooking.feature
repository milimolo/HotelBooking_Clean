Feature: CreateBooking

In order to book.
I can book a room that is available.

@tag1
Scenario Outline: Book a room
	Given I have entered a <startDate>
	And I have also entered a <endDate>
	When I press book room
	Then The result should be true

	Examples: 
	| startDate	| endDate	|
	| 1			| 2			|
	| 21		| 23		|
