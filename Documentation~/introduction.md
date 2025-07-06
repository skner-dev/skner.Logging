# Introduction

## Overview

This logging package offers an invaluable set of tools designed to make logging in Unity projects both simple and powerful. It offers a remarkable blend of user-friendliness and extensive configurability, this package caters to developers of all preferences and project requirements.

## Loggers

In this section, we'll introduce the three primary loggers that come pre-packaged with the library.

### GlobalLogger

The [**GlobalLogger**](Loggers/global-logger.md) stands as a singleton logger, effortlessly accessible throughout the entire project. Ideal for developers seeking a shared configuration across classes and objects, this logger ensures a consistent logging experience.

### GameObjectLogger

Meet the [**GameObjectLogger**](Loggers/game-object-logger.md), a Unity MonoBehaviour that seamlessly provides logging functionality in the form of a Unity Component. Adding it to a GameObject allows any script on that GameObject to access it with ease - simply use **`GetComponent<GameObjectLogger>()`**. This versatile component empowers developers with custom settings, neatly isolated from other logger instances.

### ClassLogger

For non-MonoBehaviour scripts requiring a specific logger, the [**ClassLogger**](Loggers/class-logger.md) steps in. While similar to the GameObjectLogger in its ability to configure LoggerSettings, it's primarily designed for non-MonoBehaviour scripts. Loading settings through scripting, this logger caters to scenarios where scripts need to manage their unique logging requirements.

## Features

The package offers a robust set of features, empowering developers to elevate their game's logging capabilities.

### Powerful and flexible configuration

#### Overview

skner's Logging provides an easy and intuitive way to configure its logging features. With the Logger Settings, developers can fully customize different loggers to behave according to the project's needs.

#### Learn more

Explore detailed information on the package manages its configuration and how to get started in the [Logger Settings](Settings/logger-settings.md) page.

### Customizable Log Levels

#### Overview

The package provides three default log levels—Error, Warning, and Debug. While these serve as foundational elements for logging, developers have the freedom to add additional levels by configuring them in Project Settings.

#### Learn more

See the [Log Levels](Settings/log-level-settings.md) page to learn how to create, configure and use custom log levels.

### Customizable Logging Output

#### Overview

Effective logging requires suitable outputs. The logging library supports logging into the Unity Console, specific file types, and even custom outputs like databases or web services. Seamless integration allows developers to implement their own logging output effortlessly. The package includes a sample TXT, CSV and XML file outputs, and developers can create specific instances of custom outputs, configuring them for different instances of the same output type.

#### Learn more

For more information on how to create a custom logging output, how to use the log output settings and more and configuring conditional logging callbacks through scripting, refer to the [Log Output Settings](Settings/log-output-settings.md) page.

### Rich Logging Format

Tailor the log format for each logger with a highly customizable structure supporting Rich Text formatting. This feature integrates seamlessly with the Unity Console, allowing for a visually appealing and informative logging experience.

Explore the details of log formatting and its customization options on the [Log Format](Models/log-format.md) page.

### Intuitive User Experience

#### Overview

To enhance user experience, the package incorporates custom inspector elements for all settings, ensuring a seamless and intuitive configuration process. The design philosophy is centered around delivering an experience that caters to both novice and advanced developers.

**For novice developers:**

* The package prioritizes a code-free approach for basic configurations and common use cases.
* Users can effortlessly navigate through the custom inspector elements, making adjustments without delving into code.
* While basic configurations can be achieved without code, it's important to note that coding is essential for logging messages and more advanced use cases.

**For advanced developers:**

* Despite the user-friendly approach, the package remains flexible and extensible.
* Advanced developers have the freedom to explore and fully leverage the package's capabilities, allowing for expansion and customization to meet specific requirements.

By focusing on an intuitive user experience, the package aims to provide accessibility to developers of all skill levels, from those looking for a straightforward setup to those seeking advanced customization options.
