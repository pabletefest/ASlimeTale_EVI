using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo
{
    [SerializeField]
    private MonsterSO monsterSo;

    public uint level { get; set; }
    public uint currentHP { get; set; }
    public uint currentMP { get; set; }
    public uint currentExp { get; set; }

    private Dictionary<string, SkillData> skills;
    public Dictionary<string, SkillData> Skills => skills;

    private Dictionary<string, SkillData> learnableSkills;
    public Dictionary<string, SkillData> LearnableSkills => learnableSkills;

    public string getName() => monsterSo.monsterName;

    public uint getMaxHP() => monsterSo.baseMaxHP + level;
    public uint getMaxMP() => monsterSo.baseMaxMP + level;

    public uint getAttack() => monsterSo.baseAttack + level;
    public uint getDefense() => monsterSo.baseDefense + level;
    public uint getMagic() => monsterSo.baseMagic + level;
    public uint getResistance() => monsterSo.baseResistance + level;
    public uint getSpeed() => monsterSo.baseSpeed + level;

    public MonsterInfo(string monsterName)
    {
        // TODO: LOAD FROM CENTRALIZED LOADER
        monsterSo = Resources.Load<MonsterSO>(string.Format($"SO/Monsters/{monsterName}"));
        skills = new Dictionary<string, SkillData>();
        learnableSkills = new Dictionary<string, SkillData>();

        skills.Add(monsterSo.baseSkill.skillName, new SkillData(monsterSo.baseSkill));

        foreach(var skill in monsterSo.skills)
        {
            learnableSkills.Add(skill.skillName, new SkillData(skill));
        }
    }
}