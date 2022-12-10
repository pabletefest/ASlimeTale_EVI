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
        if (!DataManager.InstanceDB) 
            return;

        players.Clear();

        var names = DataManager.InstanceDB.getMonstersTeamNames();

        foreach (var name in names)
        {
            var monster = Resources.Load<MonsterSO>(string.Format($"SO/Monsters/{name}"));
            players.Add(monster);
        }

        switch (players.Count)
        {
            case 1:
                PlayerOne = Instantiate(players[0].monsterPrefab, OnePlayerPosition.transform.Find("PositionPlayer1").transform.position, OnePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                break;
            case 2:
                PlayerOne = Instantiate(players[0].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                PlayerTwo = Instantiate(players[1].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                break;
            case 3:
                PlayerOne = Instantiate(players[0].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                PlayerTwo = Instantiate(players[1].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer2").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                PlayerThree = Instantiate(players[2].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                break;
            case 4:
                PlayerOne = Instantiate(players[0].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer1").transform.position, FourPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                PlayerTwo = Instantiate(players[1].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer2").transform.position, FourPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                PlayerThree = Instantiate(players[2].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer3").transform.position, FourPlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                PlayerFour = Instantiate(players[3].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer4").transform.position, FourPlayerPosition.transform.Find("PositionPlayer4").transform.rotation);
                break;
        }

        SlimeMove slimeMove = PlayerOne.GetComponent<SlimeMove>();
        slimeMove.enabled = false; 
    }

    void InstantiateEnemies()
    {
        EnemyOne = TESTPrefabEnemy;
        Instantiate(EnemyOne, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.rotation);
        EnemyTwo = TESTPrefabEnemy;
        Instantiate(EnemyTwo, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.rotation);
    }
}
