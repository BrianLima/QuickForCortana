using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.VoiceCommands;

namespace CortanaCanvas
{
    public sealed class Service : XamlRenderingBackgroundTask
    {
        private BackgroundTaskDeferral serviceDeferral;
        VoiceCommandServiceConnection voiceServiceConnection;

        protected override async void OnRun(IBackgroundTaskInstance taskInstance)
        {
            this.serviceDeferral = taskInstance.GetDeferral();

            var triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;

            // get the voiceCommandServiceConnection from the tigger details
            voiceServiceConnection = VoiceCommandServiceConnection.FromAppServiceTriggerDetails(triggerDetails);

            VoiceCommand voiceCommand = await voiceServiceConnection.GetVoiceCommandAsync();

            VoiceCommandResponse response;

            // switch statement to handle different commands
            switch (voiceCommand.CommandName)
            {
                case "sendMessage":
                    // get the message the user has spoken
                    var message = voiceCommand.Properties["message"][0];
                    //var bot = new Bot();

                    // get response from bot
                    string firstResponse = "";
                        //await bot.SendMessageAndGetResponseFromBot(message);

                    // create response messages for Cortana to respond
                    var responseMessage = new VoiceCommandUserMessage();
                    var responseMessage2 = new VoiceCommandUserMessage();
                    responseMessage.DisplayMessage =
                        responseMessage.SpokenMessage = firstResponse;
                    responseMessage2.DisplayMessage =
                        responseMessage2.SpokenMessage = "did you not hear me?";

                    // create a response and ask Cortana to respond with success
                    response = VoiceCommandResponse.CreateResponse(responseMessage);
                    await voiceServiceConnection.ReportSuccessAsync(response);

                    break;
            }

            if (this.serviceDeferral != null)
            {
                //Complete the service deferral
                this.serviceDeferral.Complete();
            }

        }
    }
}
