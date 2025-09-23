using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Template.Commands;

namespace Template.BasePlugin
{
	public partial class MapControls
	{
		[CommandHelper(0, "timeleft", CommandUsage.CLIENT_AND_SERVER)]
		[ConsoleCommand("timeleft", "Print the time left for the current map")]
		private void CommandTimeleft(CCSPlayerController player, CommandInfo commandInfo)
		{
			Timeleft.CommandTimeleft(player, commandInfo);
		}
	}
}
