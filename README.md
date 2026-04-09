Fork from Intersect engine adding a dedicated build location ../Builds/
Also adds NPC follower functionality:

NPCs can be assigned to follow a player via event commands
Uses !Aggressive as the condition — any non-aggressive event-spawned NPC can follow
Follow speed controlled by NPC speed setting in editor
Teleports to catch up if player gets too far away
Instance-aware — stops following if player changes instance

## New Event Commands
NPC Follow: Start — assigns the last spawned non-aggressive NPC to follow the player
NPC Follow: Stop — stops following and despawns the follower NPC

## Use cases
Escort quests
Pets/companions
Any friendly NPC that should accompany the player

Also added the ability to use "Text" property in gui labels to display text and get dynamic variable updates from player variables for things like custom skill levels

## Known Issues
Follower npcs may duplicate when switching rooms
