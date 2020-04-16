# CIS 410 Assignment 2


## Overview

Made by Benjamin Massey, Matthew Struble and Michael Welch for UO CIS 410 Spring Term 2020.

Based on the "John Lemon's Haunted Jaunt: 3D Beginner" Unity 3D tutorial. 

[Link to tutorial.](https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner)

## Contributions

Ben did the Player Characters Part 1 and 2 sections, along with the linear interpolation addition

Matt did Enemies Part 1 and 2 sections, along with the dot product addition

Michael did The Camera, Ending the Game and Audio sections, along with the particle effect addition

## Dot Product

Added a text display in the top left corner that shows how close the player is to the location that ends the game.

this is implemented in /Assets/Scripts/PlayerMovement.cs

This is done by taking the difference of the transformation vector of the GameEnding object and the JohnLemon object,
creating the vector between them, and then taking the dot product of itself and square rooting it to find the distance 
via dot product

## Linear Interpolation

Added an effect where the closer the player gets to an enemy, the stronger the vignette effect becomes.

This is implemented in /Assets/Scripts/VignetteLI.cs and placed upon the GlobalPost object.

It simply calculates the distance between the player and each enemy, finds the closest enemy,
gets a value based on that, and uses that value as a linear interpolation coefficient for
the intensity of the vignette effect.

This can easily be seen by observing the black around the lens at the very beginning, and
then walking over to the gargoyle to the up-left of the player. As the player approaches, 
the black around the lens will intensify.

## Particle Effect

Added a trail to the ghosts that is emitted when they walk.

Its implemented in the /Assets/Prefabs/Ghost.prefab

It uses a particle system to create a trail attached to the ghost's tail,
to show the player where the ghosts have been walking recently.
