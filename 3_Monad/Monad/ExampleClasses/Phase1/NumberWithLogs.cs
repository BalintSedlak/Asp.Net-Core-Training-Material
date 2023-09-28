using System.Text;

namespace Monad.ExampleClasses.Phase1;
public class NumberWithLogs
{
    public int Result { get; init; }
    public List<string> Log { get; init; } 

    public NumberWithLogs(int result, List<string> logHistory)
    {
        Result = result;
        Log = logHistory;
    }

    public NumberWithLogs(int result, List<string> logHistory, string newLog) : this(result, logHistory)
    {
        Log.Add(newLog);
    }

    public string WriteLog()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var logEntry in Log)
        {
            stringBuilder.AppendLine(logEntry);
        }

        return stringBuilder.ToString();
    }
}
