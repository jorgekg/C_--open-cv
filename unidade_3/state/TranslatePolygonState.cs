namespace gcgcg
{
  class TranslatePolygonState : IState
  {
    private double lastX;
    private double lastY;

    /// <summary>
    /// Contrutor sava o ultimo estado da bbox.
    /// </summary>
    /// <param name="mundo"></param>
    public TranslatePolygonState(Mundo mundo)
    {
      var bbox = mundo.polygonSelected.GetBBox();
      this.lastX = bbox.centerX;
      this.lastY = bbox.centerY;
    }

    /// <summary>
    /// Verifica se o comando é para transladar o poligono
    /// </summary>
    /// <param name="command"></param>
    /// <param name="mundo"></param>
    /// <returns></returns>
    public IState Perform(Command command, Mundo mundo)
    {
      if (command.Equals(Command.MOUSE_MOVE)) {
        if (mundo.polygonSelected != null) {
          var translation = this.GetTranslation();
          mundo.polygonSelected.Translation(translation.Item1, translation.Item2);
        } else {
          return new MainState();
        }
      } else if (command.Equals(Command.MOVE)) {
        return new MainState();
      } else if (command.Equals(Command.ESCAPE)) {
        return new MainState().Perform(command, mundo);
      }
      return this;
    }

    /// <summary>
    /// com base no mouse retorna a nova translação do poligono
    /// </summary>
    /// <returns></returns>
    private (double, double) GetTranslation()
    {
      var translX = Mouse.X - this.lastX;
      var translY = Mouse.Y - this.lastY;
      this.lastX = Mouse.X;
      this.lastY = Mouse.Y;
      return (translX, translY);
    }
  }
}