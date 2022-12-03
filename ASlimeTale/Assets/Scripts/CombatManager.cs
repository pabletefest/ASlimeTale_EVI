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
    private GameObject OnePlayerPosition;

    [SerializeField]
    private GameObject TwoPlayerPosition;

    [SerializeField]
    private GameObject ThreePlayerPosition;

    [SerializeField]
    private GameObject FourPlayerPosition;

    [SerializeField]
    private GameObject TESTPrefabSlime;

    [SerializeField]
    private GameObject TESTPrefabCactoro;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOne = TESTPrefabSlime;
        SlimeMove slimeMove = PlayerOne.GetComponent<SlimeMove>();
        slimeMove.enabled = false;
        Instantiate(PlayerOne, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer1").transform.rotation);
        PlayerTwo = TESTPrefabCactoro;
        Instantiate(PlayerTwo, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.position, TwoPlayerPosition.transform.Find("PositionPlayer2").transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
