using System;
using UnityEngine;

namespace skner.Logging.Models
{

    [Serializable]
    public struct LogPath
    {
        public BasePath LocationType;
        public string RelativePath;

        internal LogPath(BasePath locationType, string relativePath)
        {
            LocationType = locationType;
            RelativePath = relativePath;
        }

        public enum BasePath
        {
            GameFiles,
            AppData,
            StreamingAssets,
            None
        }

        public readonly string GetCompletePath()
        {
            string completePath;
            switch (LocationType)
            {
                case BasePath.GameFiles:
                    completePath = Application.dataPath + "/" + RelativePath;
                    break;
                case BasePath.AppData:
                    completePath = Application.persistentDataPath + "/" + RelativePath;
                    break;
                case BasePath.StreamingAssets:
                    completePath = Application.streamingAssetsPath + "/" + RelativePath;
                    break;
                case BasePath.None:
                default:
                    completePath = RelativePath;
                    break;
            }

            if (!completePath.EndsWith("/"))
            {
                completePath += "/";
            }

            return completePath;
        }
    }

}