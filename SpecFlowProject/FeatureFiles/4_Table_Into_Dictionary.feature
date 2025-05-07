Feature: 4_Table_Into_Dictionary 
	In order to access my account
    As a user of the website
   I want to log into the website

@Table_Into_Dictionary
Scenario: Table_Into_Dictionary
	Given Navigate to LogIn Page
	When User Successfully Login and Log out
		| Username          | Password  |
		| kshete@symtrax.in | Kajal@123 |
		| sa                | Symtr4x!  |
		| sa                | Symtr4x!  |
		
