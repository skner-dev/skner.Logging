# Class Logger

## Overview

This logger type is meant to be used independently of Unity, mostly for non-MonoBehaviour classes.

## Configuring

Configuring a ClassLogger is done exclusively through code, but still makes use of the [LoggerSettings](../settings/logger-settings.md).

To instantiate it, create a new field in the desired script:

```c#
private ClassLogger _logger;
```

There are two ways to assign a logger settings instance to a new class logger, by loading an existing instance or by creating it altogether. 

### Existing Logger Settings

To use an existing LoggerSettings, that has been created and is saved in the Resources folder: _'Resources/Logging/ExampleLoggerSettings.asset'_, making use of the Resources class from Unity can fetch and load the ScriptableObject:

```c#
_logger = new ClassLogger(Resources.Load<LoggerSettings>("Logging/ExampleLoggerSettings"));
```

### Creating Logger Settings

It's possible to create an instance of the Logger Settings and configure it programatically. This removes the dependency from the scriptable object asset file, but it introduces a startup performance overhead and removes the advantages of using the Unity Editor to configure the LoggerSettings. 

Make use of the static CreateInstace method from the ScriptableObject class to create a new instance of the LoggerSettings:

```c#
LoggerSettings loggerSettings = ScriptableObject.CreateInstance<LoggerSettings>();
```

Now the variable _loggerSettings_ exists and call be fully configured in the script:

```c#
loggerSettings.LogToUnityConsole = true;
loggerSettings.LogToExternal = false;
```
