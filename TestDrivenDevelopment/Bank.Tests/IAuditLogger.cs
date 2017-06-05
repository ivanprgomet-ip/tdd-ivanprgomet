using System.Collections.Generic;

namespace Bank.Tests
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}