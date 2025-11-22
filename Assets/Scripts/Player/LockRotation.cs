using UnityEngine;

public class LockRotation : MonoBehaviour
{
    // Fix rotation to 0
    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
