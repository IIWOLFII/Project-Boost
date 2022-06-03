using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //parameters

    [SerializeField ]AudioClip finish;
    [SerializeField ]AudioClip death;
    [SerializeField ]ParticleSystem deathpart;
    [SerializeField ]ParticleSystem finishpart;

    // cache
    AudioSource audi;

    
    // state
    bool IsAlive = true;
    bool debugmode = false;


    private void Start() 
    {
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        DEBUG();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (IsAlive)
        {
        switch(other.gameObject.tag)    
        {
            case "Finish":
                Finish();
                break;
            case "Pickup":
                break;
            case "Respawn":
                break;
            default:
                Death();
                break;
        }
        }
    }


    void Finish()
    {   
        
        IsAlive=false;
        finishpart.Play();
        audi.Stop();
        audi.PlayOneShot(finish);
        Invoke("LoadNextScene",3f);
    }

    void LoadNextScene()
    {
        int NextsceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount)
        {NextsceneIndex = 0;}
        SceneManager.LoadScene(NextsceneIndex);
    }

    void Death()
    {   
        
        IsAlive = false;
        deathpart.Play();
        audi.Stop();
        audi.PlayOneShot(death);
        GetComponent<Movement>().enabled = false;
        Invoke("Reboot",3f);
    }

    void Reboot()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

// DEBUG FROM THIS POINT

    void DEBUG()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            debugmode = !debugmode;
            if (debugmode){audi.PlayOneShot(death);}
        }
        if (debugmode)
        {
            if (Input.GetKeyDown(KeyCode.L)){DebugWrapper(DEBUGnextlevel);}
            else if (Input.GetKeyDown(KeyCode.C)){DebugWrapper(DEBUGnoclip);}
        }
    }
    // sound wrapper
    void DebugWrapper(UnityEngine.Events.UnityAction fun)
    {
        audi.PlayOneShot(death);
        fun();
    }

    void DEBUGnextlevel()
    {
        LoadNextScene();
    }

    void DEBUGnoclip()
    {
        GetComponent<BoxCollider>().enabled=!GetComponent<BoxCollider>().enabled;
    }


}
