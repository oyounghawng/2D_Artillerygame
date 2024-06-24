using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    private Controller controller;
    public Slider forceUI;

    private Vector2 movementDirection;
    private GameObject gunbarrel; //포신 //Shooting Arrow
    public GameObject bullet; //포탄
    public float Angle;//각도
    public float gunbarrelSpeed;//포신의 속도
    private float force;
    private float maxForce = 10f;


    private bool isPressed = false;

    private void Awake()
    {
        controller = GetComponentInParent<Controller>();
        gunbarrel = Util.FindChild(this.gameObject, "Shooting", true);
    }
    void Start()
    {
        controller.OnAimEvent += Aim;
        controller.OnGazeEvent += Gaze;
        controller.OnFireEvent += Fire;
    }

    private void Controller_OnGazeEvent()
    {
        throw new System.NotImplementedException();
    }
    private void Update()
    {
        if (isPressed)
        {
            force += Time.deltaTime;
            force = Mathf.Clamp(force, 0, maxForce);
            Slider();
        }
    }

    private void FixedUpdate()
    {
        Angle = Angle + Time.deltaTime * gunbarrelSpeed * movementDirection.y;
        float rad = Angle * Mathf.Deg2Rad;
        gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        gunbarrel.transform.eulerAngles = new Vector3(0, 0, Angle);
    }

    private void Aim(Vector2 value)
    {
        movementDirection = value;
    }
    private void Gaze()
    {
        isPressed = true;
    }

    private void Fire()
    {
        isPressed = false;
        GameObject go = Instantiate(bullet);
        go.GetComponent<Bullet>().Set(this.transform, force);
        go.transform.localPosition = gunbarrel.transform.position;
        go.transform.rotation = gunbarrel.transform.rotation;
        ResetGauge();
        TurnManager.instance.ChangeTurn();
    }


    public void Slider()
    {
        forceUI.value = force / maxForce;
    }
    public void ResetGauge()
    {
        force = 0;
        forceUI.value = 0;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        ResetGauge();
    }
}
