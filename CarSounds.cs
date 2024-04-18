using UnityEngine;

public class CarSounds : MonoBehaviour
{
    // Engine sound parameters
    private AudioSource engineSound;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    private float originalPitch;

    // Downshift parameters
    private bool isDownshifting = false;
    private float downshiftPitchIncrease = 0.4f; // Default increase in pitch during downshift
    private float maxDownshiftPitchIncrease = 0.5f; // Maximum increase in pitch during downshift
    private float downshiftSpeedThreshold = 4f; // Speed threshold for downshifting

    private Rigidbody2D carRigidbody;
    private float previousVelocityMagnitude;

    public float CarPitchSound;

    void Start()
    {
        // Get the AudioSource component attached to the car
        engineSound = GetComponent<AudioSource>();

        // Store the original pitch
        originalPitch = engineSound.pitch;

        // Get the Rigidbody2D component attached to the car
        carRigidbody = GetComponent<Rigidbody2D>();

        // Initialize previous velocity magnitude
        previousVelocityMagnitude = carRigidbody.velocity.magnitude;
    }

    void Update()
    {
        // Adjust pitch based on car speed
        float speedRatio = carRigidbody.velocity.magnitude / CarPitchSound; // Adjust the divisor as needed
        float targetPitch = Mathf.Lerp(minPitch, maxPitch, speedRatio);
        engineSound.pitch = targetPitch;

        // Check if the car is decelerating
        float currentVelocityMagnitude = carRigidbody.velocity.magnitude;
        if (currentVelocityMagnitude < previousVelocityMagnitude && currentVelocityMagnitude >= downshiftSpeedThreshold)
        {
            StartDownshift();
        }

        // Update previous velocity magnitude
        previousVelocityMagnitude = currentVelocityMagnitude;

        // Handle downshift effect
        if (isDownshifting)
        {
            // Increase pitch slightly during downshift, with dynamic adjustment based on speed
            float downshiftIncrease = Mathf.Lerp(0, maxDownshiftPitchIncrease, Mathf.Clamp01(carRigidbody.velocity.magnitude / downshiftSpeedThreshold));
            float targetDownshiftPitch = originalPitch + downshiftPitchIncrease + downshiftIncrease;
            engineSound.pitch = Mathf.Lerp(engineSound.pitch, targetDownshiftPitch, Time.deltaTime * 5f);

            // Reset downshift flag if pitch reaches the target
            if (engineSound.pitch >= targetDownshiftPitch)
            {
                engineSound.pitch = targetDownshiftPitch;
                isDownshifting = false;
            }
        }
    }

    public void StartDownshift()
    {
        // Trigger downshift effect
        isDownshifting = true;
    }
}
