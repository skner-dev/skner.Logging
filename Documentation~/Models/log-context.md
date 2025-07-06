# Log Context

## Overview

When any log message is generated, a Log Context instance is generated. It contains important information about the log call that can be used to construct the log message.

## Fields

| Field          | Type               | Description                                                         |
| -------------- | ------------------ | ------------------------------------------------------------------- |
| `Timestamp`    | `DateTime`         | Timestamp when the log message was created.                         |
| `LogLevel`     | `LogLevelDetail`   | Log level information associated with the log message.              |
| `SourceLogger` | `string`           | Source label for the logger where the log message originated.       |
| `LineNumber`   | `int`              | Line number in the source code where the log message was generated. |
| `ClassName`    | `string`           | Full class name from which the log message originated.              |
| `MethodName`   | `string`           | Method name from which the log message originated.                  |
| `Message`      | `string`           | Log message.                                                        |
| `StackFrames`  | `List<StackFrame>` | List of StackFrames from the log StackTrace.                        |

## Generation

When any logger is called, this context will be generated. Most of the fields are self explanatory, but here are some details:

### LogLevel

The LogLevelDetails are obtained depending on the log level provided in the Log call. These will match the LogLevels configured in the Project Settings.

### Stackframes

The logger will capture every stack frame in the log call to generate a call stack. This can be included in the [LogFormat](log-format.md) as a tag and configured per log level.

Additionally, it's possible to hide a method from the generated call stack by using the \[[HideInCallstack](https://docs.unity3d.com/ScriptReference/HideInCallstackAttribute.html)] attribute.
