using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
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

using Logger = Rocket.Core.Logging.Logger;

namespace ModerationSystem
{
	public class Functions
	{
		public static Main Instance;
		private static readonly Dictionary<string, string> p = new Dictionary<string, string> { { "Authorization", "Bearer " + Main.Instance.Configuration.Instance.Token }, { "Accept", "application/json" } };

		public static void SendToSite(string AdminSteamId, string offenderSteamid, string expiryMinutes, string reason)
		{
			var adminStr = "";
			if (AdminSteamId != null)
			{
				adminStr = "&admin_steamid=" + AdminSteamId;
			};
			var token = Main.Instance.Configuration.Instance.Token;
			var website = Main.Instance.Configuration.Instance.url;
			var Arg1Concentration = website + "/api/server/users/" + offenderSteamid + "/bans";
			var Arg2Concentration = "global=true&" + "expiry_minutes=" + expiryMinutes + "&reason=" + reason + adminStr;

			var SQLHost = Main.Instance.Configuration.Instance.SQLHost;
			var SQLPort = Main.Instance.Configuration.Instance.SQLPort;
			var SQLUser = Main.Instance.Configuration.Instance.SQLUser;
			var SQLPassword = Main.Instance.Configuration.Instance.SQLPassword;
			var SQLDatabase = Main.Instance.Configuration.Instance.SQLDatabase;

			string connetionString;
			SqlConnection cnn;
			connetionString = @"Data Source=" + SQLHost + ";Initial Catalog=" + SQLDatabase + ";User ID=" + SQLUser + ";Password=" + SQLPassword;
            cnn = new SqlConnection(connetionString);
			cnn.Open();

			string query = "INSERT INTO bans (id, scope, server_id, offender_user_id, created,  expires, reason, admin_user_id) VALUES (1, global, " + offenderSteamid + "," + System.DateTime.Now.ToLongDateString() + ", " + expiryMinutes + "," + reason + ", " + AdminSteamId+ ")";

			SqlCommand myCommand = new SqlCommand(query, cnn);

			myCommand.ExecuteNonQuery();

			cnn.Close();
		}
	}
}