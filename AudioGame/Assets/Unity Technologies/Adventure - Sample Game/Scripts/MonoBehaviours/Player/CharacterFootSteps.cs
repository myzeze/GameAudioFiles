using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootSteps : MonoBehaviour {

    private enum CURRENT_TERRAIN { InsideMetal, OutsideMetal, Concrete, Sand };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance foosteps;

    private void Update()
    {
        DetermineTerrain();
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        
        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("InsideMetal"))
            {
                currentTerrain = CURRENT_TERRAIN.InsideMetal;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("OutsideMetal"))
            {
                currentTerrain = CURRENT_TERRAIN.OutsideMetal;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                currentTerrain = CURRENT_TERRAIN.Concrete;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Sand"))
            {
                currentTerrain = CURRENT_TERRAIN.Sand;
            }
        }
    }

    public void SelectAndPlayFootstep()
    {     
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.InsideMetal:
                PlayFootstep(0);
                break;

            case CURRENT_TERRAIN.OutsideMetal:
                PlayFootstep(1);
                break;

            case CURRENT_TERRAIN.Concrete:
                PlayFootstep(3);
                break;

            case CURRENT_TERRAIN.Sand:
                PlayFootstep(2);
                break;

            default:
                PlayFootstep(0);
                break;
        }
    }

    private void PlayFootstep(int terrain)
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/char/footsteps");
        foosteps.setParameterByName("Terrain", terrain);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}