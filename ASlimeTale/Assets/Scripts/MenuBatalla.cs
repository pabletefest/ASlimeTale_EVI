using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBatalla : MonoBehaviour
{

    [SerializeField]
    private GameObject actionSelector;

    [SerializeField]
    private GameObject skillSelector;

    [SerializeField]
    private GameObject itemSelector;

    [SerializeField]
    private Color highlightedColor;

    [SerializeField]
    private List<Text> actionTexts;

    [SerializeField]
    private Text habilidad1;

    [SerializeField]
    private Text habilidad2;

    [SerializeField]
    private Text habilidad3;

    [SerializeField]
    private Text habilidad4;

    int currentAction = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateActionSelection(currentAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentAction == actionTexts.Count - 1)
            {
                currentAction = 0;
            }
            else
            {
                currentAction += 1;
            }
            UpdateActionSelection(currentAction);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction == 0)
            {
                currentAction = actionTexts.Count - 1;
            }
            else
            {
                currentAction -= 1;
            }
            UpdateActionSelection(currentAction);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (currentAction == 1)
            {
                actionSelector.SetActive(false);
                skillSelector.SetActive(true);
                Dictionary<string, SkillData> skills = DataManager.InstanceDB.getTeamMemberByName("Slime").Skills;
                List<string> skillNames = new List<string>(skills.Keys);
                int skillNumber = skillNames.Count;
                if (skillNumber >= 4)
                {
                    habilidad1.text = skillNames[0];
                    habilidad2.text = skillNames[1];
                    habilidad3.text = skillNames[2];
                    habilidad4.text = skillNames[3];
                }
                else if (skillNumber == 3)
                {
                    habilidad1.text = skillNames[0];
                    habilidad2.text = skillNames[1];
                    habilidad3.text = skillNames[2];
                    habilidad4.text = "";
                }
                else if (skillNumber == 2)
                {
                    habilidad1.text = skillNames[0];
                    habilidad2.text = skillNames[1];
                    habilidad3.text = "";
                    habilidad4.text = "";

                }
                else if (skillNumber == 1)
                {
                    habilidad1.text = skillNames[0];
                    habilidad2.text = "";
                    habilidad3.text = "";
                    habilidad4.text = "";
                }
                else if (skillNumber == 0)
                {
                    habilidad1.text = "No hay habilidades desbloqueadas.";
                }
            }
            if (currentAction == 4)
			{
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                Cursor.visible = true;
            }
        }
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i = 0; i<actionTexts.Count; ++i)
        {
            if (i == selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            } else
            {
                actionTexts[i].color = Color.black;
            }
        }
    }


    public void EnableSkillSelection(bool enabled)
    {
        skillSelector.SetActive(enabled);
    }

    public void EnableActionSelection(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableItmeSelection(bool enabled)
    {
        itemSelector.SetActive(enabled);
    }

    public void EnableMenu(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
