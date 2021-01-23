using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnObject;
    void Start()
    {
        SpawnObject = Resources.Load<GameObject>("RocketTurret");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(transform.position, ray.direction.normalized * 30, Color.red, 50);
            if (Physics.Raycast(transform.position, ray.direction.normalized * 30, out hit,500,1,QueryTriggerInteraction.Ignore))
            {
                if (hit.transform.tag == "Platform" && SpawnObject.GetComponent<Turret>().Price <= GameProgress.Credits)
                {
                    GameProgress.Credits -= SpawnObject.GetComponent<Turret>().Price;
                    Instantiate(SpawnObject, new Vector3(hit.transform.position.x, 0.5f, hit.transform.position.z), SpawnObject.transform.rotation, null);
                    UI.UpdateProgressState();
                    SoundEffectManager.PlaySound("Spawn1", 1f);
                }else if (hit.transform.tag == "Platform" && SpawnObject.GetComponent<Turret>().Price > GameProgress.Credits)
                {
                    UI.ShowMessage("More credits required!");
                    StartCoroutine(UI.StopShowMessage());
                }             
            }
        }
    }

    public void SetSpawnObject(GameObject SpawnObject)
    {
        this.SpawnObject = SpawnObject;
    }
}
