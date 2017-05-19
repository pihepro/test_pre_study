*** Settings ****


*** Test Cases ***
My Test case
	Tee jotain
	Tama failaa


*** Keywords ***
Tee jotain
	Log	Log message
	
Tama failaa
	Should Be Equal	2	2
	