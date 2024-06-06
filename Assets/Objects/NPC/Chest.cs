using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _chestName;
    public string InteractionText => _chestName;

    private Animator _animator;
    //private AudioSource _audioSource;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        //_audioSource = GetComponent<AudioSource>();
    }

    public bool Interact(Interactor interactor)
    {

        // Trigger the chest opening animation
        // Play the chest opening sound
        // Spawn loot

        _animator.SetTrigger("Open");
        //_audioSource.Play();
        return true;
    }
}