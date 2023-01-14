using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("enemiesBeaten", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.InstanceDB.lastBattleWon)
        {
            StartCoroutine(ShadingDieEnemyCoroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       switch (other.tag)
        {
            case "Monster":

                // Destroy to ensure enemy despawns if scene change happens before fading out finishes
                var lastEnemyFought = GameObject.Find(PlayerPrefs.GetString("FoughtEnemy"));

                if (lastEnemyFought)
                    Destroy(lastEnemyFought);

                PlayerPrefs.SetString("RecruitableMonster", other.name);
                LoadAdditiveSceneAsync("Reclutar");
                break;

            case "Enemy":
                PlayerPrefs.SetString("FoughtEnemy", other.name);
                LoadAdditiveSceneAsync("Combat");
                break;

            default:
                break;
        }

    }

    private void LoadAdditiveSceneAsync(string sceneName)
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOp.completed += (AsyncOperation op) =>
        {
            var sceneGOs = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var go in sceneGOs)
                go.SetActive(false);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            sceneGOs = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var go in sceneGOs)
                go.SetActive(true);
        };
    }

    private IEnumerator ShadingDieEnemyCoroutine()
    {
        string lastEnemy = PlayerPrefs.GetString("FoughtEnemy");
        DataManager.InstanceDB.lastBattleWon = false;
        GameObject enemyGO = GameObject.Find(lastEnemy);
        enemyGO.GetComponent<Animator>().SetTrigger("die");
        yield return new WaitForSeconds(2f);
        SkinnedMeshRenderer renderer = enemyGO.transform.Find("Body").GetComponent<SkinnedMeshRenderer>();
        StartCoroutine(ShadingUtilities.FadeOutGameObjectCoroutine(renderer));
    }
}
