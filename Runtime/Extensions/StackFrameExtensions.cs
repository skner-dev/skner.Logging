using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace skner.Logging.Extensions
{
    internal static class StackFrameExtensions
    {
        internal static string ToStackString(this List<StackFrame> stackFrames)
        {
            var sb = new StringBuilder();
            sb.AppendLine();

            foreach (var frame in stackFrames)
            {
                string methodName = frame.GetMethod().Name;
                string className = frame.GetMethod().DeclaringType?.FullName;
                int lineNumber = frame.GetFileLineNumber();

                if (!string.IsNullOrEmpty(className))
                {
                    sb.AppendFormat("   at {0}.{1}()", className, methodName);
                }
                else
                {
                    sb.AppendFormat("   at {0}()", methodName);
                }

                if (lineNumber > 0)
                {
                    sb.AppendFormat(" in {0}:{1}", className, lineNumber);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}