using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceDB { get; private set; }

    private static bool alreadyInit = false;

    [SerializeField]
    private Dictionary<string, MonsterInfo> monstersTeam;

    //public MonsterInfo this[string key]
    //{
    //    get => monstersTeam[key];
    //    set => monstersTeam[key] = value;
    //}

    void Awake()
    {
        if (InstanceDB && InstanceDB != this)
        {
            Destroy(InstanceDB);
            return;
        }

        InstanceDB = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (alreadyInit)
            return;

        monstersTeam = new Dictionary<string, MonsterInfo>();

        PlayerPrefs.DeleteKey(UtilsHelper.PLAYER_TEAM_KEY);

        string playerTeam = PlayerPrefs.GetString(UtilsHelper.PLAYER_TEAM_KEY, "Slime");

        foreach (var member in playerTeam.Split(','))
        {
            var monsterInfo = new MonsterInfo(member);

            monsterInfo.level = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_LEVEL_KEY, member), 1);
            monsterInfo.currentHP = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_HP_KEY, member), (int)monsterInfo.getMaxHP());
            monsterInfo.currentMP = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_MP_KEY, member), (int)monsterInfo.getMaxMP());
            monsterInfo.currentExp = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_EXP_KEY, member), 0);

            string skillNames = PlayerPrefs.GetString(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_SKILLS_KEY, member), "");

            if(skillNames != "")
            {
                foreach (var skillName in skillNames.Split(','))
                    if (!monsterInfo.Skills.ContainsKey(skillName))
                        monsterInfo.Skills.Add(skillName, new SkillData(Resources.Load<SkillSO>(String.Format($"SO/Skills/{skillName}"))));
            }

            monstersTeam.Add(member, monsterInfo);
        }

        alreadyInit= true;
    }

    public MonsterInfo getTeamMemberByName(string monsterName) => monstersTeam[monsterName];

    public List<string> getMonstersTeamNames() => monstersTeam.Keys.ToList();   

    public void SaveTeamMembersData()
    {
        List<string> teamNames = new List<string>();

        foreach (var monsterInfo in monstersTeam.Values)
        {
            string monsterName = monsterInfo.getName();
            teamNames.Add(monsterName);
            PlayerPrefs.SetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_LEVEL_KEY, monsterName), (int)monsterInfo.level);
            PlayerPrefs.SetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_HP_KEY, monsterName), (int)monsterInfo.currentHP);
            PlayerPrefs.SetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_MP_KEY, monsterName), (int)monsterInfo.currentMP);
            PlayerPrefs.SetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_EXP_KEY, monsterName), (int)monsterInfo.currentExp);

            PlayerPrefs.SetString(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_SKILLS_KEY, monsterName), String.Join(",", monsterInfo.Skills.Keys));
        }

        PlayerPrefs.SetString(UtilsHelper.PLAYER_TEAM_KEY, String.Join(",", teamNames));
    }

    public void AddTeamMember(String member)
    {
        if (monstersTeam.ContainsKey(member))
            return;

        var monsterInfo = new MonsterInfo(member);

        monsterInfo.level = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_LEVEL_KEY, member), 1);
        monsterInfo.currentHP = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_HP_KEY, member), (int)monsterInfo.getMaxHP());
        monsterInfo.currentMP = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_MP_KEY, member), (int)monsterInfo.getMaxMP());
        monsterInfo.currentExp = (uint)PlayerPrefs.GetInt(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_EXP_KEY, member), 0);

        //string skillNames = PlayerPrefs.GetString(UtilsHelper.FormatKeyString(UtilsHelper.MONSTER_SKILLS_KEY, member), "Bola de Fuego");

        //foreach (var skillName in skillNames.Split(','))
        //    monsterInfo.Skills.Add(skillName, new SkillData(Resources.Load<SkillSO>(String.Format($"SO/Skills/{skillName}"))));

        monstersTeam.Add(member, monsterInfo);
        
    }

    void OnDestroy()
    {
        SaveTeamMembersData();
    }
}
