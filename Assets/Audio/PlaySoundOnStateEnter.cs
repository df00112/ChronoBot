using UnityEngine;
using FMODUnity;

public class PlaySoundOnStateEnter : StateMachineBehaviour
{
    [SerializeField]
    private EventReference soundEvent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            FMOD.Studio.EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvent);
            soundInstance.start();
            soundInstance.release();
    }
}
