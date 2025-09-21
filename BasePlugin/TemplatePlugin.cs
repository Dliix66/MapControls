using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

namespace BotSlay;

public partial class TemplatePlugin: BasePlugin
{
	public override string ModuleName => $"{nameof(TemplatePlugin)}";
	public override string ModuleVersion => "1.0.0";
	public override string ModuleAuthor => "Dliix66";
	public override string ModuleDescription => "TODO";

	public static TemplatePlugin Instance { get; private set; } = null!;

	public override void Load(bool hotReload)
	{
		Instance = this;

		base.Load(hotReload);

		Server.PrintToChatAll($"[{ChatColors.Green}{ModuleName}{ChatColors.Default}] Plugin {(hotReload ? "hot-re" : "")}loaded!");
	}
}
