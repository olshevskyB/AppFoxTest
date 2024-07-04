using UnityEngine;

namespace AppFoxTest
{
    public class MainInstaller : ProjectInstaller
    {
        [SerializeField] private SceneService _sceneService;
        [SerializeField] private ScenesConfig _scenesConfig;
        [SerializeField] private ScreensConfig _screensConfig;

        public override void Init()
        {
            //Контейнер взаимодействуют с помощью интерфейсов IInjectable и IInitializable, оба интерфейса - не обязательны
            _diContainer.AddNewObjectAndInit(new GlobalEventBus());
            _diContainer.AddNewObjectAndInit(new SceneEventBus());
            _diContainer.AddNewObjectAndInit(_scenesConfig);
            _diContainer.AddNewObjectAndInit(_screensConfig);

            //Сюда должны добавляться все новые модели, затем при инициализации View мы запрашиваем отсюда нужную модель, и вызываем у модели метод AddView,
            //который сам создаст Presenter и укажет связи, между View, Model и Presenter. Модель будет сама вызывать методы презентора для обновления данных при необходимости
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<ModelLocator>());
            //Unloader используются как аргумент в loader - каждая фабрика должна иметь собственную копию unloader.
            _diContainer.AddNewObjectAndInit(new Unloader());
            //Должен быть во всех фабриках, он также инжектит все объекты при загрузке.
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<PrefabLoader>());

            _diContainer.AddNewObjectAndInit(new UIFactory());
            //При инициализации сервис запрашивает у UIFactory создать стартовый загрузочный экран 
            _diContainer.AddNewObjectAndInit(CreateAsGameObject<UIService>());

            ISceneLoader sceneLoader = CreateAsGameObject<SceneLoader>();
            _diContainer.AddNewObjectAndInit(sceneLoader);
            //Инициализация сервиса запрашивает загрузку основной сцены
            _diContainer.AddNewObjectAndInit(_sceneService);
        }
    }
}
