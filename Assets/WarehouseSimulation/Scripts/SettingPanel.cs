using Audio.Warehouse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SettingPanel : MonoSingleton<SettingPanel>
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("OnMusicButtonPressed", 0.2f);
        //Invoke("OnSoundButtonPressed", 0.2f);
        //OnMusicButtonPressed();
    }
    private void OnMusicButtonPressed()
    {
        GenericAudioManager.Instance.ToggleBackgroundMusicMute(true);
        Debug.Log("Audio Stop");
    }
    private void OnSoundButtonPressed()
    {
        GenericAudioManager.Instance.TogleSfxMute(true);
    }
  }
