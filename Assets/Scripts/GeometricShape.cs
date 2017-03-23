using UnityEngine;
using System.Collections;

struct UnwrapSide
{
    bool up;
    bool down;
    bool right;
    bool left;
}

public class GeometricShape : MonoBehaviour {

    [SerializeField]
    private float width; //Y Axis
    [SerializeField]
    private float length; //X Axis
    [SerializeField]
    private float depth; //Z Axis

    private Direction3D topFace;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(4.5f, 9 + (length / 2), -4.5f);
        topFace = Direction3D.UP;
	}
	
	// Update is called once per frame
	void Update () {
	    switch (GameManager.Instance.state)
        {
            case GameState.STATE_IDLE:

                break;
            case GameState.STATE_WAIT_FALL:
                if (InputManager.Instance.directionUses)
                {
                    move();
                }
                else if (InputManager.Instance.A)
                {
                    Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
                    rigidBody.constraints = (RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ);
                    GameManager.Instance.state = GameState.STATE_FALL;
                }
                BoardManager.Instance.flash(Mathf.RoundToInt(transform.position.x + 4.5f), Mathf.RoundToInt(transform.position.z + 4.5f), 0.9f);
                break;
            case GameState.STATE_FALL:

                break;
            case GameState.STATE_WAIT_UNWRAP:
                if (InputManager.Instance.directionUses)
                {
                    roll();
                }
                break;
            default:
                Debug.Log("unknow state used in GeometricShape");
                break;
        }
	}

    private void move()
    {
        BoardManager.Instance.resetFlash(Mathf.RoundToInt(transform.position.x + 4.5f), Mathf.RoundToInt(transform.position.z + 4.5f));
        if (InputManager.Instance.up)
        {
            if(transform.position.z > -4.5f)
            {
                transform.position += new Vector3(0, 0, -1);
            }
        }
        else if (InputManager.Instance.down)
        {
            if(transform.position.z < 4.5f)
            {
                transform.position += new Vector3(0, 0, 1);
            }
        }
        else if (InputManager.Instance.right)
        {
            if(transform.position.x > -4.5f)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (InputManager.Instance.left)
        {
            if(transform.position.x < 4.5f)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }

    private void roll()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        switch (GameManager.Instance.state)
        {
            case GameState.STATE_FALL:
                Destroy(GetComponent<Rigidbody>());
                GameManager.Instance.state = GameState.STATE_WAIT_UNWRAP;
                break;
            default:
                break;
        }
    }
}
