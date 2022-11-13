using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    const string PLAYER_TEAM_KEY = "PlayerTeam";
    const string MONSTER_LEVEL_KEY = "MonsterLevel";
    const string MONSTER_HP_KEY = "MonsterCurrentHP";
    const string MONSTER_MP_KEY = "MonsterCurrentMP";
    const string MONSTER_EXP_KEY = "MonsterCurrentEXP";
    const string MONSTER_SKILLS_KEY = "MonsterSkills";

    [SerializeField]
    private static List<MonsterInfo> monstersTeam;

    // Start is called before the first frame update
    void Start()
    {
        monstersTeam = new List<MonsterInfo>();

        string playerTeam = PlayerPrefs.GetString(PLAYER_TEAM_KEY, "Slime");

        foreach (var member in playerTeam.Split(','))
        {
            var monsterInfo = new MonsterInfo(member);

            monsterInfo.level = (uint)PlayerPrefs.GetInt(FormatKeyString(MONSTER_LEVEL_KEY, member), 1);
            monsterInfo.currentHP = (uint)PlayerPrefs.GetInt(FormatKeyString(MONSTER_HP_KEY, member), (int)monsterInfo.getMaxHP());
            monsterInfo.currentMP = (uint)PlayerPrefs.GetInt(FormatKeyString(MONSTER_MP_KEY, member), (int)monsterInfo.getMaxMP());
            monsterInfo.currentExp = (uint)PlayerPrefs.GetInt(FormatKeyString(MONSTER_EXP_KEY, member), 0);

            string skillNames = PlayerPrefs.GetString(FormatKeyString(MONSTER_SKILLS_KEY, member), "Ataque");

            foreach (var skillName in skillNames.Split(','))
                monsterInfo.skills.Add(skillName, new SkillData(Resources.Load<SkillSO>(String.Format($"SO/Skills/{skillName}"))));

            monstersTeam.Add(monsterInfo);
        }
    }

    public static void SaveTeamMembersData()
    {
        List<string> teamNames = new List<string>();

        foreach (var monsterInfo in monstersTeam)
        {
            string monsterName = monsterInfo.getName();
            teamNames.Add(monsterName);
            PlayerPrefs.SetInt(FormatKeyString(MONSTER_LEVEL_KEY, monsterName), (int)monsterInfo.level);
            PlayerPrefs.SetInt(FormatKeyString(MONSTER_HP_KEY, monsterName), (int)monsterInfo.currentHP);
            PlayerPrefs.SetInt(FormatKeyString(MONSTER_MP_KEY, monsterName), (int)monsterInfo.currentMP);
            PlayerPrefs.SetInt(FormatKeyString(MONSTER_EXP_KEY, monsterName), (int)monsterInfo.currentExp);
            
            PlayerPrefs.SetString(FormatKeyString(MONSTER_SKILLS_KEY, monsterName), String.Join(",", monsterInfo.skills.Keys));
        }

        PlayerPrefs.SetString(PLAYER_TEAM_KEY, String.Join(",", teamNames));
    }

    public static string FormatKeyString(string key, string name)
    {
        return String.Format($"{key}_{name}");
    }

    void OnDestroy()
    {
        //SaveTeamMembersData();
    }
}
