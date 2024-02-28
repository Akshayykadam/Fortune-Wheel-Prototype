using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    // Rotation power when spinning the roulette
    public float RotatePower;

    // Deceleration power when stopping the rotation
    public float StopPower;

    // Interval for checking if rotation stopped
    public float CheckInterval = 0.5f;

    private Rigidbody2D rbody;
    private int inRotate; // Flag to indicate if roulette is currently rotating
    private float elapsedTime;

    // Offset to adjust sector calculation
    private const float RangeOffset = 22f;

    // Size of each sector on the roulette
    private const float SectorSize = 45f;

    private void Start()
    {
        // Get reference to the Rigidbody2D component
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // If the roulette is rotating
        if (rbody.angularVelocity > 0)
        {
            // Decrease angular velocity over time to simulate deceleration
            rbody.angularVelocity -= StopPower * Time.deltaTime;
            // Clamp angular velocity to ensure it doesn't go below 0 or exceed a certain value
            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }
        else if (inRotate == 1) // If rotation stopped and reward needs to be determined
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;
            // Check if enough time has passed since rotation stopped
            if (elapsedTime >= CheckInterval)
            {
                // Determine and assign reward, reset rotation state
                GetReward();
                inRotate = 0;
                elapsedTime = 0f;
            }
        }
    }

    // Method to initiate rotation of the roulette
    public void Rotate()
    {
        // If the roulette is not already rotating
        if (inRotate == 0)
        {
            // Apply torque to the roulette to start rotation
            rbody.AddTorque(RotatePower);
            // Set the rotation state to indicate the roulette is now rotating
            inRotate = 1;
        }
    }

    // Method to determine and assign reward based on final roulette position
    public void GetReward()
    {
        // Get the current rotation angle of the roulette
        float rot = transform.eulerAngles.z;

        // Calculate the sector the roulette pointer is pointing to
        int sector = Mathf.FloorToInt(rot / (360f / 12f)) % 12;

        // Calculate the target angle within the sector
        float targetAngle = sector * (360f / 12f);

        // Set the rotation angle to align with the target sector
        GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, targetAngle);

        // Calculate the reward based on the sector
        int score = (sector + 1) * 100;

        // Adjust win probability based on the score
        // Higher score implies lower probability
        float probabilityFactor = Mathf.Clamp01(1.0f / (score / 100.0f));

        // Generate a random number between 0 and 1
        float randomValue = UnityEngine.Random.value;

        // If the random value is less than the adjusted probability factor, it's a win
        if (randomValue < probabilityFactor)
        {
            // Special case: if score is 1200, treat it as 100
            if (score == 1200)
                score = 100;

            // Call Win method with the calculated score
            Win(score);
        }
        else
        {
            // It's not a win, call Win method with a score of 0
            Win(0);
        }
    }




    // Method to handle winning outcome
    public void Win(int Score)
    {
        // Print the score
        print(Score);
    }
}


