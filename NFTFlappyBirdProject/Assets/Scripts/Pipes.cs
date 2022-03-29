using UnityEngine;

public class Pipes : MonoBehaviour {
    //change for difficulty
    public float speed = 5f;
    private float leftEdge;

    //set leftEdge
    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }

    //move pipes and destroy on leftEdge
    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
}
