using UnityEngine;
using UnityEngine.UI;

public class SliderValueSaver : MonoBehaviour
{
    public Slider rotationSpeedSlider;

    private string rotationSpeedKey = "RotationSpeed";

    private void Start()
    {
        // Load the saved rotation speed value or set a default value if it's not present
        float savedRotationSpeed = PlayerPrefs.GetFloat(rotationSpeedKey, 5f);
        rotationSpeedSlider.value = savedRotationSpeed;
    }

    private void ChangeRotationSpeed(float newValue)
    {
        // Save the new rotation speed value
        PlayerPrefs.SetFloat(rotationSpeedKey, newValue);
        PlayerPrefs.Save(); // Persist the changes

        // Apply the new rotation speed to your logic
        // ...
    }

    private void OnEnable()
    {
        // Add listener for when the value of the slider changes
        rotationSpeedSlider.onValueChanged.AddListener(ChangeRotationSpeed);
    }

    private void OnDisable()
    {
        // Remove the listener when the script is disabled or destroyed
        rotationSpeedSlider.onValueChanged.RemoveListener(ChangeRotationSpeed);
    }
}
