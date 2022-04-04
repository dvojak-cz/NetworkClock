using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Server.Records;
using Server.Resources;

namespace Server;

public static class Program
{
	[DllImport("WhiteListCaps.so", EntryPoint = "WhiteListCapabilities")]
	private static extern int WhiteListCapabilities(IntPtr array, int len);

	private static Config LoadConfig()
	{
		string json;
		using (StreamReader r = new("/etc/NetworkClock.json"))
		{
			json = r.ReadToEnd();
		}

		var items = JsonConvert.DeserializeObject<Config>(json);
		return items!;
	}
	
	private static bool GiveUpCapabilities()
	{
		try
		{
			// Set capabilities to 0000000000000000
			if (WhiteListCapabilities(IntPtr.Zero, 0) != 0)
			{
				Console.WriteLine(UI.Program_Main_App_failed_to_run_safely);
				return false;
			}
		}
		catch (DllNotFoundException e)
		{
			Console.WriteLine(e.Message);
			return false;
		}

		return true;
	}

	private static Config? GetConfig()
	{
		Config config;
		try
		{
			return LoadConfig();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return null;
		}
	}

	public static async Task<int> Main()
	{
		if (!GiveUpCapabilities())
			return 1;

		var config = GetConfig();
		if (config is null)
			return 1;

		Server? s = null;
		if (config.Network.Enable)
		{
			s = new (config);
			s.Listen();
		}


		UserInterface ui = new(config, s);
		ui.Loop();
		s?.Dispose();
		return 0;
	}
}