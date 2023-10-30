using System.Configuration;

namespace UtilityLib
{
    public class Utility
    {

        public bool testInt(string num)
        {
            if (int.TryParse(num, out int userNum))
            {
                return true;
            }
            else { return false; }
        }
        public void titleStyle(string message)
        {
            Console.WriteLine("");
            Console.WriteLine($"== {message} ==");
            Console.WriteLine("");
        }
        public void errorStyle(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void successStyle(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
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

        public void WriteDataEvent(DataLog dLog, string path, string name)
        {
            string rowLofValues = $"/-/ Nuova registrazione : {name} - {dLog.DateTimeLog} /-/\n";

            File.AppendAllText(path, rowLofValues);
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
            public void WriteErrorEvent(ErrorLog dLog, string path)
            {
                string rowLogValues = $"{dLog.ClassName}:{dLog.MethodName}:{dLog.DateTimeLog.ToString()}:" + $"{dLog.ErrorCode.ToString()}:{dLog.ErrorMessage}:{dLog.InnerExcept}";

                File.AppendAllText(path, rowLogValues);
            }
        }
    }
}