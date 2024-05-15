using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _chestName;
    public string InteractionText => _chestName;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Chest opened");
        return true;
    }
}
