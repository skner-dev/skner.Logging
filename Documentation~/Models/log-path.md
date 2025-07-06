# Log Path

## Overview

The Log Path is a struct that facilitates the definition of a file path. It contains a BasePath, deriving from common system scoped paths and the relative path. In conjunction, they determine a full path pointing to a folder.

## BasePath

The BasePath is an enum that encapsulates Application paths to easily display it in the Unity Inspector:

![LogPath as seen in the Unity Editor](/images/logpath.png)

Here's the BasePath mapping:

| BasePath Type        | Folder Path                                    |
|----------------------|--------------------------------------------------|
| `BasePath.GameFiles`   | [Application.dataPath](https://docs.unity3d.com/ScriptReference/Application-dataPath.html)      |
| `BasePath.AppData`     | [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) |
| `BasePath.StreamingAssets` | [Application.streamingAssetsPath](https://docs.unity3d.com/ScriptReference/Application-streamingAssetsPath.html) |
| `BasePath.None` | No BasePath               |