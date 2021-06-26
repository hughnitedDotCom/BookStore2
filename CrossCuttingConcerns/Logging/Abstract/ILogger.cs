namespace BookStore.CrossCuttingConcerns
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(string message);
        ILogger SetNextLogger(ILogger nextLogger);
    }
}
