Overview:

This Unity project contains a simple implementation of a Fortune wheel game. The game allows the player to spin the roulette wheel and rewards them based on where the wheel stops.

Instructions:

Setup:

Ensure you have Unity installed on your system.
Open the project in Unity by navigating to the project folder and opening the Assets folder.
Understanding the Code:

The main script controlling the roulette game is Roulette.cs, located in the Scripts folder.
Key variables:
RotatePower: Determines the rotation speed of the roulette wheel when spinning.
StopPower: Determines the deceleration rate of the roulette wheel when stopping.
CheckInterval: Time interval for checking if the rotation has stopped.
Methods:
Rotate(): Initiates the rotation of the roulette wheel.
GetReward(): Determines the reward based on the final position of the wheel.
Win(int Score): Handles the outcome of winning, printing the score.
Customization:

You can adjust the RotatePower, StopPower, and CheckInterval parameters in the Roulette.cs script to tweak the game mechanics.
Modify the SectorSize and RangeOffset constants for adjusting the size of each sector on the roulette wheel.
Running the Game:

Attach the Roulette.cs script to a GameObject representing the roulette wheel in your Unity scene.
Ensure the GameObject has a Rigidbody2D component attached.
Press play in the Unity Editor to run the game and interact with the roulette wheel.
Notes:

This project is a basic implementation and can be extended with additional features such as UI enhancements, sound effects, and more complex reward mechanisms.
Feel free to customize and expand upon the code to suit your specific requirements or game design.
Credits:


Version History:

v1.0 (Date): Initial release.
