using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecruitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnPoint;

    private string monsterName;

    [SerializeField]
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        monsterName = PlayerPrefs.GetString("RecruitableMonster");

        InstantiateMonster();
        SetupDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //Provisional press enter to recruit
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //TODO Add monster to team
            DataManager.InstanceDB.AddTeamMember(monsterName);
            //SceneManager.LoadScene("LlanuraAfable");
            AsyncOperation asyncOp = SceneManager.UnloadSceneAsync("Reclutar");
            asyncOp.completed += (AsyncOperation op) => {
                
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("LlanuraAfable"));
                var sceneGOs = SceneManager.GetActiveScene().GetRootGameObjects();

                foreach (var go in sceneGOs)
                    go.SetActive(true);
            };
        }
    }
    void InstantiateMonster()
    {
        var monster = Resources.Load<MonsterSO>(string.Format($"SO/Monsters/{monsterName}"));
        Instantiate(monster.monsterPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }

    void SetupDialogue()
	{
		switch (monsterName)
		{
            case "Cactoro":
                dialogueText.text = "Ándale limo, dame tacos al pastor y me uniré a ti.";
                break;

            case "Abelago":
                dialogueText.text = "¿Unirme a ti? ¡Perfecto! Necesito un compañero para irme de aventuras. Bzzz";
                break;

            case "Mudfish":
                dialogueText.text = "Puedo ir contigo pero vas a tener que regarme a menudo.";
                break;
        }
	}
}
