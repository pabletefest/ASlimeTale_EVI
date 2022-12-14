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

    [SerializeField]
    private Text recruitText;

    private bool canRecruit = false;

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
        if (Input.GetKeyDown(KeyCode.Space) && canRecruit)
        {
            //Add monster to team
            DataManager.InstanceDB.AddTeamMember(monsterName);
            //SceneManager.LoadScene("LlanuraAfable");
            AsyncOperation asyncOp = SceneManager.UnloadSceneAsync("Reclutar");
            asyncOp.completed += (AsyncOperation op) => {
                
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("LlanuraAfable"));
                var sceneGOs = SceneManager.GetActiveScene().GetRootGameObjects();

                foreach (var go in sceneGOs)
                    if (go.name != monsterName)
                    {
                        go.SetActive(true);
                        if (go.name.Equals("Monsters"))
                        {
                            go.transform.Find(monsterName).gameObject.SetActive(false);
                        }
                    }
            };
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("LlanuraAfable");
            AsyncOperation asyncOp = SceneManager.UnloadSceneAsync("Reclutar");
            asyncOp.completed += (AsyncOperation op) => {

                SceneManager.SetActiveScene(SceneManager.GetSceneByName("LlanuraAfable"));
                var sceneGOs = SceneManager.GetActiveScene().GetRootGameObjects();

                foreach (var go in sceneGOs)
                    if (go.name != monsterName)
                    {
                        if (go.name.Equals("Slime"))
                        {
                            go.transform.position = new Vector3(go.transform.position.x + 3f, go.transform.position.y, go.transform.position.z);
                        }
                        go.SetActive(true);
                    }
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
                if(PlayerPrefs.GetInt("enemiesBeaten") >= 2)
                {
                    canRecruit = true;
                    dialogueText.text = "Ándale limo, dame unos tacos al pastor y me uniré a ti.";
                    recruitText.text = "Presiona Espacio para darle los tacos.";
                }
                else
                {
                    int enemiesLeft = 2 - PlayerPrefs.GetInt("enemiesBeaten");
                    if(enemiesLeft == 1)
                    {
                        dialogueText.text = "Ándale limo, te ves algo flojo. Derrota a " + enemiesLeft + " enemigo más y me uniré.";
                        recruitText.text = "Presiona Espacio para volver al mapa.";
                    }
                    else
                    {
                        dialogueText.text = "Ándale limo, te ves algo flojo. Derrota a " + enemiesLeft + " enemigos más y me uniré.";
                        recruitText.text = "Presiona Espacio para volver al mapa.";
                    }
                }
                break;

            case "Abelago":
                if (PlayerPrefs.GetInt("enemiesBeaten") >= 1)
                {
                    canRecruit = true;
                    dialogueText.text = "Bzzz ¿Unirme a ti? ¡Perfecto! Necesito un compañero para irme de aventuras. Bzzz";
                    recruitText.text = "Presiona Espacio para contestarle 'Bzzz'.";
                }
                else
                {
                    int enemiesLeft = 1 - PlayerPrefs.GetInt("enemiesBeaten");
                    dialogueText.text = "Bzzz ¡Tengo miedo! Derrota a " + enemiesLeft + " enemigo más y me iré de aventura contigo.";
                    recruitText.text = "Presiona Espacio para volver al mapa.";
                }
                break;

            case "Mudfish":
                if(PlayerPrefs.GetInt("enemiesBeaten") >= 3)
                {
                    canRecruit = true;
                    dialogueText.text = "Puedo ir contigo pero vas a tener que regarme a menudo.";
                    recruitText.text = "Presiona Espacio para tirarle un cubo de agua.";
                }
                else
                {
                    int enemiesLeft = 3 - PlayerPrefs.GetInt("enemiesBeaten");
                    if (enemiesLeft == 1)
                    {
                        dialogueText.text = "Pareces un pez fuera del agua. Derrota a " + enemiesLeft + " enemigo más y me pensaré si voy contigo.";
                        recruitText.text = "Presiona Espacio para volver al mapa.";
                    }
                    else
                    {
                        dialogueText.text = "Pareces un pez fuera del agua. Derrota a " + enemiesLeft + " enemigos más y me pensaré si voy contigo.";
                        recruitText.text = "Presiona Espacio para volver al mapa.";
                    }
                }
                
                break;
        }
	}
}
