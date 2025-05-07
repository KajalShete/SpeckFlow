Feature: 2_DDT_WithSceanarioOutline 
@DataDrivenTest
  Scenario Outline: Passing Data Through Table
    Given I navigate to the IRP login page
    When I enter the following user credentials
      | Username   | Password   |
      | <username> | <password> |
    And I click the login button
    Then I should see the dashboard page

    Examples:
      | username          | password  |
      | kshete@symtrax.in | Kajal@123 |
      | sa                | Symtr4x!  |
     
      
