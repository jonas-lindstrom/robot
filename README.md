# Robot
Accept a set of commands and then simulate whether an object can move without going outside the given area. The object cannot reenter the area to "save" the end result.<br>

Input:<br>
● A string containing 4 comma separated integers describing:<br>
  \- The size of the table as two integers [width, height].<br>
  \- The object's starting position as two integers [x, y].<br>
● A string containing comma separated integers, as commands, ending with a 0.<br>

Output:<br>
● If the simulation succeeded: The objects final position as two integers [x, y].<br>
● If the simulation failed: [-1, -1] should be returned.<br>
