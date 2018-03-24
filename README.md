# QBert-Recreated

## Q*Bert Description
Q*bert is an arcade game developed and published by Gottlieb in 1982. It is a 2D action game with puzzle elements that uses isometric graphics to create a pseudo-3D effect. The objective is to change the color of every cube in a pyramid by making the on-screen character hop on top of the cube while avoiding obstacles and enemies.

## Recreated
Re-done using the cross-platform game engine, Unity, this Q*Bert, 2D Based Game, utilizes game features and assets based on the original Q*bert.

## In Game Features
Main Menu Functionality.
Leaderboard.

## Player Controls

The player can control Q*Bert, getting him to hop on an adjacent platform on the pyramid, using the 
following controls: 

Numpad 7 or Left Arrow: Move top-left.
Numpad 9: Move top-right.
Numpad1: Move bottom-left.
Numpad3: Move bottom-right.

## Pause Menu:
Player can press the “Esc” key at any point during gameplay to pause the game. From there, the player 
can return to the game, or exit and return to the main menu

## Platform Functionality
When Q*Bert lands on a platform for the first time, it changes to the colour listed in the “Change To” icon text. Platform remains that colour for rest of session.

## Win Condition
When Q*Bert changes the colour of each platform on the pyramid, he defeats the level. The pyramid flashes several colours and victory music should play and the player’s bonus points are awarded, before the player is returned to the Main 


## Game Over
If the player dies and there are no lives remaining, it triggers the Game Over state. The text “Game Over” appears on the screen, and after a few seconds, the player is returned to the main menu.
#High Score
If, after the player beats the level or suffers a Game Over, she has a high score that cracks the Top 10, she is asked enter her initials, and her score is now in the appropriate slot on the leaderboard screen.
#Death States 
Q*Bert runs into a red or purple ball – after which, he utters his trademark curse word, “@!#?@!”.
Q*Bert runs into Coily– after which, he utters his trademark curse word, “@!#?@!”.
Q*Bert jumps off the pyramid.

## Player Lives/Restart.
Player has 3 lives, depicted by the icons on the left side of the screen – 2 present at start of game. Every time the player dies, she loses one life, and 1 of the icons disappears. If the player has a life left after death, she restarts where Q*Bert died on the pyramid, and the state of the pyramid remains the same (for example, if the player landed on 3 platforms before dying, those 3 platforms will remain changed). If the player jumped off the pyramid, Q*Bert restarts at the top platform.

## Coily Defeat
If Q*Bert gets onto an elevator, Coilywill try and follow him, jumping off the pyramid
If Coily jumps off the pyramid, all enemies disappear and no new enemies spawn for around 5 seconds BUT Coily won’t jump off the platform if Q*Bert lands back on the pyramid before Coilycan jump. He will simply redirect and hunt Q*Bert again

## SFX Implemented, which include the following:
Q*Bert lands on a platform
Ball lands on a platform (any colour)
Q*Bert lands on an elevator
Q*Bert collides with Coily
Coilylands on a platform
Q*Bert gets a Green Ball
Q*Bert dies

## Scoring 
– includes the following:
Change a cube to the destination colour: 25 points.
Catch a green ball: 100 points.
Defeating Coily: 500 points.
Clear a level: 1000 points.
Clear a level with elevators remaining: 100 points for each one.
Green Ball behaviour - If the player touches a green ball, all enemies are frozen for several seconds, and the player is awarded 100 points.

## UI Functional
Score increases at the correct rate.
Life icons decrement each time player dies.
Arrows animate beside the “Change To” pyramid block.
Leaderboard.
Top 10 scores are visible on the Leaderboard screen from the Main Menu.


