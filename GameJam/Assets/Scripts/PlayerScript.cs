using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 mousePos;
    RaycastHit2D raycastHit2D;
    Transform clickObject;
    public bool isReloading;
    public bool canShoot = true;
    public float bullets = 6f;
    public float reloadInterval = 3f;
    public float reloadTimer;
    public TextMeshProUGUI bulletText;

    // Start is called before the first frame update
    void Start()
    {
        bullets = 6f;
        reloadTimer = reloadInterval;
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        //TODO: add artwork and work on theme/borders
        bulletText.text = "Bullets: " + bullets.ToString();
        
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null;
            bullets -= 1;

            if (clickObject.CompareTag("Target"))
            {
                Debug.Log("Target hit!");
                //TODO: add the points/flip the target back down
            }
        }

        if (bullets <= 0)
        {
            canShoot = false;
            isReloading = true;
            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0)
            {
                bullets = 6f;
                canShoot = true;
                isReloading = false;
                reloadTimer = reloadInterval;
            }
        }
    }
}
