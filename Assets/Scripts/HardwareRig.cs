using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class HardwareRig : MonoBehaviour, INetworkRunnerCallbacks
{

    #region RigComponents
    [Header("Rig Components")]
    public Transform _characterTransform;

    public Transform _headTransform;

    public Transform _bodyTransform;

    public Transform _leftHandTransform;

    public Transform _rightHandTransform;

    #endregion
        

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region RunnerCallbacks
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        XRRigInputData inputData = new XRRigInputData();

        inputData.HeadsetPosition = _headTransform.position;
        inputData.HeadsetRotation = _headTransform.rotation;

        inputData.BodyPosition = _bodyTransform.position;
        inputData.BodyRotation = _bodyTransform.rotation;

        inputData.CharacterPosition = _characterTransform.position;
        inputData.CharacterRotation = _characterTransform.rotation;

        inputData.LeftHandPosition = _leftHandTransform.position;
        inputData.LeftHandRotation = _leftHandTransform.rotation;

        inputData.RightHandPosition = _rightHandTransform.position;
        inputData.RightHandRotation = _rightHandTransform.rotation;

        input.Set(inputData);
    }

    #endregion

    #region UnusedRunnerCallbacks 
    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }


    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
       
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }
    #endregion

}
public struct XRRigInputData : INetworkInput
{
    public Vector3 MainPlayerPosition;
    public Quaternion MainPlayerRotation;

    //Head
    public Vector3 HeadsetPosition;
    public Quaternion HeadsetRotation;

    public Vector3 BodyPosition;
    public Quaternion BodyRotation;

    //Body
    public Vector3 CharacterPosition;
    public Quaternion CharacterRotation;


    //Hands
    public Vector3 LeftHandPosition;
    public Quaternion LeftHandRotation;

    public Vector3 RightHandPosition;
    public Quaternion RightHandRotation;
}