using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IInteractable
{
    [SerializeField] private string _powerUpName;
    public string InteractionText => _powerUpName;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("PowerUp picked up");
        return true;
    }
}
