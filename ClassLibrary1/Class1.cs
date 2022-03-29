using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Commands;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using System;
using System.Collections.Generic;

namespace ModerationSystem
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        
        [RocketCommand("eban", "Ban command", "", AllowedCaller.Player)]
        [RocketCommandPermission("ember.ban")]

        protected override void Load()
        {
            Instance = this;
            Logger.Log("Ember link system loaded", ConsoleColor.Red);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "Invalid-Player-Name", "!color=yellow¡Invalid Player Name!/color¡" },
            { "Reason", "!color=blue¡reason:!/color¡" },
            { "For", "!color=blue¡for:!/color¡" },
            { "Correct-Ban-Usage", "!color=yellow¡Ban command correct usage: /ban (player) (reason) (time)!/color¡" },
            { "Ban-Success1", "!color=blue¡Successfully banned:!/color>" },
            { "Invalid-Ban-Format", "!color=yellow¡Invalid Player Name or time!/color¡" },
        };

        protected override void Unload()
        {
            Instance = null;
        }
    }

    public class Command : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "eban";
        public string Help => "Bans player via ember";
        public string Syntax => "nothing || <player>/all";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "ember.ban" };

        public void Execute(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            var main = ModerationSystem.Main.Instance;
            var config = main.Configuration.Instance;


            if (UnturnedPlayer.FromName(args[1]) != null) {

                if (args[2] != null) {

                    if (args[3] != null) {
                        Functions.SendToSite(caller.Id, args[1], args[2], args[3]);

                        else {
                            Functions.SendToSite(caller.Id, args[1], args[2], "");
                        };
                    }
                    else {
                        Functions.SendToSite(caller.Id, args[1], "0", "");
                    };
                };



                else {
                    UnturnedChat.Say(caller, "Unable to find player");

                };
            };
        }
    }
}
