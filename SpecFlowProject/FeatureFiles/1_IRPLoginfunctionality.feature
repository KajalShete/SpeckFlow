Feature: 1_IRPLoginfunctionality

Background: 
Given Open IRP Application
	
@IRPLoginFunctionalitySuccessful Login
Scenario: Test login functionality with valid data
    When the user enters valid userName
    When the user enters valid password
    And clicks the login button
    Then the user should redirected to the IRP home page
    Then click on logout button

@IRPLoginFunctionalityUnsuccessful Login
Scenario: Test login functionality with invalid data
    When I enter invalid userName
    When I enter invalid password
    And Click on login
    Then Dashboard page should not open

