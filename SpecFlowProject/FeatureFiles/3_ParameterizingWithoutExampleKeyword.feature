Feature: 3_ParameterizingWithoutExampleKeyword

Background: 
Given Open IRP Application Login page
	
@ParameterazingWithoutExampleKeySuccessful Login
Scenario: Demo of Prameterizing Without Example Keyword
    When the user enters valid 'kshete@symtrax.in' and 'Kajal@123' 
    And click the login button
    Then the user should navigate to the IRP home page
    And click on logout button to exit from IRP Application