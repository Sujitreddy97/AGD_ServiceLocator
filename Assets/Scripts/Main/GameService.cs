using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.UI;
using ServiceLocator.Events;

public class GameService: GenericMonoSingleton<GameService>
{
    public PlayerService PlayerService { get; private set; }
    public SoundService SoundService { get; private set; }
    public MapService MapService { get; private set; }
    public WaveService WaveService { get; private set; }
    public EventService EventService { get; private set; }


    [SerializeField]private UIService uIService;
    public UIService UIService => uIService;


    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        EventService = new EventService();
        UIService.SubscribeToEvents();
        PlayerService = new PlayerService(playerScriptableObject);
        SoundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        MapService = new MapService(mapScriptableObject);
        WaveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        PlayerService.Update();
    }
}
