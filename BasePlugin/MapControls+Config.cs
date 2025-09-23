using CounterStrikeSharp.API.Core;
using Template.Config;
using Template.Tools;

namespace Template.BasePlugin
{
	public partial class MapControls: IPluginConfig<MapControlsConfig>
	{
		public MapControlsConfig Config { get; set; }
		public int moduleConfigVersion = 1;

		public void OnConfigParsed(MapControlsConfig config)
		{
			LogHelper.Log("Config parsed!");

			if (config.Version < moduleConfigVersion)
			{
				LogHelper.Log($"A new config file version is available. Your version ({config.Version}), new version: ({moduleConfigVersion})");
			}

			// if everything is good, lets save the instance reference
			Config = config;
		}
	}
}
