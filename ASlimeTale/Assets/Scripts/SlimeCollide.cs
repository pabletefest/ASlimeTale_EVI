using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       switch (other.tag)
        {
            case "Monster":
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
        };
    }
}
