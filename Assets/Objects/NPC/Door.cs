using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _doorName;
    public string InteractionText => _doorName;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Door opened");
        return true;
    }
}
