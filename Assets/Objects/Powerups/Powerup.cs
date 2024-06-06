using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IInteractable
{
    [SerializeField] protected string _powerupName;
    public string InteractionText => _powerupName;

    public PowerupEffect _powerupEffect;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_powerupName + " picked up");
        _powerupEffect.ApplyEffect(interactor.gameObject);
        gameObject.SetActive(false);
        return true;
    }

    void FixedUpdate()
    {
        if (transform.parent == null)
        {
            transform.Rotate(Vector3.up, 1.0f);
        }
    }
}
