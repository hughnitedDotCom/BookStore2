using Serilog;
using Serilog.Sinks.RollingFileAlternative;
using System.IO;

namespace BookStore.CrossCuttingConcerns
{
    public class FileLogger : AbstractLogger
    {
        Serilog.Core.Logger _fileLogger;

        private string directory = Directory.GetCurrentDirectory();
        
        public FileLogger()
        {
            string logErrorPath = $"{directory}/Log.txt";

            _fileLogger = new LoggerConfiguration()
                            .WriteTo
                            .RollingFile(logErrorPath, fileSizeLimitBytes: 1024 * 1024)
                            .CreateLogger();
        }

        public override void LogDebug(string message)
        {
            _fileLogger.Debug(message);
            _nextLogger?.LogDebug(message);
        }

        public override void LogError(string message)
        {
            _fileLogger.Error(message);
            _nextLogger?.LogError(message);
        }

        public override void LogInformation(string message)
        {
            _fileLogger.Information(message);
            _nextLogger?.LogInformation(message);
        }

        public override void LogWarning(string message)
        {
            _fileLogger.Warning(message);
            _nextLogger?.LogWarning(message);
        }
    }
}
