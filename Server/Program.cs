using System;
using System.IO;
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


	public static int Main()
	{
		try
		{
			// Set capabilities to 0000000000000000
			if (WhiteListCapabilities(IntPtr.Zero, 0) != 0)
			{
				Console.WriteLine(UI.Program_Main_App_failed_to_run_safely);
				return 0;
			}
		}
		catch (DllNotFoundException e)
		{
			Console.WriteLine(e.Message);
			return 1;
		}

		Config config;
		try
		{
			config = LoadConfig();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return 1;
		}

		UserInterface ui = new(config);
		ui.Loop();


		return 0;
	}
}