using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactablePoint;
    [SerializeField] private float _interactablePointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _colliderCount;
    public WeaponManager _weaponManager;

    void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        _colliderCount = Physics.OverlapSphereNonAlloc(_interactablePoint.position, _interactablePointRadius, _colliders, _interactableMask);
    
        if (_colliderCount > 0)
        {
            IInteractable interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(this);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactablePoint.position, _interactablePointRadius);
    }
}
