using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[EditorTool("Creater")]
public class ToolsCriateObgect : EditorTool
{
    static Texture2D _toolIcon;

    readonly GUIContent _iconContent = new GUIContent
    {
        image = _toolIcon,
        text = "Place Objects Tool",
        tooltip = "Place Objects Tool"
    };

    VisualElement _toolRootElement;
    ObjectField _prefabObjectField;
    FloatField hithSpavn;
    FloatField wahitSpavn;
    bool _receivedClickDownEvent;
    bool _receivedClickUpEvent;

    bool HasPlaceableObject => _prefabObjectField?.value != null;

    public override GUIContent toolbarIcon => _iconContent;

    public override void OnActivated()
    {
        //Create the UI
        _toolRootElement = new VisualElement();
        _toolRootElement.style.width = 200;
        var backgroundColor = EditorGUIUtility.isProSkin
            ? new Color(0.21f, 0.21f, 0.21f, 0.8f)
            : new Color(0.8f, 0.8f, 0.8f, 0.8f);
        _toolRootElement.style.backgroundColor = backgroundColor;
        _toolRootElement.style.marginLeft = 10f;
        _toolRootElement.style.marginBottom = 10f;
        _toolRootElement.style.paddingTop = 5f;
        _toolRootElement.style.paddingRight = 5f;
        _toolRootElement.style.paddingLeft = 5f;
        _toolRootElement.style.paddingBottom = 5f;
        var titleLabel = new Label("Place Objects Tool");
        titleLabel.style.unityTextAlign = TextAnchor.UpperCenter;

        _prefabObjectField = new ObjectField { allowSceneObjects = true, objectType = typeof(GameObject) };

        _toolRootElement.Add(titleLabel);
        _toolRootElement.Add(_prefabObjectField);

        var titleLabelHithSpavn = new Label("Place a");
        titleLabelHithSpavn.style.unityTextAlign = TextAnchor.UpperCenter;

        hithSpavn = new FloatField();
        _toolRootElement.Add(titleLabelHithSpavn);
        _toolRootElement.Add(hithSpavn);

        var titleLabelWahitSpavn = new Label("Place b");
        titleLabelWahitSpavn.style.unityTextAlign = TextAnchor.UpperCenter;

        wahitSpavn = new FloatField();
        _toolRootElement.Add(titleLabelWahitSpavn);
        _toolRootElement.Add(wahitSpavn);

        var sv = SceneView.lastActiveSceneView;
        sv.rootVisualElement.Add(_toolRootElement);
        sv.rootVisualElement.style.flexDirection = FlexDirection.ColumnReverse;

        SceneView.beforeSceneGui += BeforeSceneGUI;
    }

    public override void OnWillBeDeactivated()
    {
        _toolRootElement?.RemoveFromHierarchy();
        SceneView.beforeSceneGui -= BeforeSceneGUI;
    }

    void BeforeSceneGUI(SceneView sceneView)
    {
        if (!ToolManager.IsActiveTool(this))
            return;

        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            ShowMenu();
            Event.current.Use();
        }

        if (!HasPlaceableObject)
        {
            _receivedClickDownEvent = false;
            _receivedClickUpEvent = false;
        }
        else
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                _receivedClickDownEvent = true;
                Event.current.Use();
            }

            if (_receivedClickDownEvent && Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                _receivedClickDownEvent = false;
                _receivedClickUpEvent = true;
                Event.current.Use();
            }
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        //If we're not in the scene view, we're not the active tool, we don't have a placeable object, exit.
        if (!(window is SceneView))
            return;

        if (!ToolManager.IsActiveTool(this))
            return;

        if (!HasPlaceableObject)
            return;

        //Draw a positional Handle.
        var sceil = _prefabObjectField.value;
        float sceilRadius = ((GameObject)sceil).GetComponent<CircleCollider2D>().radius;
        Handles.DrawWireCube(GetCurrentMousePositionInScene(), new Vector3(3*hithSpavn.value* sceilRadius, 3*wahitSpavn.value* sceilRadius, 1));

        //If the user clicked, clone the selected object, place it at the current mouse position.
        if (_receivedClickUpEvent)
        {
            var newObject = _prefabObjectField.value;
            float radius = ((GameObject)newObject).GetComponent<CircleCollider2D>().radius;
            for (int i = 0; i < hithSpavn.value; i++)
            {
                for (int j = 0; j < wahitSpavn.value; j++)
                {
                    GameObject newObjectInstance;
                    if (PrefabUtility.IsPartOfAnyPrefab(newObject))
                    {
                        var prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(newObject);
                        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                        newObjectInstance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                    }
                    else
                    {
                        newObjectInstance = Instantiate((GameObject)newObject);
                    }
                    
                    Vector3 pointSpavn = GetCurrentMousePositionInScene() - new Vector3(3*hithSpavn.value/2*radius, -3*wahitSpavn.value/2*radius,0) + Vector3.down * j * 3 * radius+ Vector3.right * i * 3 * radius;
                    newObjectInstance.transform.position = pointSpavn;
                    Undo.RegisterCreatedObjectUndo(newObjectInstance, "Place new object");
                }
            }
            _receivedClickUpEvent = false;
        }

        //Force the window to repaint.
        window.Repaint();
    }

    Vector3 GetCurrentMousePositionInScene()
    {
        Vector3 mousePosition = Event.current.mousePosition;
        var placeObject = HandleUtility.PlaceObject(mousePosition, out var newPosition, out var normal);
        return placeObject ? newPosition : HandleUtility.GUIPointToWorldRay(mousePosition).GetPoint(10);
    }

    void ShowMenu()
    {
        var picked = HandleUtility.PickGameObject(Event.current.mousePosition, true);
        
        if (!picked) return;
        var menu = new GenericMenu();
        menu.AddItem(new GUIContent($"Pick {picked.name}"), false, () => { _prefabObjectField.value = picked; });
        menu.ShowAsContext();
    }
}
