Feature: CreateBooking

A short summary of the feature

@tag1
Scenario Outline: Book a room
	Given I have entered a <startDate>
	And I have also entered a <endDate>
	When I press book room
	Then the result should be <isBooked>

	Examples: 
	| startDate		| endDate		| isBooked	|
	| '2022-11-03'	| '2022-11-04'	| false		|
	| '2022-11-03'	| '2022-11-15'	| true		|
