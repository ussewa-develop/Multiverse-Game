using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArtifactGate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [field: SerializeField] public ArtifactSO artifact { get; private set;}
    [SerializeField] ArtifactPanel artifactPanelPrefab;

    private RectTransform scrollView;
    static private ArtifactPanel panel;
    [SerializeField] Canvas canvasForArtDesc;
    static public bool safePanel = false; //переменная для сохранения панельки при нажатии на артефакт

    public void Initialize(ArtifactSO artifact, Canvas canvas, RectTransform scrollView)
    {
        if(artifact != null)
        {
            this.artifact = artifact;
            gameObject.name = artifact.itemName;
            GetComponent<Image>().sprite = artifact.icon;
        }
        canvasForArtDesc = canvas;
        this.scrollView = scrollView;
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
        CheckHorizontalBorders(transform, panel);
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
        
        Vector3 point = panel.DownPoint.transform.localPosition - new Vector3(0, 550f, 0); //550f - просто оптимальная разница

        foreach (var skill in skills)
        {
            skill.transform.localPosition = point;
            point -= new Vector3 (0, skill.Background.sizeDelta.y);
        }
    }
    
    public void CheckHorizontalBorders(Transform point, ArtifactPanel panel)
    {
        float distanceToCenter = scrollView.sizeDelta.x/2f;
        float localPosPoint = point.parent.localPosition.x;
        float currentX;

        if (localPosPoint <= distanceToCenter) //число в диапазоне от 0 до до половины разрешения экрана
        {
            currentX = distanceToCenter - localPosPoint; 
        }
        else //число в диапазоне от половины разрешения экрана до всего разрешения
        {
            currentX = localPosPoint - distanceToCenter; 
            currentX *= -1f;
        }

        float shiftFactor = scrollView.sizeDelta.x / 4f;
        float offsetX = currentX / shiftFactor;
        float offsetY = 3f;

        panel.transform.position = transform.position - new Vector3(-offsetX, offsetY, 0);
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
