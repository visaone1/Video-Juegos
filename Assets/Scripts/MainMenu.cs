using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("1-1");
    }

    public void SalirJuego()
    {
        // Este mensaje aparecerá en la consola de Unity para confirmar que funciona
        Debug.Log("Saliendo del juego..."); 
        
        // Esta es la línea que cerrará el juego cuando lo exportes
        Application.Quit(); 
    }
}