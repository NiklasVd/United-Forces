using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public List<AudioClip> audioClips;

    void Awake()
    {
        Instance = this;
    }

    public AudioClip GetAudioClip(string name)
    {
        return audioClips.Find((a) => { if (a.name == name) return true; else return false; });
    }
}
