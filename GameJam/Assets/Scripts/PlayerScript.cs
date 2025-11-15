using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float score = 0f;
    public float gameTime = 25f;
    public float gameTimer;
    public bool playedReload = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI prizeText;
    public GameObject dogImage;
    public GameObject catImage;
    public GameObject keyring;
    public GameObject WinScreen;
    public AudioSource audioSource;
    public AudioSource musicSource;
    public AudioClip music;
    public AudioClip shootSound;
    public AudioClip winSound;
    public AudioClip reloadSound;
    


    // Start is called before the first frame update
    void Start()
    {
        bullets = 6f;
        reloadTimer = reloadInterval;
        gameTimer = gameTime;
        scoreText.text = "Score: " + score;
        
        WinScreen.SetActive(false);

        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        //timer text
        bulletText.text = "Bullets: " + bullets.ToString();
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Time: " + Mathf.CeilToInt(gameTimer);

        gameTimer -= Time.deltaTime;

        
        //shooting
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null;
            bullets -= 1;

            audioSource.PlayOneShot(shootSound);

            if (clickObject.CompareTag("Target"))
            {
                Debug.Log("Target hit!");
                //TODO: add the points/flip the target back down
                clickObject.gameObject.SetActive(false);
                score += 1;
            }
            if (clickObject.CompareTag("Wall"))
            {
                Debug.Log("You missed!");
            }
            
        }

        if (!canShoot && !playedReload)
        {
            audioSource.PlayOneShot(reloadSound);
            playedReload = true;
        }

        //reloads
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
                playedReload = false;
            }
        }

        if (gameTimer <= 0)
        {
            //gameover code
            canShoot = false;
            Debug.Log("Game Over");
            WinScreen.SetActive(true);
            timerText.text = "Time's up!";

            if (score >= 35)
            {
                dogImage.SetActive(true);
                prizeText.text = "Congratulations! You won a cuddly puppy!";
            }
            else if (score >= 30)
            {
                catImage.SetActive(true);
                prizeText.text = "Congratulations! You won a cute cuddly kitten!";
            }
            else if (score >= 15)
            {
                keyring.SetActive(true);
                prizeText.text = "Congratulations! You won a keychain!";
            }
            else
            {
                prizeText.text = "Sorry, you didn't score enough points to win anything.";
            }
            
        }
    }
    
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

}
