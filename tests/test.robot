*** Settings ****


*** Test Cases ***
My Test case
	Tee jotain
	Tama ok


*** Keywords ***
Tee jotain
	Log	Log message
	
Tama ok
	Should Be Equal	2	2
	