# Log Output Settings

## Overview

This logging library offers a a very flexible way to output logs. It's architectured to facilitate the developer to completely implement their own output, whether that's a specific file type, database or webservice, the freedom of choice is placed in the developer.

The package facilitates the integration with any output by providing a comprehensive interface that can be implemented for any output imaginable.

Each implementation can be instantiated, as it derives from Unity's ScriptableObjects and therefore configured at will. This means that the developer can setup two instances of the same output type, but for different files / databases, for example.

A sample TXT, CSV and XML file output implementations are pre-packaged for the developer to use.

## Creating

This section will demonstrate how to fully implement a brand new log output. It will use the TXT Log Output Settings as a use case.

1. Create a new script that extends from the abstract class `LogOutputSettings`.

    ```c#
    /// <summary>
    /// Represents log output settings for saving log messages to a text (TXT) file.
    /// </summary>
    [CreateAssetMenu(fileName = "TxtLogOutputSettings", menuName = "Logging/Log Output Settings/Txt File")]
    public class TxtLogOutputSettings : LogOutputSettings
    ```

    _Note: It's advisable to use the `CreateAssetMenu` attribute to facilitate the creation of the settings for this log output type._

2. Implement the abstract class's `SendToOutputAsync` method:

    ```c#
    /// <inheritdoc/>
    public override async Task SendToOutputAsync(LogTagHolder logTagHolder);
    ```

    In the TXT implementation, for example, a buffer is configured and flushed frequently. The developer is free to determine and implement any logic associated with the output functionality. 

3. Add and use Output Modules:

    ```c#
    [SerializeField] internal LogOutputFormat LogOutputFormat;
    [SerializeField] internal LogOutputFileWriter LogOutputFile;
    [SerializeField] internal LogOutputBuffer LogOutputBuffer;
    ```

    This functionality is made possible by the use of several output modules, using a composition principle. Learn more [here](<../Output Modules/output-modules.md>).

    These modules will be exposed in the inspector with a custom property drawer, making it easy for the developer to configure each module.

    When creating a new LogOutputSettings type, the developer can create or use existing modules to create their own output logic.

    Example on how these three different output modules affect the inspector window for the TxtLogOutputSettings:

    ![TxtLogOutputSettings inspector preview](/images/logoutputsettings_tutorial1.png)

## Instantiating 

After the log output has been created, a settings object must be created and configured in order to be used.

1. Create an instance of the log output settings by going to Assets -> Create -> Logging -> Log Output Settings -> Your implementation. Choose a name for this instance.

    ![TxtLogOutputSettings in the Resources folder](/images/logoutputsettings_tutorial2.png)

    Ensure that the `CreateAssetMenu` was added in the log output creation steps.

2. Use the inspector to configure the output settings with the desired configuration. Ideally, the configuration will use the modules defined in the implementation:

    Here's a sample TXT Log Output Settings:

    ![TxtLogOutputSettings inspector preview](/images/logoutputsettings_tutorial1.png)

## Assigning 

With a configured instance of the new log output settings, the developer can assign it to any existing logger settings.

1. Go to any existing Logger Settings instance:

    ![](/images/logoutputsettings_tutorial3.png)

2. Enable `Log To External` and click `Add Log Output Entry`:

    ![](/images/logoutputsettings_tutorial4.png)

3. Drag and drop the created log output settings into the box.

    ![](/images/logoutputsettings_tutorial5.png)

With this, any Log call to a logger making use of these logger settings will redirect every log message (after the log level filter is applied) to the configured log output. 
