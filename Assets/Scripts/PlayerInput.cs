using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField]
    private InputActionReference _moveInput;

<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

=======
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    private void OnEnable()
    {
        _moveInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action?.Disable();
    }
<<<<<<< HEAD


=======
    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        //throw new NotImplementedException();
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
       // throw new NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        //throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
       // throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
       // throw new NotImplementedException();
    }

    #region RunnerCallbacks
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Vector2 direction = _moveInput.action.ReadValue<Vector2>();
        Vector3 dir = new Vector3(direction.x, 0, direction.y);
<<<<<<< HEAD

=======
        
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
        PlayerInputData inputData = new PlayerInputData();

        inputData.Direction = dir;


        input.Set(inputData);
    }
<<<<<<< HEAD
    #region UnUsedCallbacks

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

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
         
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
         
    }

   

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
         
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
         
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
         
=======

    #endregion
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
<<<<<<< HEAD
         
=======
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
<<<<<<< HEAD
         
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
         
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
         
=======
        //throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
<<<<<<< HEAD
         
=======
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
<<<<<<< HEAD
         
=======
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
<<<<<<< HEAD
         
=======
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
<<<<<<< HEAD
         
=======
        //throw new NotImplementedException();
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
<<<<<<< HEAD
         
    }
#endregion
}
public struct PlayerInputData : INetworkInput
{
    public Vector3 Direction;
}
=======
        //throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct PlayerInputData: INetworkInput
{
    public Vector3 Direction;
}
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
