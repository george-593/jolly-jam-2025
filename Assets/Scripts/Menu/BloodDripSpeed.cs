using UnityEngine;

public class BloodDripSpeed : MonoBehaviour
{
    public float animationSpeed = 1.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.speed = animationSpeed;
        }
    }
}