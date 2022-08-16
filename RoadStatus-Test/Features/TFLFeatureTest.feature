Feature: Road Status
	As a consumer I want to get the status of a given road id

Scenario: Valid Road ID to display road name
	Given a valid road ID is specified A10
	When the client is run
	Then the road displayName should be displayed


Scenario: Valid Road ID to display status severity
	Given a valid road ID is specified A10
	When the client is run
	Then the road statusSeverity should be displayed as Road Status

Scenario: Valid Road ID to display status severity description
	Given a valid road ID is specified A10
	When the client is run
	Then the road statusSeverityDescription should be displayed as Road Status Description

Scenario: In Valid Road ID to display an informative error
	Given a invalid road ID is specified A100
	When the client is run
	Then the application should return an informative error

Given a invalid road ID is specified A100
	When the client is run
	Then the application should exit with a non-zero System Error code