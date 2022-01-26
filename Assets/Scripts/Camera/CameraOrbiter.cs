using UnityEngine;

public class CameraOrbiter : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 10f;

    public float MouseSens = 4f;
    public float ScrollSens = 2f;
    public float OrbitDamp = 10f;
    public float ScrollDamp = 6f;

    public bool CameraDisabler = false;


    // Start is called before the first frame update
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CameraDisabler = !CameraDisabler;

        if(!CameraDisabler)
        {
            // Rotate based on x,y of camera pointer
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSens;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSens;

                // Clamp the y Rotation to the horizon and not flipping over at the top...
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, 2f, 90f);
            }

            // Scrolling Input form our mouse scroll wheel to zoom in and out
            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSens;

                // Dynamic Scrolling
                ScrollAmount *= (this._CameraDistance / 0.3f);

                this._CameraDistance += ScrollAmount * -1 ;
              
                // Limit range of zoom 
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, -100f, -1.5f);
            }
        }

        // Actual Camera Rig
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDamp);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * 1f, Time.deltaTime * ScrollDamp));
        }
    }
}
