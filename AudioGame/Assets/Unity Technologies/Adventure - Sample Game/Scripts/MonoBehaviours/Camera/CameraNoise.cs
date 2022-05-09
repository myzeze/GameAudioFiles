using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoise : MonoBehaviour
{
  

  private void startCamera()

  {
      FMODUnity.RuntimeManager.PlayOneShot("event:/Camera/Turn");
  }

  private void stopCamera()

  {
      FMODUnity.RuntimeManager.PlayOneShot("event:/Camera/Stop");
  }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
