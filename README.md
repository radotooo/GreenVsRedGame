# GreenVsRedGame
**Summary:**  
Green vs Red is a game played on a 2d grid that in theory can be infinite.
Each cell on this grid can be either green (represented by 1) or red (represented by 0). The game always receives an initial state of the grid wich we will call "Generation Zero". After that a set of 4 rules are applied across the grid and those rules form the next generation.

**Rules:**  
 **1.** Each red cell that is surrounded by exactly 3 or exactly 6 green cells will also become green in the next generation.  
 **2.** A red cell will stay red in the next generation if it has either 0,1,2,4,5,7 or 8 green neighbours.  
 **3.** Each green cell surrounded by 0,1,4,5,7 or 8 green neighbours will become red in the next generation.  
 **4.** A green cell will stay green in the next generation if it has either 2,3 or 6 green neighbours.  

**Input:**  
  - Size of the grid width height(constrains: width <=  height < 1000)
  - The next 'height' lines should contain strings created by '0' and '1' (example "0000" , "1111")
  - Coordinates for cell to observe and turns till the game end (example 1,0,10)

**Output:**  
Single integer representing how many time observed cell has changed color to green for the given turns.
