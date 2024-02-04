using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _sessionCodeInput;

    [SerializeField]
    string _sessionCode;

    [SerializeField]
    private bool _useFieldSessionCode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateSession()
    {
        NetworkManager.Instance.StartSharedSession();
    }
    public void JoinSession()
    {
        if (_useFieldSessionCode)
        {
            _sessionCode = _sessionCodeInput.text;
        }

        NetworkManager.Instance.StartSharedSession(_sessionCode.ToUpper());
    }
}

