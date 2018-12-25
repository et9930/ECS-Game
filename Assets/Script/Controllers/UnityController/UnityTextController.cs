using System.Numerics;
using UnityEngine.UI;

namespace Assets.Script.Controllers.UnityController
{
    class UnityTextController : UnityBaseComponentController, ITextController
    {
        private Text _text;
        public override void InitializeComponent(GameContext context, GameEntity entity)
        {
            _text = gameObject.GetComponent<Text>();
            _context = context;
            _entity = entity;
            Text = entity.text.value;
        }

        public string Text
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        public int FontSize
        {
            get { return _text.fontSize; }
            set { _text.fontSize = value; }
        }

        public Vector4 Color
        {
            get { return Utilities.ToSystemNumericsVector4(_text.color); }
            set { _text.color = Utilities.ToUnityEngineColor(value); }
        }

        public int FontStyle
        {
            get
            {
                switch (_text.fontStyle)
                {
                    case UnityEngine.FontStyle.Normal:
                        return 0;
                    case UnityEngine.FontStyle.Bold:
                        return 1;
                    case UnityEngine.FontStyle.Italic:
                        return 2;
                    case UnityEngine.FontStyle.BoldAndItalic:
                        return 3;
                    default:
                        return 0;
                }
            }

            set
            {
                switch (value)
                {
                    case 0:
                        _text.fontStyle = UnityEngine.FontStyle.Normal;
                        break;
                    case 1:
                        _text.fontStyle = UnityEngine.FontStyle.Bold;
                        break;
                    case 2:
                        _text.fontStyle = UnityEngine.FontStyle.Italic;
                        break;
                    case 3:
                        _text.fontStyle = UnityEngine.FontStyle.BoldAndItalic;
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
