using UnityEngine;
using UnityEngine.UI;
using Vector4 = System.Numerics.Vector4;

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
        get { return (int)_text.fontStyle; }

        set
        {
            if (value >= 0 && value <= 3)
            {
                _text.fontStyle = (FontStyle) value;
            }
            else
            {
                _text.fontStyle = UnityEngine.FontStyle.Normal;
            }
        }
    }
}

