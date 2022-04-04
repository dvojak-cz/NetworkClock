using System;
using Server.Constants;
using Server.Records;
using Server.Resources;
using Regex = System.Text.RegularExpressions.Regex;


namespace Server;

public class UserInterface
{
	/// <summary>
	/// Holds format for formatting time
	/// </summary>
	private string _format;

	/// <summary>
	/// Flag, that holds if command fo exiting app has been entered
	/// </summary>
	private bool _end;

	/// <summary>
	/// Time operator
	/// </summary>
	private readonly TimeOperator _timeOperator;

	private readonly Server? _server;

	public UserInterface(Config conf, Server? server = null)
	{
		_server = server;
		_format = Formats.DEFAULT_DATE_FORMAT;
		_end = false;
		_timeOperator = new TimeOperator(conf);
	}

	/// <summary>
	/// UI CLI loop
	/// </summary>
	public void Loop()
	{
		do
		{
			Console.Write(UI.UserInterface_Loop_Command__h_for_help);
			var command = Console.ReadLine();
			if (!ValidateInput(command, Constants.Regex.REGEX_COMMAND))
			{
				continue;
			}

			EvaluateCommand((Enums.Commands) command![0]);
		} while (!_end);
	}

	/// <summary>
	/// Evaluates command and execute action for command
	/// </summary>
	/// <param name="command">Command</param>
	private void EvaluateCommand(Enums.Commands command)
	{
		switch (command)
		{
			// Prints help message
			case Enums.Commands.HELP:
				Console.WriteLine(UI.UserInterface_EvaluateCommand_Menu);
				break;
			// Sets new time
			case Enums.Commands.SET:
				SetTime();
				break;
			// Displays time to user
			case Enums.Commands.GET:
				Console.WriteLine(TimeOperator.GetTime.ToString(_format));
				break;
			// Sets new date format 
			case Enums.Commands.FORMAT:
				SetFormat();
				break;
			// Exits application
			case Enums.Commands.QUIT:
				_server?.Stop();
				_end = true;
				Console.WriteLine(UI.UserInterface_EvaluateCommand_Stopping_server);
				break;
			default:
				Console.WriteLine(UI.UserInterface_EvaluateCommand_Invalid_input);
				break;
		}
	}
	/// <summary>
	/// Sets new format
	/// </summary>
	private void SetFormat()
	{
		Console.WriteLine(UI.UserInterface_SetFormat_Specify_the_format);
		_format = Console.ReadLine() ?? "";
		Console.WriteLine(UI.UserInterface_SetFormat_Format_has_been_set);
	}

	private void SetTime()
	{
		Console.WriteLine(UI.UserInterface_SetTime_Please_enter_the_date_you_want_to_set);
		var formatInput = Console.ReadLine()?.Trim();
		DateTime newDate;
		try
		{
			newDate = DateTime.Parse(formatInput ?? throw new ArgumentNullException());
		}
		catch (Exception)
		{
			Console.WriteLine(UI.UserInterface_SetTime_Invalid_format);
			return;
		}

		var diff = newDate.ToUniversalTime() - DateTime.UnixEpoch;
		var res = _timeOperator.SetTime((long) Math.Floor(diff.TotalSeconds));
		switch (res)
		{
			case 0: break;
			case -1:
				Console.WriteLine(UI.UserInterface_SetTime_This_acction_is_not_enabled_);
				break;
			case -2:
				Console.WriteLine(UI.UserInterface_SetTime_Runnig_process_failed_);
				break;
			case -3:
				Console.WriteLine(UI.UserInterface_SetTime_Prces_exited_with_failure_);
				break;
		}
	}

	private static bool ValidateInput(string? input, string regexPattern)
	{
		var res = input is not null && new Regex(regexPattern).IsMatch(input);
		if (res is false)
		{
			Console.WriteLine(UI.UserInterface_ValidateInput_Invalid_input);
		}

		return res;
	}
}