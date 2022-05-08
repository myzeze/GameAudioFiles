using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodMusicParam : MonoBehaviour
{

    private static FMOD.Studio.EventInstance Music;
    // Start is called before the first frame update
    void Start()
    {
        Music = FMODunity.RuntimeManager.CreateInstance("event:/music/Back Ground Music");
        Music.start();
        Music.release();
    }

    public void Progress (float scene, item)
{
        Music.setParameterByName("Scene", scene);
        Music.setParameterByName("Item", item);
}
    // Update is called once per frame
    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
