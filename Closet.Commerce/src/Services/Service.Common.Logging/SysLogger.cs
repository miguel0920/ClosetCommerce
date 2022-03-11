using Microsoft.Extensions.Logging;

namespace Service.Common.Logging
{
	public class SyslogLoggerProvider : ILoggerProvider
	{
		private readonly string _hostName;
		private readonly LogLevel _logLevel;
		private readonly IDictionary<string, ILogger> _loggers;

		public SyslogLoggerProvider(string hostName, LogLevel logLevel)
		{
			_hostName = hostName;
			_logLevel = logLevel;
			_loggers = new Dictionary<string, ILogger>();
		}

		public ILogger CreateLogger(string name)
		{
			if (!_loggers.ContainsKey(name))
				_loggers[name] = CreateLoggerInstance(name);

			return _loggers[name];
		}

		private ILogger CreateLoggerInstance(string name)
		{
			switch (_settings.HeaderType)
			{
				case SyslogHeaderType.Rfc3164:
					return new Syslog3164Logger(name, _settings, _hostName, _logLevel, _messageSender);
				case SyslogHeaderType.Rfc5424v1:
					return new Syslog5424v1Logger(name, _settings, _hostName, _logLevel, _messageSender);
				default:
					throw new InvalidOperationException($"SyslogHeaderType '{_settings.HeaderType.ToString()}' is not recognized.");
			}
		}

		public ILogger CreateLogger<T>()
		{
			return CreateLogger(typeof(T).FullName);
		}

		public void Dispose()
		{
			_loggers.Clear();
		}
	}
}