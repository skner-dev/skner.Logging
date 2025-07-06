# Global Logger

## Overview

The GlobalLogger is a singleton logger. It facilitates logging throughout the project and uses a centralized configuration. 

## Configuring

The configuration for GlobalLogger is located in the Project Settings:

![GlobalLogger Settings](/images/globallogger.png)

This references a ScriptableObject that comes pre-packaged in the Resources folder. __Editing these files outside of the Project Settings is possible, but it can lead to unexpected behaviours that are not supported by the library.__

## Using

To use the GlobalLogger in any project script, ensure the script references the following namespace:

```c#
using skner.Logging.Loggers;
```

The GlobalLogger uses a static Instance that is accessible through the project and is initialized on load.

Call any of the available Log methods from the GlobalLogger's Instance:

```c#
GlobalLogger.Instance.LogDebug("Logging a debug message.");
```
