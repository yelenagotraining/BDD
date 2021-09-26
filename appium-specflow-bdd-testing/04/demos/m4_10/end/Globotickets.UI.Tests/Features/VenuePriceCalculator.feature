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
	
	Scenario Outline: Jim calculates venue costs
		When Jim enters <numberOfGuests> for the number of guests
		And Jim clicks on the venue picker
		And selects <venue> option for the Venue
		And Jim clicks on the service level picker
		And selects <levelOfService> option for the Service Level
		And clicks on the calculate button
		Then the result "<result>" is displayed.
	
		Examples: 
		  | venue         | numberOfGuests | levelOfService | result                  |
		  | City Hall     | 150            | Basic          | Total cost is: $17500.0 |
		  | Main Building | 300            | Premium        | Total cost is: $50000.0 |
		  | Retro Lounge  | 500            | Basic          | Total cost is: $57000.0 |

	@SharedSteps
	Scenario: Jim calculates total cost of renting a venue with a random number of guests
		Given the City Hall venue option is selected
		And Jim has chosen a random number of guests
		When Jim enters randomly chosen number of guests
		And clicks on the calculate button
		Then the calculated result should be correct