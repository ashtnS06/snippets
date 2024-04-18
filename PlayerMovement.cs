using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI SpeedoText;
    public float accelerationForce = 0f;
    public float rotationSpeed = 5f;
    public float downforce = 20f;
    public float MoveDrag = 3;
    public float breakDrag = 0.3f;
    private Rigidbody2D rb;
    public float speedLimit = 70f;
    public float RateOfAccel = 1f;
    public float Deccel = 100f;

    private CarSounds carSounds; // Reference to the CarSounds script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable default gravity

        // Get the reference to CarSounds script
        carSounds = GetComponent<CarSounds>();
    }

    private void Decceleration()
{
    if (rb.velocity.magnitude > 0 && accelerationForce > 0)
    {
        accelerationForce = accelerationForce - Deccel;

    }
}

    void FixedUpdate()
    {
        float currentSpeed = rb.velocity.magnitude;
        float adjustedRotationSpeed = rotationSpeed + (1 - Mathf.Clamp01(currentSpeed / 1)) * 0.95f; // Adjust the values as needed
        float acceleration = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");

        
        
        
        if (Input.GetKey(KeyCode.LeftControl) && accelerationForce > -40)
        {
            accelerationForce = accelerationForce - 1f;
        }



        // Rotate the car
        if (currentSpeed > 0.5f)
        {
            float rotateAmount = Mathf.Min((-steering * adjustedRotationSpeed) / currentSpeed, 12);
            rb.MoveRotation(rb.rotation + rotateAmount);
        }

        Decceleration();

        SpeedoText.text = ((rb.velocity.magnitude * 2.23693629f) * 18).ToString("0") + (" mph");

        rb.AddForce(transform.up * accelerationForce);

        if (acceleration > 0)
        {
            if (accelerationForce < speedLimit)
            {
                accelerationForce = accelerationForce + RateOfAccel;
            }

            Deccel = 3;

            rb.drag = MoveDrag;

            if (((rb.velocity.magnitude * 2.23693629f) * 13) == 40f)
            {
                accelerationForce = 0f;
            }

        }
        else if (acceleration < 0)
        {
            rb.drag = breakDrag;
            Deccel = 7;
            // Trigger downshift effect when braking
            if (Input.GetAxis("Vertical") < 0 && carSounds != null)
            {
                carSounds.StartDownshift();
            }
        }

        
    }
}