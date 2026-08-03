using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UltimateCC
{
    public class RampGate : MonoBehaviour
    {
        public Collider2D secondRamp;
        public Collider2D firstRamp;

        public PlayerMain player;
        
        private bool enteredTrigger;
        
        private void Update()
        {
           // SetRampsToDefault();

            if (enteredTrigger)
            {
                float verticalInput = player.InputManager.Input_WallClimb;
                Collider2D playerCollider = player.CapsuleCollider2D;

                if (verticalInput == 0) // if not pushing up
                {
                    Debug.Log($"fuck not pushing up");
                    if (firstRamp != null)
                        Physics2D.IgnoreCollision(playerCollider, firstRamp, true);
                    if (secondRamp != null)
                        Physics2D.IgnoreCollision(playerCollider, secondRamp, true);
                }
                else if (verticalInput == 1) // If pushing up
                {
                    Debug.Log($"fuck pushing up");
                    if (firstRamp != null)
                        Physics2D.IgnoreCollision(playerCollider, firstRamp, false);
                    if (secondRamp != null)
                        Physics2D.IgnoreCollision(playerCollider, secondRamp, true);
                }

            }
        }
        
        
        private void OnTriggerStay2D(Collider2D other)
        {
            enteredTrigger = true;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            enteredTrigger = false;
        }

        private void SetRampsToDefault()
        {
            Collider2D playerCollider = player.CapsuleCollider2D;
            if (secondRamp != null) Physics2D.IgnoreCollision(playerCollider, secondRamp, false); 
            if (firstRamp != null) Physics2D.IgnoreCollision(playerCollider, firstRamp, false);
        }
    }
}