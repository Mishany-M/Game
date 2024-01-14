using UnityEngine;
using UnityEngine.UI;

public class CanvasLoad : MonoBehaviour
{
    public Canvas canv;
    public Animator animator;
    public Saves saves;

    private void Awake()
    {
        canv.worldCamera = Camera.main;
        saves = Saves.instance;
    }

    public void DisableLoading()
    {
        canv.gameObject.SetActive(false);
        saves.loading.allowSceneActivation = true;
        saves.loadingScene = false;
        Time.timeScale = 1;
    }

    public void Loading()
    {
        if(saves.loading.isDone)
        {
            animator.SetBool("EndAnimation", true);
            saves.loading.allowSceneActivation = false;
        }
    }

    public void StartLoading()
    {
        animator.SetBool("EndAnimation", false);
        saves.LoadLvl();
        saves.loadingScene = true;
    }
}
