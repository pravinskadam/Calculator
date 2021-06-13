 ---------------------------------------------------------------------------------------------------------------------------
|	Date:-		13-June-2021																								|
|	Author:-	Praveen Kadam																								|
 ---------------------------------------------------------------------------------------------------------------------------

Product:- Calculator
Version:- 1.0
-----------------------------------------------------------------------------------------
Intend:- Calculate a result from a set of instructions.

Requirement:-
	-- A instruction comprises a keywork and a number, separated by a space per line
	-- Any number of instructions can be given
	-- Instructions will be loaded from a file
	-- Allowed type of instructions are add, divide, multiply and subtract
	-- The last instruction in the file should be of type 'apply' and a number e.g., "apply 3"
	-- The 'apply' instruction triggers the calculator
	-- The number given along with 'apply' instruction is base number 
	-- All the previous instructions are then applied on the base number in ascending order
	-- Calculation does not consider mathematical precedence
	-- Result will be displayed on the screen

Assumptions:- 
	-- Only integer numbers are allowed
-----------------------------------------------------------------------------------------

Implementation:-
--------------------
1. Calculator.Client
	-- Console application for,
		-- reading operations from data file (data.txt: included in the client project)
		-- validating the operations given in the data file
		-- invokes calculator core service
		-- displays user-friendly messages
2. Calculator.Core
	-- Calculator logic component
	-- Processes the given data
	-- Calculates the final result
	
Unit Tests:-
1. Calculator.Client.Tests:- unit testing for calculator client application
2. Calculator.Core.Tests: unit testing for calculator core component

Additional Information:
	1. Data can be added in the give data.txt file 
	2. When application is running, you can edit data.txt from Client App's bin folder and re-run the another calculation
	3. Validation could be added at core level (not sure if it was expected)
---------------------------------------------------------------------------------------------------------------------------


 --------------------------------------	
|-------------- THANK YOU -------------|
 --------------------------------------