using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace Template.Tools
{
	public static class GameRulesHelper
	{
		private static readonly CachedEntity<CCSGameRulesProxy> _gameRules = new(() => Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").FirstOrDefault());

		public static CCSGameRules GetGameRules()
		{
			return _gameRules.Value?.GameRules;
		}
	}
}
