using UnityEngine;
using System.Collections;

enum Direction2D
{
    UP,
    DOWN,
    RIGHT,
    LEFT
}

enum Direction3D
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    FRONT,
    BACK
}

public class InputManager : MonoBehaviour {

    public bool up;
    public bool down;
    public bool right;
    public bool left;
    public bool directionUses;
    public bool start;
    public bool select;
    public bool A;
    public bool B;

    [SerializeField]
    private float touchCoolDown;

    private float verticalLock;
    private float horizontalLock;

    public static InputManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Instance of InputManager");
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        verticalLock = horizontalLock = 0;
	}
	
	// Update is called once per frame
	void Update () {
        up = false;
        down = false;
        if(verticalLock >= 0)
        {
            verticalLock -= Time.deltaTime;
        }
        if(horizontalLock >= 0)
        {
            horizontalLock -= Time.deltaTime;
        }

        if(up = (Input.GetAxis("Vertical") > 0.1f) && (verticalLock < 0))
        {
            verticalLock = touchCoolDown;
        }
        else if (down = (Input.GetAxis("Vertical") < -0.1f) && (verticalLock < 0))
        {
            verticalLock = touchCoolDown;
        }

        if(right = (Input.GetAxis("Horizontal") > 0.1f) && (horizontalLock < 0))
        {
            horizontalLock = touchCoolDown;
        }
        else if (left = (Input.GetAxis("Horizontal") < -0.1f) && (horizontalLock < 0))
        {
            horizontalLock = touchCoolDown;
        }

        start = Input.GetKey(KeyCode.Space);
        select = Input.GetKey(KeyCode.Escape);
        A = Input.GetKey(KeyCode.A);

        if(up || down || left || right)
        {
            directionUses = true;
        } else
        {
            directionUses = false;
        }
	}
}
