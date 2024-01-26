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

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        _moveInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action?.Disable();
    }


    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Vector2 direction = _moveInput.action.ReadValue<Vector2>();
        Vector3 dir = new Vector3(direction.x, 0, direction.y);

        PlayerInputData inputData = new PlayerInputData();

        inputData.Direction = dir;


        input.Set(inputData);
    }
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
         
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
         
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
         
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
         
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
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
public struct PlayerInputData : INetworkInput
{
    public Vector3 Direction;
}
