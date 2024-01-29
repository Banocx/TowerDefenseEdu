<<<<<<< HEAD
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e

public class PlayerSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField]
    private NetworkPrefabRef _prayerPrefab;
<<<<<<< HEAD

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }



    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (player == runner.LocalPlayer)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(1, 5), 0.5f, UnityEngine.Random.Range(1, 5));

            runner.Spawn(_prayerPrefab, spawnPosition, Quaternion.identity, player);
        }
    }


    #region UnUsedCallBacks
    // Update is called once per frame
    void Update()
    {

    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        
=======
    public void OnConnectedToServer(NetworkRunner runner)
    {
       
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
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

<<<<<<< HEAD
    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
=======
    public void OnDisconnectedFromServer(NetworkRunner runner)
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
<<<<<<< HEAD
        
=======
       
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
<<<<<<< HEAD
        
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    

=======
       
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (player == runner.LocalPlayer) 
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(1, 5), 0.5f, UnityEngine.Random.Range(1, 5));

            runner.Spawn(_prayerPrefab, spawnPosition, Quaternion.identity, player);
        }
    }

>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

<<<<<<< HEAD
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        
=======
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
       
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
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

<<<<<<< HEAD
    #endregion
=======
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> a091d6b10fed516af13e7d9bdd51080c8b79535e
}
