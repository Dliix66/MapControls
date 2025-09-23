using System.Text;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using Template.Tools;
using MapControls = Template.BasePlugin.MapControls;

namespace Template.Commands
{
	public static class Timeleft
	{
		public static void CommandTimeleft(CCSPlayerController playerController, CommandInfo commandInfo)
		{
			StringBuilder builder = new("Timeleft: ");
			bool hasTimeLimit = TimeHelper.MapHasTimeLimit();
			bool hasRoundLimit = TimeHelper.MapHasRoundLimit();

			if (hasTimeLimit)
			{
				float timeLeft = TimeHelper.GetRemainingTime();
				int seconds = (int)timeLeft % 60;
				int minutes = (int)timeLeft / 60;
				int hours = minutes / 60;

				if (hours > 0)
					builder.Append($"{hours}:");
				builder.Append($"{minutes}:{seconds:00}");

				if (hasRoundLimit)
					builder.Append(" OR ");
			}

			if (hasRoundLimit)
			{
				float roundsLeft = TimeHelper.GetRemainingRounds();
				builder.Append($"{roundsLeft:0}");
			}

			if (hasTimeLimit == false && hasRoundLimit == false)
				builder.Append("No limit");

			string strResult = builder.ToString();

			bool calledFromServer = playerController == null || playerController.IsValid == false;
			bool isConsoleCommand = commandInfo.CallingContext == CommandCallingContext.Console;
			bool printToAllChat = MapControls.Instance.Config.timeleftPrintToAllChat;

			if (calledFromServer || isConsoleCommand || printToAllChat == false)
			{
				commandInfo.ReplyToCommand(strResult);
			}

			if (printToAllChat)
				Server.PrintToChatAll(strResult);
		}
	}
}
