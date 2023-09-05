using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArtifactGate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public ArtifactSO artifact { get; private set;}
    [SerializeField] ArtifactPanel artifactPanelPrefab;

    static private ArtifactPanel panel;
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
        float delta = 0f;
        List<SkillPanel> skills = new List<SkillPanel>();//создаем новый лист для скиллов
        DestroyPanel();//уничтожаем панель, если существует

        panel = Instantiate(artifactPanelPrefab);
        panel.Create(this, canvasForArtDesc);
        foreach (var skill in artifact.itemSkills)
        {
            SkillPanel skillPanel = Instantiate(panel.SkillPanelPrefab, panel.ContentField);
            skillPanel.SetSkillInPanel(skill);
            skillPanel.SetActiveBackground(false);
            delta += skillPanel.Background.sizeDelta.y;
            skills.Add(skillPanel);
        }

        panel.AddScaleForBackground(new Vector2(0, delta));
        panel.ChangeScaleForContentField(new Vector2 (panel.ContentField.sizeDelta.x, panel.Background.sizeDelta.y));
        
        Vector3 point = panel.DownPoint.transform.localPosition - new Vector3(0, 550f, 0);

        foreach (var skill in skills)
        {
            skill.transform.localPosition = point;
            point -= new Vector3 (0, skill.Background.sizeDelta.y);
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
