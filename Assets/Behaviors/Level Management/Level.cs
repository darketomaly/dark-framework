using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DarkFramework
{
    [System.Serializable]
    public class Level
    {
        public LeveLReference m_Name;
        public AssetReference m_Asset;
    }

    public enum LeveLReference
    {
        Landing,
        Playground,
        Tutorial
    }
}
