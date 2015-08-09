namespace WestWorld2 {
    using System;
    using System.Collections.Generic;

    public class EntityManager {
        private static readonly Lazy<EntityManager> Lazy = new Lazy<EntityManager>(()=>new EntityManager());
        private EntityManager() { }
        public static EntityManager Instance { get { return Lazy.Value; } }

        private readonly Dictionary<int, BaseGameEntity> _entityIdMap = new Dictionary<int, BaseGameEntity>();
        private readonly Dictionary<string, BaseGameEntity> _entityNameMap  = new Dictionary<string, BaseGameEntity>();

        public void RegisterEntity(BaseGameEntity entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity","Cannot register null entity");
            }
            try {
                _entityIdMap.Add(entity.Id, entity);
            } catch (ArgumentException aex) {
                throw new ArgumentException("Cannot register duplicate entity id: " + entity.Id, "entity.Id", aex);
            }
            try {
                _entityNameMap.Add(entity.Name, entity);
            } catch (ArgumentException aex) {
                throw new ArgumentException("Cannot register duplicate entity name: " + entity.Name, "entity.Name", aex);
            }
        }
        public BaseGameEntity this[int id] { get { return _entityIdMap.ContainsKey(id) ?_entityIdMap[id] : null; } }
        public BaseGameEntity this[string name] { get { return _entityNameMap.ContainsKey(name) ? _entityNameMap[name] : null; } }

        public void RemoveEntity(BaseGameEntity entity) {
            _entityIdMap.Remove(entity.Id);
            _entityNameMap.Remove(entity.Name);
        }
    }
}