using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace SharedUtilities
{
    public static class LogHelper
    {
        private const string SourceName = "InventorySystem";
        private const string LogName = "Application";

        /// <summary>
        /// Logs an error message with contextual information.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        /// <param name="ex">Optional exception to log.</param>
        /// <param name="methodName">Name of the method where the error occurred (auto-filled).</param>
        /// <param name="filePath">File path of the source file where the error occurred (auto-filled).</param>
        public static void LogError(string message,
                                    Exception ex = null,
                                    [CallerMemberName] string methodName = "",
                                    [CallerFilePath] string filePath = "")
        {
            try
            {
                // Create event source if it does not exist
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                // Extract file name and project name for context
                string fileName = Path.GetFileName(filePath);
                string projectName = Path.GetFileName(Path.GetDirectoryName(filePath));

                // Include stack trace if exception is provided
                string exceptionDetails = ex != null ? $"\nException: {ex.Message}\nStackTrace: {ex.StackTrace}" : string.Empty;

                // Compose detailed log message
                string logMessage = $"{DateTime.Now:G} | {projectName}::{fileName}::{methodName}: {message}{exceptionDetails}";

                // Write to event log
                EventLog.WriteEntry(SourceName, logMessage, EventLogEntryType.Error);

                // Optional: Write to console for debugging purposes
                Console.WriteLine(logMessage);
            }
            catch (Exception loggingEx)
            {
                // Fallback logging if EventLog fails
                Console.WriteLine("Logging failed: " + loggingEx.Message);
            }
        }

        public static void LogWarning(string message,
                                  [CallerMemberName] string methodName = "",
                                  [CallerFilePath] string filePath = "")
        {
            try
            {
                // Create event source if it does not exist
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                // Extract file name and project name for context
                string fileName = Path.GetFileName(filePath);
                string projectName = Path.GetFileName(Path.GetDirectoryName(filePath));

                // Compose detailed log message
                string logMessage = $"{DateTime.Now:G} | {projectName}::{fileName}::{methodName}: {message}";

                // Write to event log
                EventLog.WriteEntry(SourceName, logMessage, EventLogEntryType.Warning);

                // Optional: Write to console for debugging purposes
                Console.WriteLine(logMessage);
            }
            catch (Exception loggingEx)
            {
                // Fallback logging if EventLog fails
                Console.WriteLine("Logging failed: " + loggingEx.Message);
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        public static void LogInfo(string message,
                                    [CallerMemberName] string methodName = "",
                                    [CallerFilePath] string filePath = "")
        {
            try
            {
                // Create event source if it does not exist
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                // Extract file name and project name for context
                string fileName = Path.GetFileName(filePath);
                string projectName = Path.GetFileName(Path.GetDirectoryName(filePath));

                // Compose detailed log message
                string logMessage = $"{DateTime.Now:G} | {projectName}::{fileName}::{methodName}: {message}";

                // Write to event log
                EventLog.WriteEntry(SourceName, logMessage, EventLogEntryType.Information);

                // Optional: Write to console for debugging purposes
                Console.WriteLine(logMessage);
            }
            catch (Exception loggingEx)
            {
                // Fallback logging if EventLog fails
                Console.WriteLine("Logging failed: " + loggingEx.Message);
            }
        }
    }
}
