using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Cvars;

namespace Template.Tools
{
	public static class TimeHelper
	{
		private static ConVar _mapTimeLimit;
		private static ConVar _mapRoundLimit;

		public static ConVar mapTimeLimit => _mapTimeLimit ?? ConVar.Find("mp_timelimit");
		public static ConVar mapRoundLimit => _mapRoundLimit ?? ConVar.Find("mp_maxrounds");


		public static float TimeSinceMapStart()
		{
			return Server.CurrentTime - GameRulesHelper.GetGameRules().GameStartTime;
		}

		public static float MapTimeLimit()
		{
			return mapTimeLimit.GetPrimitiveValue<float>() * 60; // * 60 to get total seconds 
		}

		public static bool MapHasTimeLimit()
		{
			return MapTimeLimit() > 0;
		}

		public static float GetRemainingTime()
		{
			return Math.Max(0, MapTimeLimit() - TimeSinceMapStart());
		}

		public static int MapRoundLimit()
		{
			return mapRoundLimit.GetPrimitiveValue<int>();
		}

		public static bool MapHasRoundLimit()
		{
			return MapRoundLimit() > 0;
		}

		public static float GetRemainingRounds()
		{
			return Math.Max(0, MapRoundLimit() - GameRulesHelper.GetGameRules().TotalRoundsPlayed);
		}
	}
}
