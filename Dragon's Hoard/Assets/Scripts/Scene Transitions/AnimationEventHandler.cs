using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public void AnimationFinishedTrigger()
    {
        GetComponent<Animator>().SetBool("Finished", true);
    }

}
