using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    private Controller controller;
    public Slider forceUI;

    private Vector2 movementDirection;
    private GameObject gunbarrel; //포신 //Shooting Arrow
    private GameObject bullet; //포탄
    private float angle; //각도
    private float gunbarrelSpeed = 50;//포신의 속도
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
        bullet = Managers.Resource.Load<GameObject>("Prefabs/Bullet");

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
            force += Time.deltaTime * 2.5f;
            force = Mathf.Clamp(force, 0, maxForce);
            Slider();
        }
    }

    private void FixedUpdate()
    {
        angle = angle + Time.deltaTime * gunbarrelSpeed * movementDirection.y;
        angle = Mathf.Clamp(angle, 0, 180);
        float rad = angle * Mathf.Deg2Rad;
        gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        gunbarrel.transform.eulerAngles = new Vector3(0, 0, angle);
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
        go.GetComponent<Bullet>().Set(gunbarrel.transform, force);
        go.transform.localPosition = gunbarrel.transform.position;
        go.transform.rotation = gunbarrel.transform.rotation;
        ResetGauge();
        StartCoroutine(ChangeTurnAfterShot());
    }

    private IEnumerator ChangeTurnAfterShot()
    {
        yield return null;
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
