using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactPanel : MonoBehaviour
{
    [Header("\t\t\tArtifact values")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescText;
    [Space]
    [Header("\t\t\tOther")]
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject scrollView;
    [SerializeField] private SkillPanel skillPanelPrefab;
    [SerializeField] private Canvas canvasPrefab;
    [SerializeField] private RectTransform contentField;
    [SerializeField] private Button exitButton;
    [SerializeField] private Transform downPoint;
    [Space]
    [Header("\t\t\tValues")]
    [SerializeField] private float ratioForDelta = 43.5f;
    [SerializeField] private float ratio = 40f;
    [SerializeField] private float downStatsY = 0;
    private RectTransform generalScrollView;

    //public values
    public RectTransform Background { get => background.GetComponent<RectTransform>(); }
    public SkillPanel SkillPanelPrefab { get => skillPanelPrefab; }
    public RectTransform ContentField { get => contentField; }
    public Transform DownPoint { get => downPoint; }
    public static Action SafePanelEvent;

    private void Start()
    {
        EventController.SwitchMenu += Destroy;
        SafePanelEvent += EnableExitButton;
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
        SafePanelEvent -= EnableExitButton;
        
    }


    public void AddScaleForBackground(Vector2 vect)
    {
        Background.sizeDelta += vect;
    }

    public void ChangeScaleForBackground(Vector3 vect)
    {
        Background.sizeDelta = vect;
    }

    public void AddScaleForContentField(Vector2 vect)
    {
        contentField.sizeDelta += vect;
    }

    public void ChangeScaleForContentField(Vector2 vect)
    {
        contentField.sizeDelta = vect;
    }

    public void EnableExitButton()
    {
        exitButton.gameObject.SetActive(!exitButton.gameObject.activeSelf);
    }

    public static void OnChangeSafePanel()
    {
        SafePanelEvent?.Invoke();
    }

    public void Destroy()
    {
        ArtifactGate.safePanel = false;
        Destroy(gameObject);
    }

    private void SetScale()
    {
        float delta = itemDescText.preferredHeight / ratioForDelta;
        Vector2 deltaVector = new Vector2(0, delta * ratio);

        background.GetComponent<RectTransform>().sizeDelta += deltaVector;
        //scrollView.GetComponent<RectTransform>().sizeDelta += deltaVector;

        downPoint.localPosition = new Vector3(downPoint.localPosition.x, downStatsY);
        downPoint.transform.localPosition -= new Vector3(deltaVector.x, deltaVector.y);
    }


    public void Create(ArtifactGate artifactGate, Canvas artifactCanvas) //создание панельки описания артефакта
    {
        //if (artifactGate.artifact == null) return;
        gameObject.transform.SetParent(artifactCanvas.transform, false);
        itemNameText.text = artifactGate.artifact.itemName;
        itemDescText.text = artifactGate.artifact.itemDesc;    
        itemIcon.sprite = artifactGate.artifact.icon;
        itemTypeText.text = Localizator.Localize(artifactGate.artifact.itemType.ToString()) 
            + " (" + Localizator.Localize(artifactGate.artifact.itemSlot.ToString()) + ")"; // -> ItemType (ItemSlot)
        SetScale();
    }



}
