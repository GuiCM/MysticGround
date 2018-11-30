using UnityEngine;

public class MusicAndAnimationManager : MonoBehaviour
{
    private static bool startMenuAlreadyAnimated;
    private static bool creditsAlreadyAnimated;
    private static MusicAndAnimationManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            startMenuAlreadyAnimated = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        // Disable the animations if already played once (like when is backing from credits scene)
        // This code force the animations to play only a single time, when the player is accessing the menu or the credit scene for the first time
        if (level == 0)
        {
            if (startMenuAlreadyAnimated)
            {
                DisableAllAnimations();
            }
        }
        else if (level == 1)
        {
            if (creditsAlreadyAnimated)
            {
                DisableAllAnimations();
            }
            else
            {
                // Animate once and next time not
                creditsAlreadyAnimated = true;
            }
        }
    }

    private void DisableAllAnimations()
    {
        foreach (Animation anim in FindObjectsOfType<Animation>())
        {
            anim.enabled = false;
        }
    }
}