## Framework
.NET 8

## Email Environment Variables

Emails are automatically disabled while debugging. 

Setup Azure Communication and set it as environment variable below. 
```bash
EMAIL_CONNECTION_STRING = Azure communication email connection string
EMAIL_SENDER_ADDRESS = email domain (you can setup a free one in Azure)
EMAIL_RECIPIENT = email address the notifications to be sent to.
```

## Usage
Generate an ID using the /generate route. Add it as environment variable and set candidate name as value. Then use route /[ID]/start to start app.
