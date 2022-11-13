using UnityEngine;

public class SlimeMonsterInfo : IMonsterInfo
{
    [SerializeField]
    private MonsterSO slimeSO;

    public SlimeMonsterInfo()
    {
        // TODO: LOAD FROM CENTRALIZED LOADER
        slimeSO = Resources.Load<MonsterSO>("SO/Monsters/Slime");
    }

    public string getName() => slimeSO.monsterName;

    public override uint getMaxHP() => slimeSO.baseMaxHP + level;
    public override uint getMaxMP() => slimeSO.baseMaxMP + level;

    public override uint getAttack() => slimeSO.baseAttack + level;
    public override uint getDefense() => slimeSO.baseDefense + level;
    public override uint getMagic() => slimeSO.baseMagic + level;
    public override uint getResistance() => slimeSO.baseResistance + level;
    public override uint getSpeed() => slimeSO.baseSpeed + level;
}