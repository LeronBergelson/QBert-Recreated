# QBert-Recreated

## Q*Bert Description.
Q*bert is an arcade game developed and published by Gottlieb in 1982. It is a 2D action game with puzzle elements that uses isometric graphics to create a pseudo-3D effect. The objective is to change the color of every cube in a pyramid by making the on-screen character hop on top of the cube while avoiding obstacles and enemies.

## Platform.
Recreated using the cross-platform game engine Unity, this Q*bert is a 2D Based Game that utilizes game features and assets based on the original Q*bert.

## Player Controls.
The player can control QBert, getting him to hop on an adjacent platform on the pyramid, using the following controls: 

Numpad 7 or Left Arrow: Move top-left.<br />
Numpad 9 or Up Arrow: Move top-right.<br />
Numpad 1 or Down Arrow: Move bottom-left.<br />
Numpad 3 or Right Arrow : Move bottom-right.<br />

## Pause Menu.
Player can press the “Esc” key at any point during gameplay to pause the game. From there, the player can return to the game, or exit and return to the main menu

## Platform Functionality.
When QBert lands on a platform for the first time, it changes to the colour listed in the “Change To” icon text. Platform remains that colour for rest of session.<br /><br />
![untitled](https://user-images.githubusercontent.com/19450714/37858776-5441f06c-2ee0-11e8-825e-4c2ad35dad53.png)

## Elevator functionality.
When QBert hops onto an elevator, it takes him back to the top platform, and disappears from the level

## Red & Green Ball Functionality.
Every so often, a red or green ball spawns on the second level of the pyramid (right underneath the 
top platform). The balls hop down the pyramid, randomly heading bottom-left or bottom-right with each hop. Red Balls should spawn more often than Green ones. <br /><br />
![giphy](https://user-images.githubusercontent.com/19450714/51068782-e46a0b00-15f0-11e9-8e2c-a0ccb1e68d18.gif)

## Coily.
Behaviour Coily begins as a purple ball, and spawns at the second level near the beginning of the session. It bounces down to the bottom level, behaving just like a red ball. Once it reaches the bottom level, the ball hatches and Coily springs out Coily hops on the platforms and chases Q*Bert across the pyramid It always makes the move that gets it closest to Q*Bert. If there is an even choice, 
Coily randomly  picks from one of the two platforms available. There can only be one Coily present at any point during the level. If there is no Coily on the pyramid, one spawns within the next two or three enemy spawns.
 
## Win Condition.
When QBert changes the colour of each platform on the pyramid, he defeats the level. The pyramid flashes several colours and victory music should play and the player’s bonus points are awarded, before the player is returned to the Main Menu.<br /><br />
![giphy3](https://user-images.githubusercontent.com/19450714/51068784-e46a0b00-15f0-11e9-9baf-5160fca1887a.gif)

## Game Over.
If the player dies and there are no lives remaining, it triggers the Game Over state. The text “Game Over” appears on the screen, and after a few seconds, the player is returned to the main menu.

## High Score.
If, after the player beats the level or suffers a Game Over, she has a high score that cracks the Top 10, she is asked enter her initials, and her score is now in the appropriate slot on the leaderboard screen.

## Death States.
QBert runs into a red or purple ball – after which, he utters his trademark curse word, “@!#?@!”.<br />
QBert runs into Coily– after which, he utters his trademark curse word, “@!#?@!”.<br /><br />
![giphy5](https://user-images.githubusercontent.com/19450714/51068781-e46a0b00-15f0-11e9-9851-d3947590bb3b.gif)
QBert jumps off the pyramid.<br /><br />
![giphy4](https://user-images.githubusercontent.com/19450714/51068785-e46a0b00-15f0-11e9-9900-d9e86c91b313.gif)                                                                                                                              

## Player Lives/Restart.
Player has 3 lives, depicted by the icons on the left side of the screen – 2 present at start of game. Every time the player dies, she loses one life, and 1 of the icons disappears. If the player has a life left after death, she restarts where QBert died on the pyramid, and the state of the pyramid remains the same (for example, if the player landed on 3 platforms before dying, those 3 platforms will remain changed). If the player jumped off the pyramid, QBert restarts at the top platform.

## Coily Defeat
If QBert gets onto an elevator, Coilywill try and follow him, jumping off the pyramid. <br />
If Coily jumps off the pyramid, all enemies disappear and no new enemies spawn for around 5 seconds BUT Coily won’t jump off the platform if QBert lands back on the pyramid before Coilycan jump. He will simply redirect and hunt QBert again. <br /><br />
![giphy2](https://user-images.githubusercontent.com/19450714/51068783-e46a0b00-15f0-11e9-9449-721dc95271d0.gif)

## SFX Implemented, which include the following:
QBert lands on a platform.<br />
Ball lands on a platform (any colour).<br />
QBert lands on an elevator.<br />
QBert collides with Coily.<br />
Coily lands on a platform.<br />
QBert gets a Green Ball.<br />
QBert dies.

## Scoring 
Includes the following:<br />
Change a cube to the destination colour: 25 points.<br />
Catch a green ball: 100 points.<br />
Defeating Coily: 500 points.<br />
Clear a level: 1000 points.<br />
Clear a level with elevators remaining: 100 points for each one.<br />
Green Ball behaviour - If the player touches a green ball, all enemies are frozen for several seconds, and the player is awarded 100 points.

## UI Functional
Score increases at the correct rate.<br />
Life icons decrement each time player dies.<br />
Arrows animate beside the “Change To” pyramid block.<br />

## Leaderboard.
Top 10 scores are visible on the Leaderboard screen from the Main Menu.


