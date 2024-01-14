using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudManager", menuName = "Managers/AudManager")]
public class ManagerAud : ScriptableObject
{
    public List<AudioClip> clip = new();
    public List<AudioClip> sounds = new();

    public IEnumerator SwitchSound(AudioSource aud)
    {
        while (clip.Count > 0)
        {
            foreach (AudioClip clipItem in clip)
            {
                aud.clip = clipItem;
                aud.Play();
                while(aud.isPlaying)
                {
                    yield return null;
                }
            }
            yield return null;
        }
    }
}
