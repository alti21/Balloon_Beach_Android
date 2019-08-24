using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
using UnityEngine.UI;
//using UnityEngine.Pur
//using UnityEngine.Monetization;
using GoogleMobileAds.Api;






public class App_Initialize : MonoBehaviour
{
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;
    public GameObject adButton;
    public GameObject restartButton;
    private bool hasGameStarted = false;
    private bool hasSeenRewardedAd = false;
    private BannerView bannerView;



#if UNITY_IOS
    public const string gameID = "3064768";
#elif UNITY_ANDROID
   // public const string gameID = "3064769";
    public const string gameID = "ca-app-pub-3597509611968947~8979819867";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif
    public string bannerPlacement = "banner";
    public bool testMode = false;
    public bool show = false;
    void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        // show = false;
        //  Debug.Log("Unity Ads test mode enabled: " + Advertisement.testMode);
        MobileAds.Initialize(gameID);
        this.RequestBanner();

       // Advertisement.Initialize(gameID, false);
       // Debug.Log("Unity Ads initialized: " + Advertisement.isInitialized);
      //  Debug.Log("Unity Ads is supported: " + Advertisement.isSupported);
      //  Debug.Log("Unity Ads is showing: " + Advertisement.isShowing);
      //  StartCoroutine(ShowBannerWhenReady());
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
      //  Debug.Log("Unity Ads is showing: " + Advertisement.isShowing);



    }

    private void RequestBanner()
    {


        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView("ca-app-pub-3597509611968947/8914696098", AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build(); //AddTestDevice("FDA75B5FBEE7F41D8361CAB19B7CE4A2")
        bannerView.LoadAd(request);

    }



    public void PlayButton ()
    {
        if(hasGameStarted == true)
        {
            StartCoroutine(StartGame(1.0f));
        }
        else
        {
            StartCoroutine(StartGame(0.0f));
        }
       
    }

    public void OpenPolicy()
    {
        Application.OpenURL("https://docs.google.com/document/d/1BSo_YnZAE8lW43FqiF_V32XI6Nv6R923MoQPYTCGRLg/edit?usp=sharing");
    }

    public void PauseGame ()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        hasGameStarted = true;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    public void GameOver ()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        hasGameStarted = true;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        if(hasSeenRewardedAd == true)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
            adButton.GetComponent<Animator>().enabled = false;
            restartButton.GetComponent<Animator>().enabled = true;
        }
    }

    public void RestartGame ()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(0);
    }

    public void ShowAd()
    {
        //  hasSeenRewardedAd = true;

        if (show == false)
        {
            StartCoroutine(StartGame(1.5f));
         //   StartCoroutine(ShowBannerWhenReady());

        }

      //  show = true;

       // Debug.Log("Unity Ads is showing: " + Advertisement.isShowing);
        //  if (Advertisement.IsReady("banner"))
        //   {
        //         var options = new ShowOptions { resultCallback = HandleShowResult };
        //        Advertisement.Show("banner", options);
        //  }
       // Debug.Log("Unity Ads is showing: " + Advertisement.isShowing);

    }


 /*   private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                hasSeenRewardedAd = true;
                StartCoroutine(StartGame(1.5f));
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }*/



  /*  IEnumerator ShowBannerWhenReady()
    {
        Advertisement.Banner.Load(bannerPlacement);
        Debug.Log("Unity Ads is loaded!: " + Advertisement.Banner.isLoaded);
        while (!Advertisement.IsReady("banner"))
        {
           //
            yield return new WaitForSeconds(0.8f);
        }
       
        Advertisement.Banner.Show(bannerPlacement);
       
        //  yield return new WaitForSeconds(3.5f);
        // Advertisement.Banner.Hide();

    }*/



    IEnumerator StartGame(float waitTime)
    {
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }

}
