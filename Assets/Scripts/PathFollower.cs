using PathCreation;
using UnityEngine;
using UnityEngine.Serialization;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private float speed = 5;
    private float distanceTravelled;
    [SerializeField] private GameObject greenObject;
    [SerializeField] private KeyCode switchKey;

    private Vector2 greenRange;
    void Update()
    {
        float pathLength = pathCreator.path.length;

        //непосредственно перемещение
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //transform.rotation = new Quaternion(0,0,0,0);

        //позиция зеленой хуйни
        var greenPosition = greenObject.transform.position;
        greenPosition = pathCreator.path.GetPointAtDistance(pathLength / 5);
        greenObject.transform.position = greenPosition;


        greenRange = new Vector2(greenPosition.x - pathLength / 2,
            greenPosition.x + pathLength / 2);
    
        if(Input.GetKeyDown(switchKey))
            isPopal();
       
    }

    void isPopal()
    {
        //проверка на попадание
        if (transform.position.x > greenRange.x && transform.position.x < greenRange.y)
        {
            Debug.Log("U got it");
        }
    }
}