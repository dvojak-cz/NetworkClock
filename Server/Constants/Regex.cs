namespace Server.Constants;

public static class Regex
{
	public const string REGEX_COMMAND = @"^[hsgfq]$";
	private const string YEAR = @"((yyyy)|(y))";
	private const string MONTH = @"((MM)|(M))";
	private const string DAY = @"((dd)|(d))";
	private const string HOUR = @"((hh)|(h))";
	private const string MINUTE = @"((mm)|(m))";
	private const string DELIM = @"([:\-_\/ ])";
	public const string REGEX_TIME_FORMAT = @$"^{YEAR}{DELIM}{MONTH}{DELIM}{DAY}{DELIM}{HOUR}{DELIM}{MINUTE}$";
}