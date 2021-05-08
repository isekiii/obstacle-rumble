using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;
    void Start()
    {
        anim["CameraMainMenu"].speed = 0.1f;
    }
}
