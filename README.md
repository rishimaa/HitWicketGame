Here is a brief desciption of how I have created the doofus-pulpit game with a sample game play video.
The JSON file is inside the 'StreamingAssets' folder.
There is a json.cs script for the data structure used to represent the JSON data in Unity

Objects:
1. cube: as doofus. The scripts attached are:
   
	move.cs script to change movement with arrow keys. The move script takes input from the json file for player speed

	score_main.cs to update score.

	camera_follow.cs script so the camera follows the cube

3. Pulpits

4. empty game object 'GameObject' where the toggle.cs script is attached to activate and deactivate pulpits after taking input from the json file and 
represent timer on each pulpit

5. empty game object 'json' where the game_json.cs file is attached to load the game data from the json file
All these scripts are there inside the assets folder

6. A canvas with TextMeshProUGUI to represent score and game over. This gets updated by the functionality UpdateScoreText() and DisplayGameOver()
inside the toggle.cs script

The game play video link is below:

