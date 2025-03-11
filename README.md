# Unity Breakout Clone

A modern implementation of the classic arcade game "Breakout" built with Unity, optimized for Windows platforms.

<img src="https://github.com/sPappalard/BreakoutClone/assets/149112901/36595eb7-0d48-4a8a-81a8-2bec6aa9a605" alt="GIF">

## Overview

This Breakout clone recreates the addictive gameplay of the classic arcade game where players control a paddle to bounce a ball and break bricks. The game features colorful graphics, smooth controls, particle effects, and sound effects to enhance the gaming experience.

## Features

- **Classic Gameplay**: Control a paddle to bounce the ball and destroy all bricks to win
- **Dynamic Brick System**: Bricks with multiple hit points that change color as they take damage
- **Particle Effects**: Visual feedback when bricks are hit and when the paddle is destroyed
- **Sound Effects**: Audio feedback for ball collisions, game over, and victory
- **Game States**: Start screen, gameplay, game over, and victory screens
- **Responsive Controls**: Smooth paddle movement with keyboard/mouse input

## Game Mechanics

### Paddle Control
The paddle can be moved horizontally using the left and right arrow keys or the mouse. It's confined within screen boundaries to ensure fair gameplay.

### Ball Physics
- The ball maintains a constant velocity throughout gameplay
- The ball's direction changes realistically upon collision with the paddle, bricks, and walls
- If the ball falls below the paddle (into the "death zone"), the player loses

### Brick System
- Bricks are arranged in a grid pattern at the top of the screen
- Each brick can have multiple hit points (1-3)
- Bricks change color based on remaining hit points:
  - Three lives: Blue
  - Two lives: Green
  - One life: Red
- When a brick is hit, particle effects matching its current color are displayed
- The game is won when all bricks are destroyed

## Code Structure

### Main Components

- **GameManager (`Gamemanager.cs`)**: Controls game states, handles scene management, and tracks the number of bricks
- **Ball Controller (`BallController.cs`)**: Manages ball physics, velocity, and collision detection
- **Bar Controller (`BarControl.cs`)**: Handles paddle movement and screen boundaries
- **Brick Spawner (`BrickSpawner.cs`)**: Creates the grid of bricks at the start of the game
- **Brick Manager (`BrickManager.cs`)**: Handles individual brick behavior, hit points, and destruction

### Key Scripts

#### GameManager
The central controller that manages:
- Game states (start, playing, game over, victory)
- Scene loading/unloading
- UI panels visibility
- Tracking the number of bricks
- Victory and defeat conditions

#### BallController
Handles the ball's behavior:
- Maintains constant velocity regardless of collision angles
- Detects collisions with the paddle, bricks, and walls
- Triggers game over when the ball enters the death zone
- Plays sound effects on collision

#### BarControl
Controls the paddle:
- Handles user input (keyboard/mouse)
- Restricts movement within screen boundaries
- Adjustable movement speed via the Unity Inspector

#### BrickSpawner
Manages the brick layout:
- Creates a grid of bricks at game start
- Configurable rows and columns
- Adjustable spacing between bricks
- Informs GameManager of the total brick count

#### BrickManager
Controls individual brick behavior:
- Manages hit points for each brick
- Changes brick color based on remaining hit points
- Generates particle effects on collision
- Notifies GameManager when a brick is destroyed

## Installation and Setup

1. Clone this repository
2. Open the project in Unity (recommended version: 2020.3 or higher)
3. Open the main scene from the Scenes folder
4. Press Play in the Unity Editor to test the game
5. Build the game for Windows platform using Unity's build settings

## Controls

- **Start Game**: Left mouse button click
- **Move Paddle**: Left/Right arrow keys or mouse movement
- **Restart After Game Over**: Left mouse button click

## Development

This project is built using:
- Unity Game Engine
- C# for scripting
- Unity's built-in physics system for ball dynamics
- Particle systems for visual effects

## Future Enhancements

Potential features for future versions:
- Power-ups (multi-ball, paddle extension, etc.)
- Multiple levels with increasing difficulty
- High score system
- Additional visual and audio effects
- Mobile platform support


## License

This project is licensed under the MIT License --->  [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
