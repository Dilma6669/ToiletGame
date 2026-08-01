using UnityEngine;
using UnityEngine.InputSystem;

namespace UltimateCC
{
    public class NPCController : MonoBehaviour
    {
        private PlayerInputManager inputManager;

        private void Awake()
        {
            inputManager = GetComponent<PlayerInputManager>();
        }

        private void Start()
        {
            if (inputManager != null && inputManager.playerControls != null)
            {
                inputManager.playerControls.Player.Disable();
            }
        }

        private void Update()
        {
            if (inputManager != null)
            {
                typeof(PlayerInputManager)
                    .GetField("input_Walk", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, 1f);

                typeof(PlayerInputManager)
                    .GetField("input_Jump", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, false);

                typeof(PlayerInputManager)
                    .GetField("input_Dash", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, false);

                typeof(PlayerInputManager)
                    .GetField("input_Crouch", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, false);

                typeof(PlayerInputManager)
                    .GetField("input_WallGrab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, false);

                typeof(PlayerInputManager)
                    .GetField("input_WallClimb", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(inputManager, 0f);
            }
        }
    }
}