using Template.Config;
using CounterStrikeSharp.API.Core;
using Template.Tools;

namespace BotSlay
{
	public partial class TemplatePlugin: IPluginConfig<TemplateConfig>
	{
		public TemplateConfig Config { get; set; }
		public int moduleConfigVersion = 1;

		public void OnConfigParsed(TemplateConfig config)
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
