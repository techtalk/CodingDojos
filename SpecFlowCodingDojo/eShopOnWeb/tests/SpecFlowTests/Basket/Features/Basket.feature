Feature: Add a product to a basket

#---------------------------------------------------------------------
# Write simple scenario with Feature/Steps/Driver pattern
#
#1. Generate the steps (right click -> generate step definitions -> choose the three used in the first test)
# or click F12 on each of three steps and manually copy them to BasketSteps.cs
# BasketSteps.cs will contain all the Bindings for Basket and will coordinate needed contexts and drivers
# BasketSteps class must be marked with attribute [Binding]

#2. Generate BasketDriver.cs and inject it through ctor of BasketSteps.cs
# Specflow DI will create the objects

#3. Generate the three methods in BasketDriver.cs and implement them using UserCommandHandler.cs
# UserCommandHandler should be injected to BasketDriver
#---------------------------------------------------------------------

Scenario: Add an item to an empty basket

	Given the basket of 'John Smith' is empty
	
	When 'John Smith' adds a 'Roslyn Red Sheet' to his basket

	Then the basket of 'John Smith' contains 'Roslyn Red Sheet'
	
#---------------------------------------------------------------------
# Share data in a test through context
#
#1. Generate CurrentUserContext class with a property "CurrentUserName"

#2. Generate and implement the step for "I am logged in as..."
# it's recommended to create it in a separate CurrentUserSteps and CurrentUserDriver
# as it will let us show how we can share data between different drivers

#3. create 3 new steps in BasketSteps.cs where username will be taken
# from CurrentUserContext (injected through ctor) instead of taking it from param
# same driver methods should be called
#---------------------------------------------------------------------
Scenario: Add an item to my basket

	Given I am logged in
		And my basket contains 'Prism White T-Shirt'
	
	When I add a 'Roslyn Red Sheet' to my basket

	Then my basket contains 'Roslyn Red Sheet, Prism White T-Shirt'
	

#---------------------------------------------------------------------
# Implicitely log in as a default user
# 
# Option 1:
# go to CurrentUserContext and set default value for CurrentUserName = "TestUser"
#
# Option 2:
# in the given step check if the CurrentUserName is set -  if not, log in
#---------------------------------------------------------------------
Scenario: Add an item to my basket with implicit logging in

	Given my basket contains 'Prism White T-Shirt'
	
	When I add a 'Roslyn Red Sheet' to my basket

	Then my basket contains 'Roslyn Red Sheet, Prism White T-Shirt'
	
#---------------------------------------------------------------------
# Pass complex parameters as Tables
# 
# 1. Create classes AddItemToBasketRow and AssertItemInBasketRow
# both classes should contain properties "Name" and "Amount"
#
# 2. Generate all three steps needed for this test
# they will have "Table" as the parameter. It will need to be converted
# 
# 3. Convert Table to our classes using extension methods
# createSet<>(), createInstance<>() or createSetValidated<>(), createInstanceValidated<>()
#
# 4. extend the existing methods to be able to work with "amount", too
#---------------------------------------------------------------------
@ignore
Scenario: Add an item to my basket (complex)

	Given my basket contains following products:
		| Name                | Amount |
		| Prism White T-Shirt | 1      |
	
	When I add the following product to my basket:
		| Name             | Amount |
		| Roslyn Red Sheet | 2      |

	Then my basket contains following products:
		| Name                | Amount |
		| Roslyn Red Sheet    | 2      |
		| Prism White T-Shirt | 1      |

#---------------------------------------------------------------------
# Automate conversion of Tables into classes
# 
# 1. Create a class StepArgumentTransformations with an attribute [Binding]
# Create methods converting Tables into our classes - each method needs a [StepArgumentTransformation] attribute
# 
# 2. Now instead of manually converting Table to classes in the steps,
# we can directly pass our classes as parameters
#---------------------------------------------------------------------
