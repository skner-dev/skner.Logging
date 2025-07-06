# Log Tag Holder

## Overview

The LogTagHolder is a struct that holds native values for all the [LogContext](log-context.md), in form of tags. These tag values are used to replace a [LogFormat](log-format.md) into a full string, containing all the required context for the log message.

This struct plays a pivotal role in the logging pipeline, working hand-in-hand with the [LogOutputSettings](../Settings/log-output-settings.md) to format and organize log data for various output destinations.

## Fields

| Field              | Type     | Description                                                         |
| ------------------ | -------- | ------------------------------------------------------------------- |
| `Timestamp`        | `string` | Timestamp when the log message was created.                         |
| `LogLevelName`     | `string` | Name of the log level associated with the log message.              |
| `LogLevelHexColor` | `string` | Hexadecimal color code associated with the log level.               |
| `SourceLogger`     | `string` | Source label for the logger from which the log message originated.  |
| `LineNumber`       | `int?`   | Line number in the source code where the log message was generated. |
| `ClassName`        | `string` | Full class name from which the log message originated.              |
| `MethodName`       | `string` | Method name from which the log message originated.                  |
| `Message`          | `string` | Log message.                                                        |
| `StackTrace`       | `string` | Stack trace associated with the log message.                        |
