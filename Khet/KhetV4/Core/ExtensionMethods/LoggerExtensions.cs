using Serilog;
using Serilog.Context;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace KhetV4.Core.ExtensionMethods
{
    public static class LoggerExtensions
    {
        public static void InformationWithCaller(this ILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            string fileName = Path.GetFileName(sourceFilePath);
            using (LogContext.PushProperty("CallerMemberName", memberName))
            using (LogContext.PushProperty("CallerFileName", fileName))
            using (LogContext.PushProperty("CallerLineNumber", sourceLineNumber))
            {
                logger.Information(messageTemplate);
            }
        }

        public static void InformationWithCaller<T>(this ILogger logger, string messageTemplate, T propertyValue,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (LogContext.PushProperty("CallerMemberName", memberName))
            using (LogContext.PushProperty("CallerFilePath", sourceFilePath))
            using (LogContext.PushProperty("CallerLineNumber", sourceLineNumber))
            {
                logger.Information(messageTemplate, propertyValue);
            }
        }

        // Add similar methods for Warning, Error, Debug, etc.
        public static void ErrorWithCaller(this ILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (LogContext.PushProperty("CallerMemberName", memberName))
            using (LogContext.PushProperty("CallerFilePath", sourceFilePath))
            using (LogContext.PushProperty("CallerLineNumber", sourceLineNumber))
            {
                logger.Error(exception, messageTemplate);
            }
        }
    }
}
