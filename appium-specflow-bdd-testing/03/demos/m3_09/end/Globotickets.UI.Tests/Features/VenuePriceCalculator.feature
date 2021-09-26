Feature: Venue price calculator
	Calculator for estimating the total cost of renting a venue

Scenario: Jim is presented with venue options
	Given Jim has opened the Globotickets application
	When Jim clicks on the venue picker
	Then the City Hall option should be present
	And the Main Building option should be present
	And the Retro Lounge option should be present