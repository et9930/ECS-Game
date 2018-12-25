using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Controllers.UnityController
{
    abstract class UnityBaseComponentController : MonoBehaviour, IBaseComponentController
    {
        protected GameContext _context;
        protected GameEntity _entity;

        public abstract void InitializeComponent(GameContext context, GameEntity entity);

        public string Name
        {
            get { return gameObject.name; }
            set { gameObject.name = value; }
        }

        public bool Active
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }
    }
}
