# ValidationService
Data Validation Service

The Data Validation service is used to validate a schema of the data fetched from the given urls https://git.io/vpg9V and https://git.io/vpg95 against the schema provided . 

At the client end , there will be a form where there is an button to validate the schema of the data

When the validation is invoked , the WCF service contains a method to validate the data using some buili in JSON classes from the package Newtonsoft.Json. 

After the execution undergoes , the result willbe displayed in a message box i.e
a. The schema of the data is correct or not
b. Number of objects parsed
c. Number of null occurences
d. Number of parse errors
