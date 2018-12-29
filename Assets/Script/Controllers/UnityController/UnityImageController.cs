using UnityEngine;
using UnityEngine.UI;

public class UnityImageController : UnityBaseComponentController, IImageController
{
    private Image _image;

    public override void InitializeComponent(GameContext context, GameEntity entity)
    {
        _image = gameObject.GetComponent<Image>();
        _context = context;
        _entity = entity;
        
    }

    public string SourceImage
    {
        get { return _image.sprite.name; }
        set { _image.sprite = Resources.Load<Sprite>(value); }
    }
    public int ImageType
    {
        get { return (int)_image.type;}
        set
        {
            if (value >= 0 && value <= 3)
            {
                _image.type = (Image.Type)value;
            }
            else
            {
                _image.type = Image.Type.Simple;
            }
        }
    }
    public int FillMethod
    {
        get { return (int) _image.fillMethod; }
        set {
            if (value >= 0 && value <= 3)
            {
                _image.fillMethod = (Image.FillMethod) value;
            }
            else
            {
                _image.fillMethod = Image.FillMethod.Horizontal;
            }
        }
    }
    public int FillOrigin
    {
        get { return _image.fillOrigin; }
        set { _image.fillOrigin = value; }
    }
    public float FillAmount
    {
        get { return _image.fillAmount; }
        set { _image.fillAmount = value; }
    }
}
