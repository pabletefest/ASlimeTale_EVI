using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    public MonsterSO stats;

    public SlimeMonsterInfo slimeInfo;

    // Start is called before the first frame update
    void Start()
    {
        slimeInfo = new SlimeMonsterInfo();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Monster name: {slimeInfo.getName()}");
        Debug.Log($"Level: {slimeInfo.level}");
        Debug.Log($"Current HP: {slimeInfo.currentHP}");
        Debug.Log($"Current MP: {slimeInfo.currentMP}");
        Debug.Log($"Current EXP: {slimeInfo.currentExp}");
        Debug.Log($"Max HP: {slimeInfo.getMaxHP()}");
        Debug.Log($"Max MP: {slimeInfo.getMaxMP()}");
        Debug.Log($"Attack: {slimeInfo.getAttack()}");
        Debug.Log($"Defense: {slimeInfo.getDefense()}");
        Debug.Log($"Magic: {slimeInfo.getMagic()}");
        Debug.Log($"Resistance: {slimeInfo.getResistance()}");
        Debug.Log($"Speed: {slimeInfo.getSpeed()}");
    }
}
