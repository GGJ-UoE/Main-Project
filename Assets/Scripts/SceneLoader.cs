
using UnityEngine.SceneManagement;

public class SceneLoader 
{
   public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);   
    }
    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Beacuse menu is gonna be at 1 index in build scenes //
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
