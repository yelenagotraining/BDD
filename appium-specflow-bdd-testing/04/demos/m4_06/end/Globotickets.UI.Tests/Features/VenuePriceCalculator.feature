Feature: Venue price calculator
	Calculator for estimating the total cost of renting a venue

Background: 
	Given Jim has opened the Globotickets application
	
Scenario: Jim is presented with venue options
	When Jim clicks on the venue picker
	Then the venues should be present
	  | venues        |
	  | City Hall     |
	  | Main Building |
	  | Retro Lounge  |

Scenario: Jim enters number of guests that is above the limit
	Given the City Hall venue option is selected
	When Jim enters 201 for the number of guests
	And clicks on the calculate button
	Then the validation message "Selected venue cannot accept the desired number of guests." is displayed.

