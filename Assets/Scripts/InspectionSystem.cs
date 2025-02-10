using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class InspectionSystem : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private float inspectionDistance;

    [SerializeField]
    private float inspectAroundSpeed;

    [SerializeField]
    private float startInspectionDuration = 1.5f;

    [SerializeField]
    private float quitInspectionDuration = 0.3f;

    [SerializeField]
    private Transform lookPoint;

    private Camera cam;

    private PlayerInput input;

    private LookableItem currentLookable;

    private float distanceToLookPoint;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
        distanceToLookPoint = Vector3.Distance(transform.position, lookPoint.position);

    }
    private void OnEnable()
    {
        input.actions["StartInspection"].started += StartInspection;
        input.actions["InspectAround"].performed += UpdateInspection;
        input.actions["QuitInspection"].started += QuitInspection;
    }

    private void StartInspection(InputAction.CallbackContext ctx)
    {
        if(currentLookable != null)
        {
            eventManager.PlayerStartsInspecting(startInspectionDuration, distanceToLookPoint);
            currentLookable.Inspect(lookPoint, startInspectionDuration, SwitchToInspectionMode);
        }
    }

    private void UpdateInspection(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
        if (currentLookable != null)
        {
            currentLookable.InspectAround(ctx.ReadValue<Vector2>() * inspectAroundSpeed);
        }
    }

    private void QuitInspection(InputAction.CallbackContext obj)
    {
        eventManager.PlayerStopsInspecting(quitInspectionDuration);
        input.SwitchCurrentActionMap("Gameplay");
        currentLookable.QuitInspection(quitInspectionDuration);
    }
    void SwitchToInspectionMode()
    {
        input.SwitchCurrentActionMap("Looking");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, inspectionDistance))
        {
            if(hit.transform.TryGetComponent(out LookableItem lookable))
            {
                currentLookable = lookable;
            }
        }
        else
        {
            currentLookable = null;
        }
    }
}
