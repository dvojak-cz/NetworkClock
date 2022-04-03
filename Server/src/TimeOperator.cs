using System.Diagnostics;
using Server.Records;

namespace Server;

public class TimeOperator
{
	public static DateTime GetTime() => DateTime.Now;
	private readonly Config _config;

	public TimeOperator(Config config)
		=> _config = config;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="seconds"></param>
	/// <returns>
	/// 0 - OK <br/>
	/// -1 - not enabled <br/>
	/// -2 - error running <br/>
	/// -3 - process failed <br/>
	/// </returns>
	public int SetTime(long seconds)
	{
		if (!_config.TimeChanger.Enable)
			return -1;

		try
		{
			var p = Process.Start(_config.TimeChanger.ChangeTimeBin, seconds.ToString());
			p.WaitForExit();
			return p.ExitCode == 0 ? 0 : -3;
		}
		catch (Exception)
		{
			return -2;
		}
	}
}