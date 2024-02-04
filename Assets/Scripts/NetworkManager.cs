using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Fusion.Sockets;
using System;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    public static NetworkManager Instance { get; private set; }
    public NetworkRunner SessionRunner { get; private set; }

    [SerializeField]
    private GameObject _runnerPrefab;

    
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        
    }

    public async Task LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }
    }

    public void CreateRunner()
    {
        if (_runnerPrefab != null)
        {
            SessionRunner = Instantiate(_runnerPrefab, transform).GetComponent<NetworkRunner>();
        }
        else
        {
            Debug.LogError("_runnerPrefab es null en networkManager");
        }
        SessionRunner.AddCallbacks(this);
    }

    #region Instanciar elementos

   //Función asincrona de spawn de objetos 
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Lógica de instanciación del objeto aquí
        GameObject instantiatedObject = Instantiate(prefab, position, rotation);

        // Devolver el objeto instanciado
        return instantiatedObject;
    }

    #endregion
    private async Task Connect(string sessionName)
    {
        var args = new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = sessionName,
            SceneManager = GetComponent<NetworkSceneManagerDefault>(),
        };

        var result = await SessionRunner.StartGame(args);

        if (result.Ok)
        {
            Debug.Log("StartGame Succesfull");
        }
        else
        {
            Debug.LogError(result.ErrorMessage);
        }
    }

    string GenerateSessionCode(int length = 4)
    {
        char[] chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789".ToCharArray();
        string code = "";
        for (int i = 0; i < length; i++)
        {
            code += chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        Debug.Log("Session Code: " + code);
        return code;
    }

    public async void StartSharedSession(string sessionName = "")
    {
        if (sessionName == "")
        {
            sessionName = GenerateSessionCode();
        }
        else
        {
            if (sessionName.Length != 4)
            {
                Debug.LogError("Wrong Session Name");
                return;
            }
        }

        // Create Runner
        CreateRunner();

        // Load Scene
        await LoadScene();

        // Connect session
        await Connect(sessionName);
    }




    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("A new player joined the session");
         
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("Runner Shutdown");
    }





    #region UnussedCalbacks
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

    public void OnInput(NetworkRunner runner, NetworkInput input)
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

    

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }
    #endregion
}

