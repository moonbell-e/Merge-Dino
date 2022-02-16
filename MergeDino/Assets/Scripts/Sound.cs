using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private string _name;

    public string Name
    {
        get { return _name; }
        set { Name = value; }
    }

    [SerializeField]  private AudioClip _clip;

    public AudioClip Clip
    {
        get { return _clip; }
        set { Clip = value; }
    }

    [Range(0f, 1f)]
    [SerializeField]
    private float _volume;

    public float Volume
    {
        get { return _volume;  }
        set { Volume = value; }
    }

    public AudioSource Source;

}
