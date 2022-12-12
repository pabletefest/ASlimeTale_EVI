using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, CALCULATING, PLAYERTURN, ENEMYTURN, PLAYERANIM, ENEMYANIM, FULLROUND, WON, LOST }

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

    [SerializeField]
    private MenuBatalla menuController;

    List<GameObject> allCharacters = new List<GameObject>();

    public BattleState state;

    Dictionary<GameObject, MonsterSO> playerStats;
    Dictionary<GameObject, EnemySO> enemyStats;

    private GameObject unitCurrentTurn = null; // Current unit for this turn (player or enemy)

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        menuController.onSkillSelected += PlayerAttackCallback;
    }

    void OnDisabled()
    {
        menuController.onSkillSelected -= PlayerAttackCallback;
    }

    void InstantiatePlayers()
    {
        if (!DataManager.InstanceDB) 
            return;

        players.Clear();

        var names = DataManager.InstanceDB.getMonstersTeamNames();
        playerStats = new Dictionary<GameObject, MonsterSO>();

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
                    allCharacters.Add(PlayerOne);
                    playerStats.Add(PlayerOne, players[0]);
                    camera1Player.SetActive(true);
                }
                break;
            case 2:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);
                    allCharacters.Add(PlayerOne);
                    playerStats.Add(PlayerOne, players[0]);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);
                    allCharacters.Add(PlayerTwo);
                    playerStats.Add(PlayerTwo, players[1]);

                    camera2Players.SetActive(true);
                }
                break;
            case 3:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);
                    allCharacters.Add(PlayerOne);
                    playerStats.Add(PlayerOne, players[0]);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer2").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);
                    allCharacters.Add(PlayerTwo);
                    playerStats.Add(PlayerTwo, players[1]);

                    PlayerThree = Instantiate(players[2].monsterPrefab, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.position, ThreePlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                    var player3bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player3bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[2].barIcon;
                    player3bar.SetActive(true);
                    allCharacters.Add(PlayerThree);
                    playerStats.Add(PlayerThree, players[2]);

                    camera3Players.SetActive(true);
                }
                break;
            case 4:
                {
                    PlayerOne = Instantiate(players[0].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer1").transform.position, FourPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
                    var player1Bar = statusBars[(int)BarsPosition.TOP];
                    player1Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[0].barIcon;
                    player1Bar.SetActive(true);
                    allCharacters.Add(PlayerOne);
                    playerStats.Add(PlayerOne, players[0]);

                    PlayerTwo = Instantiate(players[1].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer2").transform.position, FourPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
                    var player2Bar = statusBars[(int)BarsPosition.MIDDLE_TOP];
                    player2Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[1].barIcon;
                    player2Bar.SetActive(true);
                    allCharacters.Add(PlayerTwo);
                    playerStats.Add(PlayerTwo, players[1]);

                    PlayerThree = Instantiate(players[2].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer3").transform.position, FourPlayerPosition.transform.Find("PositionPlayer3").transform.rotation);
                    var player3bar = statusBars[(int)BarsPosition.MIDDLE_BOT];
                    player3bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[2].barIcon;
                    player3bar.SetActive(true);
                    allCharacters.Add(PlayerThree);
                    playerStats.Add(PlayerThree, players[2]);

                    PlayerFour = Instantiate(players[3].monsterPrefab, FourPlayerPosition.transform.Find("PositionPlayer4").transform.position, FourPlayerPosition.transform.Find("PositionPlayer4").transform.rotation);
                    var player4Bar = statusBars[(int)BarsPosition.BOT];
                    player4Bar.transform.Find("Mask/Icon").gameObject.GetComponent<Image>().sprite = players[3].barIcon;
                    player4Bar.SetActive(true);
                    allCharacters.Add(PlayerFour);
                    playerStats.Add(PlayerFour, players[3]);

                    camera4Players.SetActive(true);
                }
                break;
        }

        SlimeMove slimeMove = PlayerOne.GetComponent<SlimeMove>();
        slimeMove.enabled = false; 
    }

    void InstantiateEnemies()
    {
        int enemyNumber = Random.Range(1, players.Count + 1);
        EnemySO enemy = Resources.Load<EnemySO>(string.Format($"SO/Enemies/Knight"));
        enemyStats = new Dictionary<GameObject, EnemySO>();
        switch (enemyNumber)
        {
            case 1:
                Debug.Log(enemy.enemyName);
                Debug.Log(OneEnemyPosition.transform.Find("PositionEnemy1").transform.position);
                Debug.Log(OneEnemyPosition.transform.Find("PositionEnemy1").transform.rotation);
                EnemyOne = Instantiate(enemy.enemyPrefab, OneEnemyPosition.transform.Find("PositionEnemy1").transform.position, OneEnemyPosition.transform.Find("PositionEnemy1").transform.rotation);
                enemyStats.Add(EnemyOne, enemy);
                
                allCharacters.Add(EnemyOne);
                break;
            case 2:
                EnemyOne = Instantiate(enemy.enemyPrefab, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy1").transform.rotation);
                EnemyTwo = Instantiate(enemy.enemyPrefab, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.position, TwoEnemiesPosition.transform.Find("PositionEnemy2").transform.rotation);
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                enemyStats.Add(EnemyOne, enemy);
                enemyStats.Add(EnemyTwo, enemy);
                break;
            case 3:
                EnemyOne = Instantiate(enemy.enemyPrefab, ThreeEnemiesPosition.transform.Find("PositionEnemy1").transform.position, ThreeEnemiesPosition.transform.Find("PositionEnemy1").transform.rotation);
                EnemyTwo = Instantiate(enemy.enemyPrefab, ThreeEnemiesPosition.transform.Find("PositionEnemy2").transform.position, ThreeEnemiesPosition.transform.Find("PositionEnemy2").transform.rotation);
                EnemyThree = Instantiate(enemy.enemyPrefab, ThreeEnemiesPosition.transform.Find("PositionEnemy3").transform.position, ThreeEnemiesPosition.transform.Find("PositionEnemy3").transform.rotation);
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                allCharacters.Add(EnemyThree);
                enemyStats.Add(EnemyOne, enemy);
                enemyStats.Add(EnemyTwo, enemy);
                enemyStats.Add(EnemyThree, enemy);
                break;
            case 4:
                EnemyOne = Instantiate(enemy.enemyPrefab, FourEnemiesPosition.transform.Find("PositionEnemy1").transform.position, FourEnemiesPosition.transform.Find("PositionEnemy1").transform.rotation);
                EnemyTwo = Instantiate(enemy.enemyPrefab, FourEnemiesPosition.transform.Find("PositionEnemy2").transform.position, FourEnemiesPosition.transform.Find("PositionEnemy2").transform.rotation);
                EnemyThree = Instantiate(enemy.enemyPrefab, FourEnemiesPosition.transform.Find("PositionEnemy3").transform.position, FourEnemiesPosition.transform.Find("PositionEnemy3").transform.rotation);
                EnemyFour = Instantiate(enemy.enemyPrefab, FourEnemiesPosition.transform.Find("PositionEnemy4").transform.position, FourEnemiesPosition.transform.Find("PositionEnemy4").transform.rotation);
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                allCharacters.Add(EnemyThree);
                allCharacters.Add(EnemyFour);
                enemyStats.Add(EnemyOne, enemy);
                enemyStats.Add(EnemyTwo, enemy);
                enemyStats.Add(EnemyThree, enemy);
                enemyStats.Add(EnemyFour, enemy);
                break;
        }
    }

    IEnumerator SetupBattle()
    {
        statusBars = new List<GameObject>();
        statusBars.Insert((int)BarsPosition.TOP, GameObject.Find("Canvas").transform.Find("BarraMonstruoTop").gameObject);
        statusBars.Insert((int)BarsPosition.MIDDLE_TOP, GameObject.Find("Canvas").transform.Find("BarraMonstruoMiddleTop").gameObject);
        statusBars.Insert((int)BarsPosition.MIDDLE_BOT, GameObject.Find("Canvas").transform.Find("BarraMonstruoMiddleBot").gameObject);
        statusBars.Insert((int)BarsPosition.BOT, GameObject.Find("Canvas").transform.Find("BarraMonstruoBot").gameObject);

        InstantiatePlayers();
        InstantiateEnemies();

        yield return new WaitForSeconds(1f);

        state = BattleState.CALCULATING;
        CalculateTurn();

    }

    void CalculateTurn()
    {

        float maxSpeed = 0.0f;
        float currentSpeed = 0.0f;
        GameObject fastestCharacter = null;
        foreach(GameObject character in allCharacters)
        {
            if (playerStats.ContainsKey(character))
            {
                currentSpeed = (float)playerStats[character].baseSpeed * Random.Range(0.9f, 1.11f);
            } else if (enemyStats.ContainsKey(character))
            {
                currentSpeed = (float)enemyStats[character].baseSpeed * Random.Range(0.9f, 1.11f);
            }
            if (currentSpeed > maxSpeed)
            {
                maxSpeed = currentSpeed;
                fastestCharacter = character;
            }
        }

        unitCurrentTurn = fastestCharacter;
        allCharacters.Remove(fastestCharacter);

        if (enemyStats.ContainsKey(fastestCharacter))
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();

        }else if (playerStats.ContainsKey(fastestCharacter))
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        } else
        {
            state = BattleState.FULLROUND;
            FullRound();
        }
    }

    void FullRound()
    {
        switch (players.Count)
        {
            case 1:
                allCharacters.Add(PlayerOne);
                break;
            case 2:
                allCharacters.Add(PlayerOne);
                allCharacters.Add(PlayerTwo);
                break;
            case 3:
                allCharacters.Add(PlayerOne);
                allCharacters.Add(PlayerTwo);
                allCharacters.Add(PlayerThree);
                break;
            case 4:
                allCharacters.Add(PlayerOne);
                allCharacters.Add(PlayerTwo);
                allCharacters.Add(PlayerThree);
                allCharacters.Add(PlayerFour);
                break;
        }

        switch (enemies.Count)
        {
            case 1:
                allCharacters.Add(EnemyOne);
                break;
            case 2:
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                break;
            case 3:
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                allCharacters.Add(EnemyThree);
                break;
            case 4:
                allCharacters.Add(EnemyOne);
                allCharacters.Add(EnemyTwo);
                allCharacters.Add(EnemyThree);
                allCharacters.Add(EnemyFour);
                break;
        }

        state = BattleState.CALCULATING;
        CalculateTurn();
    }

    void PlayerTurn()
    {
        menuController.EnableMenu(true);

        //string selectedAction = "";
        //while(selectedAction.Equals(""))
        //{
        //    selectedAction = menuController.isPlayerTurn();
        //}
        //StartCoroutine(PlayerAnimation(selectedAction));
    }

    void PlayerAttackCallback(string skillName)
    {
        SkillSO skill = playerStats[unitCurrentTurn].skills.Find(x => x.skillName == skillName);

        if (!skill) // Default skill if something wrong occurred
            skill = playerStats[unitCurrentTurn].baseSkill;

        StartCoroutine(PlayerAttackCoroutine(skill)); 
    }

    IEnumerator PlayerAttackCoroutine(SkillSO skill)
    {
        unitCurrentTurn.transform.LookAt(EnemyOne.transform);

        //yield return new WaitForSeconds(0.1f);

        Animator playerAnim = unitCurrentTurn.GetComponent<Animator>();

        playerAnim.SetTrigger("attack");

        // Wait until the animation played half way
        while ((playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1) < 0.5f)
            yield return null;

        Vector3 spawnPoint = unitCurrentTurn.transform.position;
        spawnPoint.z += 2;
        spawnPoint.y += 2;

        GameObject vfx = Instantiate(skill.vfx, spawnPoint, unitCurrentTurn.transform.rotation);
        vfx.transform.localScale *= 2;
        Destroy(vfx, 2.5f);
    }

    void EnemyTurn()
    {
        menuController.EnableMenu(false);
    }
}
