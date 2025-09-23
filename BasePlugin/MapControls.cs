using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Utils;

namespace Template.BasePlugin;

public partial class MapControls: CounterStrikeSharp.API.Core.BasePlugin
{
	public override string ModuleName => $"{nameof(MapControls)}";
	public override string ModuleVersion => "1.0.0";
	public override string ModuleAuthor => "Dliix66";
	public override string ModuleDescription => "Simple plugin to enable maps commands like RTV, nominate, votemap, nextmap, timeleft...";

	public static MapControls Instance { get; private set; } = null!;

	public override void Load(bool hotReload)
	{
		Instance = this;

		base.Load(hotReload);

		Server.PrintToChatAll($"[{ChatColors.Green}{ModuleName}{ChatColors.Default}] Plugin {(hotReload ? "hot-re" : "")}loaded!");
	}
}
