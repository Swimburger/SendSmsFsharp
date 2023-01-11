open System.Reflection
open Microsoft.Extensions.Configuration
open Twilio
open Twilio.Rest.Api.V2010.Account
open Twilio.Types

let configuration =
    ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build()

let twilioAccountSid = configuration["Twilio:AccountSid"]
let twilioAuthToken = configuration["Twilio:AuthToken"]

TwilioClient.Init(twilioAccountSid, twilioAuthToken)

MessageResource.Create(
    from = PhoneNumber("[YOUR_TWILIO_PHONE_NUMBER]"),
    ``to`` = PhoneNumber("[YOUR_PERSONAL_PHONE_NUMBER]"),
    body = "Ahoy!"
)
|> ignore
