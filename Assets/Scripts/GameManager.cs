using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Referencias de UI")]
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoPuntaje;

    [Header("Variables de Mario")]
    public int world = 1;
    public int stage = 1;
    public int lives = 3;
    public int coins = 0;
    public int score = 0;
    public float tiempoRestante = 400f;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && tiempoRestante > 0) {
            tiempoRestante -= Time.deltaTime;
            ActualizarUI();
        } else if (tiempoRestante <= 0) {
            ResetLevel();
        }
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        score = 0;
        LoadLevel(1, 1);
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        tiempoRestante = 400f;
        SceneManager.LoadScene($"{world}-{stage}");
    }

    // --- ESTO CORRIGE TUS ERRORES DE RESETLEVEL ---
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;
        if (lives > 0) {
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    public void GameOver()
    {
        NewGame();
    }

    public void AddCoin()
    {
        coins++;
        AddScore(100);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sonidoMoneda);
        if (coins == 100) {
            coins = 0;
            AddLife();
        }
        ActualizarUI();
    }

    public void AddScore(int puntos)
    {
        score += puntos;
        ActualizarUI();
    }

    public void AddLife()
    {
        lives++;
        // --- ESTO CORRIGE EL ERROR DE SONIDO1UP ---
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sonido1Up);
    }

    private void ActualizarUI()
    {
        if (textoMonedas != null) textoMonedas.text = "x" + coins.ToString("D2");
        if (textoTiempo != null) textoTiempo.text = "TIME\n" + Mathf.CeilToInt(tiempoRestante).ToString();
        if (textoPuntaje != null) textoPuntaje.text = "MARIO\n" + score.ToString("D6");
    }
}