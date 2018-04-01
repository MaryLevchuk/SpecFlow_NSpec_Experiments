Feature: Search on RecipeOverview
	As a user I would like to search for recipes by name

Scenario: Enter search query
	Given RecipeOverview page is opened
	When I have entered 'cake' into the SearchField
	Then result should contain 'cake' in the title

	#Given RecipeOverview page is opened
	#When I have entered 'qwerty' into the SearchField
	#Then result should not contain recipes 
	#And show 'No products found' message
		