using UnityEngine;

public class Player : MonoBehaviour{
    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 5f;

    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update(){

        //input to make player fly up
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector3.up * strength; 
        }

        //for touch input
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began){
                direction = Vector3.up * strength;
            }
        }

        //apply gravity 
        direction.y += gravity * Time.deltaTime;
        //update position of player
        transform.position += direction * Time.deltaTime;

        
        
    }

    //player collision
    private void OnTriggerEnter2D(Collider2D other){
            if(other.gameObject.tag == "Obstacle"){
                FindObjectOfType<GameManager>().GameOver();
            }
            else if(other.gameObject.tag == "Scoring"){
                FindObjectOfType<GameManager>().IncreaseScore();
            }
        }
}
