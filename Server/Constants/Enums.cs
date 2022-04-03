namespace Server.Constants;

internal static class Enums
{
	/// <summary>
	/// Commands that can be passed on CLI
	/// </summary>
	public enum Commands
	{
		HELP = 'h',
		SET = 's',
		GET = 'g',
		FORMAT = 'f',
		QUIT = 'q'
	}
}