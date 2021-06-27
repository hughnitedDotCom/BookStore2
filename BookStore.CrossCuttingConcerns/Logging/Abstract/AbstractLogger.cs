using BookStore.CrossCuttingConcerns;

namespace BookStore.CrossCutting_dbContextcerns
{
    public abstract class AbstractLogger : ILogger
    {
        protected ILogger _nextLogger;

        public abstract void LogDebug(string message);
        public abstract void LogError(string message);
        public abstract void LogInformation(string message);
        public abstract void LogWarning(string message);

        public virtual ILogger SetNextLogger(ILogger nextLogger)
        {
            _nextLogger = nextLogger;

            return this;
        }
    }
}
