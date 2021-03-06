﻿class Layers
{
    public const int DEFAULT = 0;
    public const int TRANSPARENT_FX = 1;
    public const int IGNORE_RAYCAST = 2;

    public const int WATER = 4;
    public const int UI = 5;

    public const int CAMERA = 8;
    public const int MANAGER = 9;

}

class AI {
	public const float THINK_TIME_VERY_HARD = 4.5f;
	public const float THINK_TIME_HARD = 7.5f;
	public const float THINK_TIME_MED = 9.5f;
	public const float THINK_TIME_EASY = 11.5f;
}

class Indices {
	public const int SHIP_PLAYER = 0;
	public const int SHIP_ENEMY = 1;
}

class Prefs {
	public const string PREV_SCENE = "PREV_SCENE";
    public const string GAME_RESULT = "GAME_RESULT";
}

class PlanetNames {
	public const string NORMAL_PLANET = "Barren Colony";
	public const string HYBRID_PLANET = "Capital Planet";
	public const string SOLDIER_PLANET = "Cyborg Colony";
	public const string REACTOR_PLANET = "Research Vessel";
	public const string RESOURCE_PLANET = "Crystal Colony";
}

class Notifications {
	public const string NO_SOLDIER_RESOURCE_MSG = "Not enough resources for soldiers!";
	public const string NO_UPGRADE_RESOURCE_MSG = "Not enough resources for upgrades!";
}

class GamePlay 
{
	public const int UPGRADE_COST = 100;
	public const int LOAD_UNITS = 5;
	public const int SHIP_COST = 300;
	public const int SHIP_CAPACITY = 100;
	public const int SOLDIER_UNIT = 5;
	public const int SOLDIER_COST = 10;

	public const float PLANET_TICK = 1.5f;
	public const float PLANET_CHANGE = 1.0f;
	public const int RESOURCE_RATE = 10;
	public const int SOLDIERS_PER_SKULL = 50;

	public const string PLAYER_WIN = "You Won!";
	public const string PLAYER_LOSS = "You Lost!";
}