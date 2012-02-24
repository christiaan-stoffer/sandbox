using System;
using System.Collections.Generic;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public delegate void ProcessOutput(string message);

    public delegate void ProcessError(string message, Exception ex);

    public class SqlGenerationEngine
    {
        private readonly StringBuilder _builder;

        public SqlGenerationEngine()
        {
            _builder = new StringBuilder();
        }

        public event ProcessOutput Output;
        public event ProcessError Error;

        private void OnOutput(string msg)
        {
            ProcessOutput handler = Output;
            if (handler != null) handler(msg);
        }

        private void OnError(string msg, Exception ex)
        {
            ProcessError handler = Error;
            if (handler != null) handler(msg, ex);
        }

        public void Generate(IEnumerable<Type> types)
        {
        }
    }
}