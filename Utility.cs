using System.Configuration;

namespace UtilityLib
{
    public class Utility
    {
        public void errorStyle(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool testInt(string value)
        {
            if (int.TryParse(value, out int val))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class DataLog
        {
            public string? ClassName { get; set; }

            public string? MethodName { get; set; }

            public DateTime DateTimeLog { get; set; }

            public DataLog(string? className, string? methodName, DateTime dateTimeLog)
            {
                ClassName = className;
                MethodName = methodName;
                DateTimeLog = dateTimeLog;
            }
        }

        public void WriteDataEvent(DataLog dLog)
        {
            string rowLofValues = $"{dLog.ClassName} - {dLog.MethodName} - {dLog.DateTimeLog}";

            File.AppendAllText("C:\\Users\\Gabriele\\Documents\\Betacom\\EsercizioLogin_Ren\\MyNameIsAlpaca\\EsercizioLogin\\DataLog.txt", rowLofValues);
        }

        public class ErrorLog
        {
            public string? ClassName { get; set; }
            public string? MethodName { get; set; }

            public DateTime DateTimeLog { get; set; }
            public int ErrorCode { get; set; }
            public string? ErrorMessage { get; set; }

            public string? InnerExcept { get; set; }
            public ErrorLog() { }

            public ErrorLog(string? className, string? methodName, DateTime dateTimeLog, int errorCode, string? errorMessage, string? innerExcept)
            {
                ClassName = className;
                MethodName = methodName;
                DateTimeLog = dateTimeLog;
                ErrorCode = errorCode;
                ErrorMessage = errorMessage;
                InnerExcept = innerExcept;
            }
            public void WriteErrorEvent(ErrorLog dLog)
            {
                string rowLogValues = $"{dLog.ClassName}:{dLog.MethodName}:{dLog.DateTimeLog.ToString()}:" + $"{dLog.ErrorCode.ToString()}:{dLog.ErrorMessage}:{dLog.InnerExcept}";

                File.AppendAllText("C:\\Users\\Gabriele\\Documents\\Betacom\\EsercizioLogin_Ren\\MyNameIsAlpaca\\EsercizioLogin\\ErrorLog.txt", rowLogValues);
            }
        }
    }
}