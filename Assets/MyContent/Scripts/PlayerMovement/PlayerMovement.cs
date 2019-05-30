using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;
    PlayerMotor motor;

    public bool crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Move our player to what we hit
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable
               Interactable interactable = hit.collider.GetComponent<Interactable>();
                // if we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);

                }
            }
        }

        Crouched();
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus); // Makes the player pawn run towards the focussed target
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget(); // Makes the player pawn stop running towards the focussed target and enter the idle state
    }

    private void Crouched() // TODO: Remove debug logs (for testing purposes)
    {
        // If crouched is true then stealth is ongoing else enemies will be aware of player and will run to them regardless of positioning
        if (crouched == false && Input.GetKeyDown(KeyCode.Space)) // stealth toggle on
        {
            crouched = true;
            Debug.Log("Crouched");
        }
        else if (crouched == true && Input.GetKeyDown(KeyCode.Space)) // stealth toggle off
        {
            crouched = false;
            Debug.Log("Uncrouched");
        }
    }
}

