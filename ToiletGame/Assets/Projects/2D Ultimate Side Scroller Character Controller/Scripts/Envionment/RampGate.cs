using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UltimateCC
{
    public class RampGate : MonoBehaviour
    {
        public Collider2D upRamp;
        public Collider2D downRamp;

        public PlayerMain player;
        
        private void Start()
        {
            if (EssentialPhysics.IgnoreRamps == false)
                return;
            
            StartCoroutine(DelayedIgnoreCollision());
        }

        private IEnumerator DelayedIgnoreCollision()
        {
            yield return new WaitForSeconds(1);
            if (player == null) yield break;
            Collider2D playerCollider = player.CapsuleCollider2D;
            
            // Default state: ignore ramp by default until entered and evaluated
            if (upRamp != null) Physics2D.IgnoreCollision(playerCollider, upRamp, true);
            //if (downRamp != null) Physics2D.IgnoreCollision(playerCollider, downRamp, true);
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (EssentialPhysics.IgnoreRamps == false)
                return;
            
            PlayerMain targetPlayer = other.GetComponent<PlayerMain>();
            if (targetPlayer == null) return;

            // Check your vertical input (adjust if your input property name differs)
            float verticalInput = targetPlayer.InputManager.Input_WallClimb;
            Collider2D playerCollider = targetPlayer.CapsuleCollider2D;

            // If pressing UP (greater than 0), stop ignoring (walk on it). Otherwise, ignore collision.
            bool shouldIgnore = verticalInput <= 0f;

            if (upRamp != null)
                Physics2D.IgnoreCollision(playerCollider, upRamp, shouldIgnore);

            // if (downRamp != null)
            //     Physics2D.IgnoreCollision(playerCollider, downRamp, shouldIgnore);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerMain targetPlayer = other.GetComponent<PlayerMain>();
            if (targetPlayer == null) return;

            Collider2D playerCollider = targetPlayer.CapsuleCollider2D;

            // Optional: Re-enable ignore or reset when leaving the box if needed, 
            // or leave it based on your design flow.
        }
    }
}