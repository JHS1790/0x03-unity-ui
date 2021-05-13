using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    ///Controller
    private CharacterController controller;
    ///Velocity
    private Vector3 playerVelocity;
    ///<summary>Player Speed</velocity>
    public float playerSpeed = 10.0f;
    ///Score
    private int score = 0;
    ///<summary>Player Health</summary>
    public int health = 5;
    ///<summary>Score Text</summary>
    public Text scoreText;
    ///<summary>Health Text</summary>
    public Text healthText;
    ///<summary>win/lose box</summary>
    public Image winloseBox;
    ///<summary>win/lose box</summary>
    public GameObject winloseBG;
    ///<summary>win/lose Text</summary>
    public Text winloseText;
    ///load catch
    private bool loadcatch = false;
    ///Start
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    ///Update
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        if (this.health <= 0)
        {
            winloseText.text = $"Game Over!";
            winloseText.color = Color.black;
            winloseBox.color = Color.green;
            winloseBG.SetActive(true);
            if (loadcatch == false)
                StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    ///Triggered
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trap")
        {
            this.health -= 1;
            ///Debug.Log($"Health: {this.health}");
            SetHealthText();
        }
        if(other.gameObject.tag == "Pickup")
        {
            this.score += 1;
            ///Debug.Log($"Score: {this.score}");
            SetScoreText();
        }
        if(other.gameObject.tag == "Goal")
        {
            ///Debug.Log($"You win!");
            winloseText.text = $"You Win!";
            winloseText.color = new Color(0, 00, 0, 255);
            winloseBox.color = new Color(0, 255, 0, 255);
            winloseBG.SetActive(true);
            if (loadcatch == false)
                StartCoroutine(LoadScene(3));
        }
    }

    ///Got 'em
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    IEnumerator LoadScene(float seconds)
    {
            this.loadcatch = true;
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
