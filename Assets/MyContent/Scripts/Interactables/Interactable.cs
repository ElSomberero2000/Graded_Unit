using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; // Radius of the interaction point
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
      if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position); // Makes player move to the interaction point                                                                                            
            if (distance <= radius)                                                            // when interaction with an object so they dont walk through it
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red; // Draws red wireframe sphere in the editor to indicate where the interaction points are for interactables
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
