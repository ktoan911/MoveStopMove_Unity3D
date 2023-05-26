using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class WayPoint : GameUnit
{
    private Vector2 targetDirection;

    private Characters character;

    private Transform target;

    [SerializeField] private TMP_Text levelText;

    public Image img;

    public Vector3 offset;

    public GameObject arrow;

    public GameObject arrowRotate;

    public Image image;


    private void Update()
    {
        if (CameraManager.Ins.CheckActiveMainCamera())
        {
            UpdatePosition();
        }

        if (target != null) UpdateLevelText(character.level);

        UpdateArrow();
    }
    
    private void UpdatePosition()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector3 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (pos.z < 0)
        {
            pos.y = Screen.height - pos.y;
            pos.x = Screen.width - pos.x;
        }


        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
    }

    private void UpdateArrow()
    {
        Vector2 pos = new Vector2(img.transform.position.x, img.transform.position.y);

        Vector2 centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);

        targetDirection = pos - centerPoint;

        Vector2 posY = new Vector2(0, 1);

        float angle = Vector2.Angle(posY, targetDirection);

        if (targetDirection.x > posY.x) // Kiểm tra xem vector đầu tiên nằm bên phải vector thứ hai
        {
            angle = 360 - angle; // Trừ giá trị góc khỏi 360 để có giá trị góc âm
        }

        arrow.transform.eulerAngles = Vector3.forward * angle;

        arrowRotate.transform.eulerAngles = Vector3.forward * angle;


    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public override void OnInit()
    {
        
    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new System.NotImplementedException();
    }

    public void OnInit(Characters character)
    {
        target = character.transform;

        this.character = character;
    }

    private void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();  
    }
}

