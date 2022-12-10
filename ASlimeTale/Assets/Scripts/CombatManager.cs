using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private List<MonsterSO> players;
    
    [SerializeField]
    private List<EnemySO> enemies;

    enum BarsPosition : int
    {
        TOP = 0, MIDDLE_TOP, MIDDLE_BOT, BOT
    }

    [SerializeField]
    private List<GameObject> statusBars;

    [SerializeField]
    private GameObject camera1Player;

    [SerializeField]
    private GameObject camera2Players;

    [SerializeField]
    private GameObject camera3Players;

    [SerializeField]
    private GameObject camera4Players;

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
    private GameObject TESTPrefabEnemy;

    // Start is called before the first frame update
    void Start()
    {
        statusBars = new List<GameObject>();
        statusBars.Insert((int)BarsPosition.TOP, GameObject.Find("Canvas").transform.Find("BarraMonstruoTop").gameObject);
        statusBars.Insert((int)BarsPosition.MIDDLE_TOP, GameObject.Find("Canvas").transform.Find("BarraMonstruoMiddleTop").gameObject);
        statusBars.Insert((int)BarsPosition.MIDDLE_BOT, GameObject.Find("Canvas").transform.Find("BarraMonstruoMiddleBot").gameObject);
        statusBars.Insert((int)BarsPosition.BOT, GameObject.Find("Canvas").transform.Find("BarraMonstruoBot").gameObject);

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
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, OnePlayerPosition.transform.Find("PositionPlayer1").transform.position, OnePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);

                    camera1Player.SetActive(true);
                }
                break;
            case 2:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);

                    camera2Players.SetActive(true);
                }
                break;
            case 3:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);

                    PlayerThree = Instantiate(players[2].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                    var player3bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player3bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[2].barIcon;
                    player3bar.SetActive(true);

                    camera3Players.SetActive(true);
                }
                break;
            case 4:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);

                    PlayerThree = Instantiate(players[2].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                    var player3bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player3bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[2].barIcon;
                    player3bar.SetActive(true);

                    PlayerFour = Instantiate(players[3].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer4").transform.position, FourPlayerPosition.transform.Find("PositionPlayer4").transform.rotation);
                    var player4Bar = statusBars[(int)BarsPosition.BOT];
                    player4Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[3].barIcon;
                    player4Bar.SetActive(true);

                    camera4Players.SetActive(true);
                }
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
