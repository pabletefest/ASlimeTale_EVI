using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private List<MonsterSO> players;
    
    [SerializeField]
    private List<EnemySO> enemies;

    [SerializeField]
    private GameObject PlayerOne;

    [SerializeField]
    private GameObject PlayerTwo;

    [SerializeField]
    private GameObject PlayerThree;

    [SerializeField]
    private GameObject PlayerFour;

    [SerializeField]
    private GameObject EnemyOne;

    [SerializeField]
    private GameObject EnemyTwo;

    [SerializeField]
    private GameObject EnemyThree;

    [SerializeField]
    private GameObject EnemyFour;

    [SerializeField]
    private GameObject OnePlayerPosition;

    [SerializeField]
    private GameObject TwoPlayerPosition;

    [SerializeField]
    private GameObject ThreePlayerPosition;

    [SerializeField]
    private GameObject FourPlayerPosition;

    [SerializeField]
    private GameObject OneEnemyPosition;

    [SerializeField]
    private GameObject TwoEnemiesPosition;

    [SerializeField]
    private GameObject ThreeEnemiesPosition;

    [SerializeField]
    private GameObject FourEnemiesPosition;

    [SerializeField]
    private GameObject TESTPrefabSlime;

    [SerializeField]
    private GameObject TESTPrefabCactoro;

    [SerializeField]
    private GameObject TESTPrefabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        InstantiatePlayers();
        InstantiateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePlayers()
    {
        PlayerOne = TESTPrefabSlime;
        SlimeMove slimeMove = PlayerOne.GetComponent<SlimeMove>();
        slimeMove.enabled = false;
        Instantiate(PlayerOne, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
        PlayerTwo = TESTPrefabCactoro;
        Instantiate(PlayerTwo, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
    }

    void InstantiateEnemies()
    {
        EnemyOne = TESTPrefabEnemy;
        Instantiate(EnemyOne, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.rotation);
        EnemyTwo = TESTPrefabEnemy;
        Instantiate(EnemyTwo, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.rotation);
    }
}
