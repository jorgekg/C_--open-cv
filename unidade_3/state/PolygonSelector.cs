using System.Collections.Generic;

namespace gcgcg
{
  public class PolygonSelector
  {

    /// <summary>
    /// Verifica se o poligono foi selecionado, se clicado dentro da bbox e poligono
    /// </summary>
    /// <param name="polygons"></param>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    public static Polygon GetSelected(List<Polygon> polygons, double X, double Y)
    {
      foreach (var polygon in polygons)
      {
        var bBox = polygon.GetBBox();
        if (
          X >= bBox.largerDistanceLeft &&
          X <= bBox.largerDistanceRight &&
          Y >= bBox.largetDistanceBottom &&
          Y <= bBox.largerDistanceTop &&
          WasClickedInside(polygon.GetTransformedPoints(), X, Y)
        )
        {
          return polygon;
        }
        var selectedChild = PolygonSelector.GetSelected(polygon.children, X, Y);
        if (selectedChild != null) {
          return selectedChild;
        }
      }
      return null;
    }

    /// <summary>
    /// Verifica se o clique foi entro do poligono
    /// </summary>
    /// <param name="points"></param>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    private static bool WasClickedInside(List<Ponto4D> points, double X, double Y)
    {
      points.Add(points[0]);
      var intersections = 0;
      for (var i = 0; i < points.Count - 1; i++)
      {
        var pointOrigin = points[i];
        if (pointOrigin.X == X && pointOrigin.Y == Y)
        {
          return true;
        }
        var pointDest = points[i + 1];
        var scanLine = (new Ponto4D() { X = X, Y = Y }, new Ponto4D() { X = 600, Y = Y });
        (double intersectionT, double intersectionX) = Intersection.ResolveIntersection(
          scanLine, 
          (pointOrigin, pointDest)
        );
        if ((intersectionT >= 0 && intersectionT <= 1) && intersectionX > X)
        {
            intersections++;
        }
      }
      return intersections % 2 == 1;
    }
  }
}