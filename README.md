# ShoppingCart

## Quickstart
https://github.com/oddell/Shopping-Cart-Prototype/assets/66199940/14ea8885-013f-429f-8174-08538edd9c57

## Overview

The ShoppingCart application is developed in .NET Framework 4.7.2. The application includes the following functionalities:
- Add a single product to a basket
- Add multiple products to a basket
- See the total cost of my basket
- Apply a discount code and see the price before and after the discount

The solution is accompanied by an xUnit-based unit test with moq

## Future Improvements
Given more time I would
- Put the saleable items behind an API and store them in a database
- Expand the unit tests to higher coverage across more files and place them in their own project
- Use AutoMoq for future more complex objects and services
- Extract relevant business logic in viewmodels into singleton services
- Use the DI infrastructure to inject a logger and use in relevant places

## Expected Features
Beyond the scope of the task it would make sense to:
- Have items added to the basket be removable.
- Better validation for the quantity input
- Tidy up of UI
- Complete purchase functionality



