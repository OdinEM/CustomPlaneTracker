using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public AudioSource audioSource; 
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }
}