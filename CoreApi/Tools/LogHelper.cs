using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Tools
{
    public static class LogHelper
    {
        private static readonly ILoggerFactory loggerFactory;        
        static LogHelper() {
            loggerFactory = new LoggerFactory()
                        .AddConsole()
                        .AddDebug();
                            //.AddProvider(new FileLoggerProvider(new FileLoggerSettings(ConfigHelper.Configuration)));                                           
            
        }
        public static ILogger GetLogger() {
            StackTrace trace = new StackTrace();
            var Frame = trace.GetFrame(2).GetMethod().ReflectedType;
            return (ILogger)typeof(LogHelper).GetMethod("CreateLogger").MakeGenericMethod(Frame).Invoke(null, new object[] { loggerFactory });
        }
        public static ILogger CreateLogger<T>(ILoggerFactory loggerFactory) {
            return loggerFactory.CreateLogger<T>();
        }
        public static IDisposable BeginScope(string messageFormat, params object[] args)
        {
            return GetLogger().BeginScope(messageFormat, args);
        }
        public static IDisposable BeginScope<TState>(TState state)
        {
            return GetLogger().BeginScope<TState>(state);
        }
        public static bool IsEnabled(LogLevel logLevel)
        {
            return GetLogger().IsEnabled(logLevel);
        }
        public static void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            GetLogger().Log<TState>(logLevel, eventId, state, exception, formatter);
        }
        public static void Log(LogLevel logLevel, string message,params object[] args)
        {
            GetLogger().Log(logLevel, message, args);
        }
        public static void Log(LogLevel logLevel, EventId eventId, string message, params object[] args)
        {
            GetLogger().Log(logLevel, eventId, message, args);
        }
        public static void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            GetLogger().Log(logLevel, exception, message, args);
        }
        public static void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().Log(logLevel, eventId, exception, message, args);
        }
        public static void LogCritical(string message, params object[] args) {
            GetLogger().LogCritical(message, args);
        }
        public static void LogCritical(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogCritical(eventId, message, args);
        }
        public static void LogCritical(Exception exception, string message, params object[] args)
        {
            GetLogger().LogCritical(exception, message, args);
        }
        public static void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogCritical(eventId, exception, message, args);
        }
        public static void LogDebug(string message, params object[] args)
        {
            GetLogger().LogDebug(message, args);
        }
        public static void LogDebug(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogDebug(eventId, message, args);
        }
        public static void LogDebug(Exception exception, string message, params object[] args)
        {
            GetLogger().LogDebug(exception, message, args);
        }
        public static void LogDebug(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogDebug(eventId, exception, message, args);
        }
        public static void LogError(string message, params object[] args)
        {
            GetLogger().LogError(message, args);
        }
        public static void LogError(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogError(eventId, message, args);
        }
        public static void LogError(Exception exception, string message, params object[] args)
        {
            GetLogger().LogError(exception, message, args);
        }
        public static void LogError(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogError(eventId, exception, message, args);
        }
        public static void LogInformation(string message, params object[] args)
        {
            GetLogger().LogInformation(message, args);
        }
        public static void LogInformation(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogInformation(eventId, message, args);
        }
        public static void LogInformation(Exception exception, string message, params object[] args)
        {
            GetLogger().LogInformation(exception, message, args);
        }
        public static void LogInformation(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogInformation(eventId, exception, message, args);
        }
        public static void LogTrace(string message, params object[] args)
        {
            GetLogger().LogTrace(message, args);
        }
        public static void LogTrace(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogTrace(eventId, message, args);
        }
        public static void LogTrace(Exception exception, string message, params object[] args)
        {
            GetLogger().LogTrace(exception, message, args);
        }
        public static void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogTrace(eventId, exception, message, args);
        }
        public static void LogWarning(string message, params object[] args)
        {
            GetLogger().LogWarning(message, args);
        }
        public static void LogWarning(EventId eventId, string message, params object[] args)
        {
            GetLogger().LogWarning(eventId, message, args);
        }
        public static void LogWarning(Exception exception, string message, params object[] args)
        {
            GetLogger().LogWarning(exception, message, args);
        }
        public static void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
        {
            GetLogger().LogWarning(eventId, exception, message, args);
        }
    }    
}
