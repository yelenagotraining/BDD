Feature: Venue price calculator
	Calculator for estimating the total cost of renting a venue

Scenario: Jim is presented with venue options
	Given Jim has opened the Globotickets application
	When Jim clicks on the venue picker
	Then the City Hall option should be present
	And the Main Building option should be present
	And the Retro Lounge option should be present
	
Scenario: Jim enters number of guests that is above the limit
	Given Jim has opened the Globotickets application
	And the City Hall venue option is selected
	When Jim enters 201 for the number of guests
	And clicks on the calculate button
	Then the validation message "Selected venue cannot accept the desired number of guests." is displayed.

