# Output Modules

## Overview

Output Modules are small classes that implement logic related with logging output. These modules are used by the Logging library for the various [LogOutputSettings](../Settings/log-output-settings.md) available.

These are quite useful since most LogOutputSettings' implementation will share functionality. By following a composition principle, the developer can easily define a feature as a module and use it as a building block of the LogOutputSettings' implementation.

Some modules are pre-packaged, but are focused on file based output. For other types of outputting, such as a database or a webservice, the developer can create their own modules.

It's highly recommended to use this practice when implementing custom LogOutputSettings.

## Native modules

Here is a list of the modules that are pre-packaged:

* **LogOutputFileWriter**: writes a log into a file.
* **LogOutputFormat**: formats a log with a given [LogFormat](../Models/log-format.md).
* **LogOutputBuffer**: creates a writting buffer for the log output.
* **LogOutputSelector**: filters a [LogTagHolder](../Models/log-tag-holder.md) to only include certain fields.creates a writting buffer for the log output.

## Creating

This section will outline the high-level approach to creating a module.

**1. Implement the module:**

Implement the functionality of your module based on the requirements. For Log Output Settings, this might include handling log messages, managing buffers, or defining output formats.

**2. Module properties:**

Define the properties that your module requires. These properties will be configurable via the Unity Inspector.

**3. \[Serializable] Attribute:**

Ensure your custom module class is marked with the \[Serializable] attribute. This is necessary for Unity to serialize the class and display its properties in the Inspector.

**4. Custom Property Drawer:**

Implement a custom property drawer to enhance the visual representation of your module in the Unity Inspector. This ensures a clean and organized display of settings.
