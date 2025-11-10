using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Pause Game");
        }
    }
}
