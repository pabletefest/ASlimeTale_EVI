using System;
using System.Collections;
using UnityEngine;

public static class UtilsHelper
{
    public const string PLAYER_TEAM_KEY = "PlayerTeam";
    public const string MONSTER_LEVEL_KEY = "MonsterLevel";
    public const string MONSTER_HP_KEY = "MonsterCurrentHP";
    public const string MONSTER_MP_KEY = "MonsterCurrentMP";
    public const string MONSTER_EXP_KEY = "MonsterCurrentEXP";
    public const string MONSTER_SKILLS_KEY = "MonsterSkills";

    public static string FormatKeyString(string key, string name) => String.Format($"{key}_{name}");

    public static IEnumerator DelayActionBySeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
