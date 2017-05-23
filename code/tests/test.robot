*** Settings ****
Library	StorageLibrary.py

*** Variables ***
${VAR}	1000

*** Test Cases ***
My Test case
	write storage point value	0	${VAR}
	${V1}=	read storage point value	0
	Should be equal	${V1}	${VAR}
Test write and read
	verify write and read	1	uusi arvo

*** Keywords ***
Tee jotain
	Log	Log message
	

	