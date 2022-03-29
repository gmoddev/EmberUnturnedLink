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
            { "Correct-Kick-Usage", "!color=yellow¡Kick command correct usage: /kick (player) (reason)!/color¡" },
            { "Kick-Success1", "!color=blue¡Successfully kicked:!/color¡" },
            { "Reason", "!color=blue¡reason:!/color¡" },
            { "For", "!color=blue¡for:!/color¡" },
            { "Correct-Ban-Usage", "!color=yellow¡Ban command correct usage: /ban (player) (reason) (time)!/color¡" },
            { "Ban-Success1", "!color=blue¡Successfully banned:!/color>" },
            { "Invalid-Ban-Format", "!color=yellow¡Invalid Player Name or time!/color¡" },
        };
        
        public void eban(IRocketPlayer caller, string[] command)
        {
            var player = (UnturnedPlayer)caller;
            Logger.Log(command[1]);
            Logger.Log(command[0]);
            Logger.Log(command[2]);
        }
        protected override void Unload()
        {
            Instance = null;
        }
    }
}
