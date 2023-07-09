using System;
using UnityEngine;

/// <summary>
/// Contains the VR rig and player controller
/// </summary>
public class FPSPlayer : SingletonMonoBehaviour
{
    private void Start()
    {
        if (m_Initialized)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
