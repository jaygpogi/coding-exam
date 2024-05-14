## Framework
.NET 8

## Email Environment Variables

Emails are automatically disabled while debugging. 

Setup Azure Communication and set it as environment variable:

EMAIL_CONNECTION_STRING = Azure communication email connection string
EMAIL_SENDER_ADDRESS = email domain (you can setup a free one in Azure)
EMAIL_RECIPIENT = email address the notifications to be sent to.

## Generate ID for candidate session
Generate an ID using the /generate route. Add it as environment variable and set candidate name as value. Then use route /[ID]/start to start app. This ID will be the session pass for the candidate. App has localStorage restrictions on validating resubmissions but users can still access the app if he clears localStorage or on another browser as long as this ID is in environment variables. So remove it when the candidate is finished.

## Instructions
Set instructions in Instructions.txt. This will be parsed per line and will be displayed on start page.

## Codes
Code methods can be configured in Codes.txt. Methods should be static and accepts and returns string. Multiple methods are separated by #SPLIT#. And the editable part should be enclosed with #EDITABLE#. 
```
public static string Method1(string input)
{
   #EDITABLE#
   // this is what the candidate can edit
   #EDITABLE#
}
#SPLIT#
public static string Method2(string input)
{
   #EDITABLE#
   // this is what the candidate can edit
   #EDITABLE#
}
```

## Tests
As of the moment, the tests module only accepts and returns string parameters. To add a test, configure it per line in Tests.txt in this format:
```
RunTest([method name], "[test data]", "[expected result]", output);
```

