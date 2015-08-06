namespace WestWorld2 {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntityManager {
        private static readonly Lazy<EntityManager> Lazy = new Lazy<EntityManager>(()=>new EntityManager());
        private EntityManager() { }
        public static EntityManager Instance { get { return Lazy.Value; } }

        private readonly Dictionary<int, BaseGameEntity> _entities = new Dictionary<int, BaseGameEntity>();

        public void RegisterEntity(BaseGameEntity entity) { _entities.Add(entity.Id, entity);}
        public BaseGameEntity this[int id] { get { return _entities.ContainsKey(id) ?_entities[id] : null; } }
        public BaseGameEntity this[string name] { get { return _entities.Values.FirstOrDefault(e => e.Name == name); } }
        public void RemoveEntity(BaseGameEntity entity) { _entities.Remove(entity.Id); }
    }
}