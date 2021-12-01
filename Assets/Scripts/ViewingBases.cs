using UnityEngine;
using UnityEngine.UI;

public class ViewingBases : MonoBehaviour
{
    [SerializeField] private Vector2 i;
    [SerializeField] private Vector2 j;
    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private Text textArea;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j);
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i);
        Gizmos.color = Color.yellow;
        var point = CalculatePoint(X, i, Y, j);
        GizmosUtils.DrawVectorAtOrigin(point);
        UpdateTextArea(point);
    }
    
    private Vector2 CalculatePoint(float scaler1, Vector2 point1, float scaler2, Vector2 point2)
    {
        return scaler1 * point1 + scaler2 * point2;
    }

    private void UpdateTextArea(Vector2 point)
    {
        textArea.text = $"v = ({point.x}, {point.y})\n" +
                        $"i = ({i.x}, {i.y})\n" +
                        $"j = ({j.x}, {j.y})\n" +
                        $"LD = {AreLinearDependent(i, j)}";
    }

    private bool AreLinearDependent(Vector2 a, Vector2 b)
    {
        var determinant = a.x * b.y - b.x * a.y;
        return determinant == 0;
    }
}
