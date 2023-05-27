using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WayPoint : GameUnit
{
    private Vector2 targetDirection;

    private Characters character;

    [SerializeField] private TMP_Text levelText;

    public TMP_Text characterName;

    public Image imgPoint;

    public Vector3 offset;

    public Image arrow;

    public GameObject arrowRotate;


    private void LateUpdate()
    {
        if (CameraManager.Ins.CheckActiveMainCamera())
        {
            UpdatePosition();

            if (IsGameObjectInViewport(character.gameObject))
            {
                arrowRotate.SetActive(false);

                characterName.gameObject.SetActive(true);
            }
            else
            {
                arrowRotate.SetActive(true);

                characterName.gameObject.SetActive(false);
            }
        }

        if (character.transform != null) UpdateLevelText(character.level);

        UpdateArrow();
    }
    
    private void UpdatePosition()
    {
        float minX = imgPoint.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = imgPoint.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector3 pos = Camera.main.WorldToScreenPoint(character.transform.position + offset);

        if (pos.z < 0)
        {
            pos.y = Screen.height - pos.y;
            pos.x = Screen.width - pos.x;
        }


        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        imgPoint.transform.position = pos;
    }

    private void UpdateArrow()
    {
        Vector2 pos = new Vector2(imgPoint.transform.position.x, imgPoint.transform.position.y);

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

    private bool IsGameObjectInViewport(GameObject gameObject)
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);

        // Kiểm tra xem vị trí của gameobject có nằm trong phạm vi viewport [0, 1] hay không
        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
            viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
            viewportPosition.z > 0)
        {
            return true; // GameObject nằm trong màn hình
        }

        return false; // GameObject không nằm trong màn hình
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
        this.character = character;

        this.characterName.text = character.characterName;

        this.SetColorWayPoint();
    }

    private void SetColorWayPoint()
    {
        this.characterName.color = this.character.materialCharacter.material.color;

        this.imgPoint.color = this.character.materialCharacter.material.color;

        this.arrow.color = this.character.materialCharacter.material.color;
    }
    

    private void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();  
    }
}

