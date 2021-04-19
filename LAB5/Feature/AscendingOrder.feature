Feature: AscendingOrder
	Ascending order functionality.

@tag
Scenario: Perform ascending order in product page.
	Given I launch the application
	And I click on any product category
	And I enter click on sort by function
	And I select ascending sort Name(A-Z)
	Then I should see product page sorted in ascending way