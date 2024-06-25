using Photon.Pun;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviourPunCallbacks
{
    private Controller controller;
    public Slider forceUI;

    private Vector2 movementDirection;
    private GameObject gunbarrel; //���� //Shooting Arrow
    private GameObject bullet; //��ź
    private float angle; //����
    private float gunbarrelSpeed = 50;//������ �ӵ�
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
        photonView.RPC("RPC_Fire", RpcTarget.All);
    }

    [PunRPC]
    private void RPC_Fire()
    {
        isPressed = false;
        GameObject go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "bullet"), gunbarrel.transform.position, gunbarrel.transform.rotation);
        go.GetComponent<Bullet>().Set(gunbarrel.transform, force);
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
