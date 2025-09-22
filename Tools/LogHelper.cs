using System;
using BotSlay;

namespace Template.Tools
{
	public static class LogHelper
	{
#region Category Logs
		public static void Log(string category, string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Cyan, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog($"[{category}] {message}", printStackTrace, foregroundColor, backgroundColor);
		}

		public static void LogWarning(string category, string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Yellow, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog($"[{category}] {message}", printStackTrace, foregroundColor, backgroundColor);
		}

		public static void LogError(string category, string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Red, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog($"[{category}] {message}", printStackTrace, foregroundColor, backgroundColor);
		}
#endregion

#region Logs
		public static void Log(string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Cyan, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog(message, printStackTrace, foregroundColor, backgroundColor);
		}

		public static void LogWarning(string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Yellow, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog(message, printStackTrace, foregroundColor, backgroundColor);
		}

		public static void LogError(string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Red, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			SubLog(message, printStackTrace, foregroundColor, backgroundColor);
		}

		public static void LogDebug(string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.DarkMagenta, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			if (MapControls.Instance.Config.debug)
				SubLog(message, printStackTrace, foregroundColor, backgroundColor);
		}

		private static void SubLog(string message, bool printStackTrace = false, ConsoleColor foregroundColor = ConsoleColor.Cyan, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
		{
			Console.BackgroundColor = backgroundColor;
			Console.ForegroundColor = foregroundColor;
			string msg = $"[WCS2] {message}";
			if (printStackTrace)
				msg += $"\n{Environment.StackTrace}";
			Console.WriteLine(msg);
			Console.ResetColor();
		}
#endregion

#region Server Logs
		private const string DEFAULT = "\x1b[0m";
		private const string BLACK = "\x1b[30m";
		private const string RED = "\x1b[31m";
		private const string GREEN = "\x1b[32m";
		private const string YELLOW = "\x1b[33m";
		private const string BLUE = "\x1b[34m";
		private const string PURPLE = "\x1b[35m";
		private const string CYAN = "\x1b[36m";
		private const string WHITE = "\x1b[37m";

		//public static void ServerLog(string message, bool printStackTrace = false)
		//{
		//	SubServerLog($"{CYAN}{message}{DEFAULT}", printStackTrace);
		//}

		//public static void ServerLogWarning(string message, bool printStackTrace = false)
		//{
		//	SubServerLog($"{YELLOW}{message}{DEFAULT}", printStackTrace);
		//}

		//public static void ServerLogError(string message, bool printStackTrace = false)
		//{
		//	SubServerLog($"{RED}{message}{DEFAULT}", printStackTrace);
		//}s

		//private static void SubServerLog(string message, bool printStackTrace)
		//{
		//	string fullMsg = $"{CYAN}{GetInstanceHash()}[WCS2] {message}";
		//	if (printStackTrace)
		//		fullMsg += $"\n{CYAN}{Environment.StackTrace}{DEFAULT}";
		//	Server.PrintToConsole(fullMsg);
		//}
#endregion
	}
}
