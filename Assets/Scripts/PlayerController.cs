using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    public float xRange = 3.0f;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private GameObject[] lives;
    private int liveIndex;
    [SerializeField]
    private PauseMenu endMenu;
    private Vector3 targetPos;
    void Awake()
    {
        targetPos = transform.position;
        SwipeDetection.SwipeEvent += OnSwipe;
        liveIndex = lives.Length;
    }
    
    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    public void OnSwipe(Vector2 direction)
    {
        if (targetPos.x < xRange && direction == Vector2.right)
        {
            Debug.Log("Yep");
            targetPos = new Vector3(targetPos.x + xRange, transform.position.y, transform.position.z);
        }
        if(targetPos.x > -xRange && direction == Vector2.left)
        {
            targetPos = new Vector3(targetPos.x - xRange, transform.position.y, transform.position.z);
        }
        if (direction == Vector2.up)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (targetPos.x > -xRange && Input.GetKeyDown(KeyCode.A))
        {
            targetPos = new Vector3(targetPos.x - xRange, transform.position.y, transform.position.z);
        }
        if (targetPos.x < xRange && Input.GetKeyDown(KeyCode.D))
        {
            targetPos = new Vector3(targetPos.x + xRange, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void minusLive()
    {
        if (liveIndex != 0)
        {
            liveIndex -= 1;
            lives[liveIndex].SetActive(false);
            if (liveIndex == 0) endMenu.EndGame();
        }
    }

    private void OnMouseDown()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
