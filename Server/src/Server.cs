using System.Net;
using System.Text;
using Server.Records;

namespace Server;

public class Server : IDisposable
{
	private readonly HttpListener _listener;

	public void Stop()
	{
		if (!_listener.IsListening) return;
		_listener.Stop();
	}


	public Server(Config config)
	{
		_listener = new HttpListener();
		_listener.Prefixes.Add($"http://*:{config.Network.Port}/");
	}

	public void Listen()
	{
		if (!_listener.IsListening)
		{
			_listener.Start();

			Task.Factory.StartNew(async () =>
			{
				while (true) await Listen(_listener);
			}, TaskCreationOptions.LongRunning);
		}
	}

	private async Task Listen(HttpListener l)
	{
		try
		{
			var ctx = await l.GetContextAsync();
			await processReqest(ctx);
		}
		catch (HttpListenerException)
		{
		}
	}

	private async Task processReqest(HttpListenerContext context)
	{
		HttpListenerRequest request = context.Request;
		var dateFormat = string.IsNullOrEmpty(request.QueryString["format"])
			? Constants.Formats.DEFAULT_DATE_FORMAT
			: request.QueryString["format"];
		var responseString = TimeOperator.GetTime.ToString(dateFormat);
		byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

		HttpListenerResponse response = context.Response;
		response.ContentLength64 = buffer.Length;
		Stream output = response.OutputStream;
		await output.WriteAsync(buffer, 0, buffer.Length);
		output.Close();
	}

	public void Dispose()
	{
		((IDisposable) _listener).Dispose();
	}
}