using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* 
        Vector3 é um tipo de vetor para possicionamento
        [SerializeField] serve para a variável aparecer no hub do Unity
    */
    [SerializeField] Vector3 axis;
    [SerializeField] float gravity = 9.0f;
    [SerializeField] float force = 5.0f;
    [SerializeField] bool isUsedRigidbody2D = false;
    [SerializeField] Sprite[] sprites;
    [SerializeField] int spriteIndex;
    [SerializeField] float timeChangeSprite = 0.15f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Olá Mundo!");
        Debug.Log("Integrando VSCode com o Unity");
        Debug.Log(":D");

        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer =  GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(this.animationSprites), timeChangeSprite, timeChangeSprite);

        if (isUsedRigidbody2D) {
            rb =  GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUsedRigidbody2D) {
            this.actionGravity();
        }
        this.verifyButtonPress();
    }

    private void actionGravity() {
        axis.y -= gravity * Time.deltaTime;
        transform.position += axis * Time.deltaTime;
    }

    private void verifyButtonPress() {
        // Tecla de espaço ou botão esquerdo do mouse
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (isUsedRigidbody2D) {
                rb.velocity = new Vector2(0, force);
            } else {
                axis = Vector2.up * force;
            }
        }
    }

    private void animationSprites() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacies")) 
        {
            gameManager.GameOver();
        } else if (collision.CompareTag("Scoring")) {
            gameManager.Scoring();
        }
    }
}
