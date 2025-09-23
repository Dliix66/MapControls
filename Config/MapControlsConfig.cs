using System.Text.Json;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace Template.Config;

public class MapControlsConfig: BasePluginConfig
{
	public override int Version { get; set; } = 1;
	
	[JsonPropertyName("timeleftPrintToAllChat")]
	public bool timeleftPrintToAllChat { get; set; } = true;

	[JsonPropertyName("debug")]
	public bool debug { get; set; } = false;

	public override string ToString()
	{
		return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
	}
}
