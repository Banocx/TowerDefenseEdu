using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkRig : NetworkBehaviour
{
<<<<<<< HEAD
=======

>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    public bool IsLocalNetworkRig => Object.HasStateAuthority;

    [Header("RigVisuals")]
    [SerializeField]
    private GameObject _headVisuals;


    #region RigComponents
    [Header("RigComponents")]
    [SerializeField]
    private NetworkTransform _characterTransform;

    [SerializeField]
    private NetworkTransform _headTransform;

    [SerializeField]
    private NetworkTransform _bodyTransform;

    [SerializeField]
    private NetworkTransform _leftHandTransform;

    [SerializeField]
    private NetworkTransform _rightHandTransform;
    #endregion


    HardwareRig _hardwareRig;
    public override void Spawned()
    {
        base.Spawned();

        if (IsLocalNetworkRig)
        {
            _hardwareRig = FindObjectOfType<HardwareRig>();
<<<<<<< HEAD
            if (_hardwareRig == null)
=======
            if(_hardwareRig== null)
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
            {
                Debug.LogError("Missing Hardware Rig in the Scene");
            }

            _headVisuals.SetActive(false);
        }

        else
        {
            Debug.Log("This is a client object");
        }
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (GetInput<XRRigInputData>(out var inputData))
        {
            _characterTransform.transform.SetPositionAndRotation(inputData.CharacterPosition, inputData.CharacterRotation);

            _headTransform.transform.SetPositionAndRotation(inputData.HeadsetPosition, inputData.HeadsetRotation);

            _bodyTransform.transform.SetPositionAndRotation(inputData.BodyPosition, inputData.BodyRotation);

            _leftHandTransform.transform.SetPositionAndRotation(inputData.LeftHandPosition, inputData.LeftHandRotation);

            _rightHandTransform.transform.SetPositionAndRotation(inputData.RightHandPosition, inputData.RightHandRotation);
        }
    }

<<<<<<< HEAD
    //public override void Render()
    //{
    //    base.Render();

    //    if (IsLocalNetworkRig)
    //    {
    //        _headTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._headTransform.position, _hardwareRig._headTransform.rotation);

    //        _characterTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._characterTransform.position, _hardwareRig._characterTransform.rotation);

    //        _bodyTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._bodyTransform.position, _hardwareRig._bodyTransform.rotation);

    //        _leftHandTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._leftHandTransform.position, _hardwareRig._leftHandTransform.rotation);

    //        _rightHandTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._rightHandTransform.position, _hardwareRig._rightHandTransform.rotation);
    //    }

    //}
=======
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    public override void Render()
    {
        base.Render();

        if (IsLocalNetworkRig)
        {
<<<<<<< HEAD
            _headTransform.transform.SetPositionAndRotation(_hardwareRig._headTransform.position, _hardwareRig._headTransform.rotation);

            _characterTransform.transform.SetPositionAndRotation(_hardwareRig._characterTransform.position, _hardwareRig._characterTransform.rotation);

            _bodyTransform.transform.SetPositionAndRotation(_hardwareRig._bodyTransform.position, _hardwareRig._bodyTransform.rotation);

            _leftHandTransform.transform.SetPositionAndRotation(_hardwareRig._leftHandTransform.position, _hardwareRig._leftHandTransform.rotation);

            _rightHandTransform.transform.SetPositionAndRotation(_hardwareRig._rightHandTransform.position, _hardwareRig._rightHandTransform.rotation);
        }
=======
            _headTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._headTransform.position, _hardwareRig._headTransform.rotation);

            _characterTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._characterTransform.position, _hardwareRig._characterTransform.rotation);

            _bodyTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._bodyTransform.position, _hardwareRig._bodyTransform.rotation);

            _leftHandTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._leftHandTransform.position, _hardwareRig._leftHandTransform.rotation);

            _rightHandTransform.InterpolationTarget.SetPositionAndRotation(_hardwareRig._rightHandTransform.position, _hardwareRig._rightHandTransform.rotation);
        }

>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }
}
