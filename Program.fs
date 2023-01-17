open System
open System.Reflection
open Microsoft.Extensions.Configuration
open Twilio
open Twilio.Rest.Api.V2010.Account
open Twilio.Types

let configuration = ConfigurationBuilder()
                     .AddUserSecrets(Assembly.GetExecutingAssembly())
                     .Build()

let twilioAccountSid = configuration["Twilio:AccountSid"]
let twilioAuthToken = configuration["Twilio:AuthToken"]

printfn "Twilio Account SID: %s"
    (if String.IsNullOrEmpty(twilioAccountSid) then "[NOT CONFIGURED]" else twilioAccountSid)
printfn "Twilio Auth Token: %s"
    (if String.IsNullOrEmpty(twilioAuthToken) then "[NOT CONFIGURED]" else "[CONFIGURED]")
    
TwilioClient.Init(twilioAccountSid, twilioAuthToken)

let message = MessageResource.Create(
    from = PhoneNumber("[YOUR_TWILIO_PHONE_NUMBER]"),
    ``to`` = PhoneNumber("[YOUR_PERSONAL_PHONE_NUMBER]"),
    body = "Ahoy!"
)

printfn "Message sent"
printfn $"Message ID: {message.Sid}"