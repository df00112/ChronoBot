using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Terrain : MonoBehaviour
{

    [SerializeField] private EventReference ambientSound;

    private void Start()
    {
        AudioManager.instance.PlayOneShot(ambientSound, this.transform.position);
    }
}
