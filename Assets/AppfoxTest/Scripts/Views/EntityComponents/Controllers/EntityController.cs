using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppFoxTest
{
    public abstract class EntityController : MonoBehaviour, IInjectable
    {
        protected SceneEventBus _eventBus;

        [SerializeField]
        protected MovableComponent _movable;

        [SerializeField]
        protected AttackComponent _attackComponent;

        [SerializeField]
        protected Transform _spellsRoot;

        protected List<AbstractSpell> _spells;
        protected List<SpellComponent> _availableSpells = new List<SpellComponent>();

        protected IPrefabLoader _prefabLoader;
        protected IUnloader _unloader;
        protected IEntityPresenter _presenter;

        public void Inject(DIContainer container)
        {
            _eventBus = container.GetSingle<SceneEventBus>();
            _prefabLoader = container.GetSingle<IPrefabLoader>();
            _unloader = container.GetTransient<IUnloader>();
            AddListeners();
        }

        public void SetPresenter(IEntityPresenter presenter)
        {
            _presenter = presenter;
        }

        public virtual void SetSpells(List<AbstractSpell> spells)
        {
            _spells = spells;
            if (_availableSpells.Any())
            {
                _unloader.Unload();
                _availableSpells.Clear();
            }

            foreach (AbstractSpell spell in _spells)
            {
                SpellComponent spellComponent = _prefabLoader.Load(spell.SpellPrefab, _unloader, _spellsRoot.transform.position, _spellsRoot.transform.rotation, _spellsRoot);
                spellComponent.SetSpell(spell);
                _availableSpells.Add(spellComponent);
            }
        }

        protected void Attack()
        {
            _attackComponent.Attack();
        }

        protected abstract void AddListeners();

        protected abstract void RemoveListeners();
    }
}
