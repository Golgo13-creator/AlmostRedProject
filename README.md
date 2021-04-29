# AlmostRedProject

The Almost Red Project repository exists to house a Sports API. The end goal of the project is to allow users to create, view, update, and delete
players, teams, and sports. Two additional tables have been implemented in order to get players by team and by sport. Another table has also been
created in order to get teams by sport. Once a player has been created, they can be assigned a team via the PlayerTeam table and its accompanying 
models and services. A player can also be assigned a sport through the PlayerSport table. These assignments are done by posting a playerteam, 
playersport, or teamsport through the WebAPI. 

  Each post method requires the Ids of the entities involved. For example, posting a new PlayerTeam requires a playerId and a teamId in order to  
match the player to the team, which can be seen using the get function and inputting the teamId in the url. The result will be a playerTeam Id, 
the playerId and the teamId. PostMan can be used to test the endpoints but the project also has swagger enabled without user intervention.  
