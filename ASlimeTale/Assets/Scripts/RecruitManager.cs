using UnityEngine;
using UnityEngine.SceneManagement;

public class RecruitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject recruitableMonster;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Provisional press enter to recruit
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //TODO Add monster to team
            DataManager.InstanceDB.AddTeamMember("Cactoro");
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
}
