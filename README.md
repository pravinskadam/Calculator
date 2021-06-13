 --------------------------------------------------------------------------------------------------------------------------- <br/>
Date:-		13-June-2021	<br/>
Author:-	Praveen Kadam	<br/>
 --------------------------------------------------------------------------------------------------------------------------- <br/>
Product:- Calculator <br/>
Version:- 1.0 <br/>
-----------------------------------------------------------------------------------------<br/>
Intend:- Calculate a result from a set of instructions. <br/>

Requirement:- <br/>
	-- A instruction comprises a keywork and a number, separated by a space per line <br/>
	-- Any number of instructions can be given <br/>
	-- Instructions will be loaded from a file <br/>
	-- Allowed type of instructions are add, divide, multiply and subtract <br/>
	-- The last instruction in the file should be of type 'apply' and a number e.g., "apply 3" <br/>
	-- The 'apply' instruction triggers the calculator <br/>
	-- The number given along with 'apply' instruction is base number <br/>
	-- All the previous instructions are then applied on the base number in ascending order <br/>
	-- Calculation does not consider mathematical precedence <br/>
	-- Result will be displayed on the screen <br/>

Assumptions:- <br/>
	-- Only integer numbers are allowed <br/>
----------------------------------------------------------------------------------------- <br/>

Implementation:- <br/>
1. Calculator.Client <br/>
	-- Console application for, <br/>
		-- reading operations from data file (data.txt: included in the client project) <br/>
		-- validating the operations given in the data file <br/>
		-- invokes calculator core service <br/>
		-- displays user-friendly messages <br/>
2. Calculator.Core <br/>
	-- Calculator logic component <br/>
	-- Processes the given data <br/>
	-- Calculates the final result <br/>
	
Unit Tests:- <br/> 
1. Calculator.Client.Tests:- unit testing for calculator client application <br/>
2. Calculator.Core.Tests: unit testing for calculator core component <br/>

Additional Information: <br/>
	1. Data can be added in the give data.txt file <br/>
	2. When application is running, you can edit data.txt from Client App's bin folder and re-run another calculation <br/>
--------------------------------------------------------------------------------------------------------------------------- <br/>
<br/>
<br/>
-------------------------------------- <br/>
------------ THANK YOU ----------- <br/>
-------------------------------------- <br/>
