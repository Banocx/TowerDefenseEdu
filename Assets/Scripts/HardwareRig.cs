using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

<<<<<<< HEAD

=======
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
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
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
   
=======
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
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
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }


    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
<<<<<<< HEAD

=======
       
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
<<<<<<< HEAD

    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
=======
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
        
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
<<<<<<< HEAD
}
=======
}
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
