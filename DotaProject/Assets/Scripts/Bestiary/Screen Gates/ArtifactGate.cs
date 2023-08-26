using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArtifactGate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public ArtifactSO artifact { get; private set;}
    [SerializeField] ArtifactPanel artifactPanelPrefab;

    static ArtifactPanel panel;
    [SerializeField] Canvas canvasForArtDesc;
    static public bool safePanel = false; //переменная для сохранения панельки при нажатии на артефакт

    public void Instantiate(ArtifactSO artifact)
    {
        this.artifact = artifact;
        gameObject.name = artifact.itemName;
        GetComponent<Image>().sprite = artifact.icon;
        canvasForArtDesc = transform.parent.GetChild(0).gameObject.GetComponent<Canvas>();
    }

    public void ClickOn()
    {
        safePanel = !safePanel;
        ArtifactPanel.OnChangeSafePanel();
    }

    
    public void CreatePanel()
    {
        Vector3 posPrevSkill = Vector3.zero;//переменная для координат панельки предыдущего скилла
        float deltaY = 7f; //
        bool isFirstSkill = true;

        DestroyPanel();
        panel = Instantiate(artifactPanelPrefab);
        panel.Create(this, canvasForArtDesc);
        foreach (var skill in artifact.itemSkills) //перебираем массив скиллов
        {
            if (isFirstSkill)//проверяем на первый скилл в массиве
            {
                //ставим коорды самого контент филда и сразу расширяем контентфилд на количество скиллов
                //
                posPrevSkill = panel.contentField.transform.position; 
                panel.contentField.sizeDelta += new Vector2(0f, 600f * artifact.itemSkills.Count);
                //
                isFirstSkill = false;
            }
            else //если это не первый скилл, уменьшаем разрез между ними
            {
                deltaY = 5.5f;
            }
            SkillPanel skillPanel = Instantiate(panel.skillPanelPrefab, panel.contentField); // создаем панельку способности
            skillPanel.SetSkillInPanel(skill,transform,panel.transform, 0f); // устанавливаем значения в панельку для скилла
            skillPanel.background.SetActive(false);

            skillPanel.transform.position = posPrevSkill - new Vector3(0f, deltaY, 0f);

            posPrevSkill = skillPanel.transform.position;
        }

    }
    
    public void DestroyPanel()
    {
        if (panel != null)
        {
            panel.Destroy();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!safePanel)
        {
            CreatePanel();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!safePanel)
        {
            DestroyPanel();
        }
    }
}
