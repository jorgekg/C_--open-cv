/*
  Autor: Dalton Solano dos Reis
*/

using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace gcgcg
{
  /// <summary>
  /// Classe que define o mundo virtual
  /// Padrão Singleton
  /// </summary>
  /// 

  class Mundo
  {
    public static Mundo instance = null;
    private Quadrilatero objeto = new Quadrilatero(0, 0, 0, 12, 5, 2);
    private Quadrilatero[] objetos = new Quadrilatero[] {
      new Quadrilatero(0, 0, -45, 12, 5, 2),
      new Quadrilatero(0, 0, -40, 12, 5, 2),
      new Quadrilatero(0, 0, -35, 12, 5, 2),
      new Quadrilatero(0, 0, -30, 12, 5, 2),
      new Quadrilatero(0, 0, -25, 12, 5, 2),
      new Quadrilatero(0, 0, -20, 12, 5, 2),
      new Quadrilatero(0, 0, -15, 12, 5, 2),
      new Quadrilatero(0, 0, -10, 12, 5, 2),
      new Quadrilatero(0, 0, -5, 12, 5, 2),
      new Quadrilatero(0, 0, 0, 12, 5, 2),
      new Quadrilatero(0, 0, 5, 12, 5, 2),
      new Quadrilatero(0, 0, 10, 12, 5, 2),
      new Quadrilatero(0, 0, 15, 12, 5, 2),
      new Quadrilatero(0, 0, 20, 12, 5, 2),
      new Quadrilatero(0, 0, 25, 12, 5, 2),
      new Quadrilatero(0, 0, 30, 12, 5, 2),
      new Quadrilatero(0, 0, 35, 12, 5, 2),
      new Quadrilatero(0, 0, 40, 12, 5, 2),
      new Quadrilatero(0, 0, 45, 12, 5, 2),
    };

    private Mundo()
    {
      objeto.atualizarBBox();
    }

    public static Mundo getInstance()
    {
      if (instance == null)
        instance = new Mundo();
      return instance;
    }

    public void Desenha()
    {
      SRU3D();
      for (var i = 0; i < objetos.Length; i++)
      {
        objetos[i].Desenha();
      }
    }
    public void MouseMove(int x, int y)
    {
    }

    public void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.M)
        objeto.exibeMatriz();
      else
        if (e.Key == Key.P)
        objeto.exibePontos();
      else
        if (e.Key == Key.R)
        objeto.atribuirIdentidade();
      else
        if (e.Key == Key.Left)
        objeto.translacaoXYZ(-10, 0, 0);
      else
        if (e.Key == Key.Right)
        objeto.translacaoXYZ(10, 0, 0);
      else
        if (e.Key == Key.Up)
        objeto.translacaoXYZ(0, 10, 0);
      else
        if (e.Key == Key.Down)
        objeto.translacaoXYZ(0, -10, 0);
      else
        if (e.Key == Key.PageUp)
        objeto.escalaXYZ(2, 2);
      else
        if (e.Key == Key.PageDown)
        objeto.escalaXYZ(0.5, 0.5);
      else
        if (e.Key == Key.Home)
        objeto.escalaXYZPtoFixo(0.5, new Ponto4D(-150, -150));
      else
        if (e.Key == Key.End)
        objeto.escalaXYZPtoFixo(2, new Ponto4D(-150, -150));
      else
        if (e.Key == Key.Number1)
        objeto.rotacaoZ(10);
      else
        if (e.Key == Key.Number2)
        objeto.rotacaoZ(-10);
      if (e.Key == Key.Number3)
        objeto.rotacaoZPtoFixo(10, new Ponto4D(-150, -150));
      else
      if (e.Key == Key.Number4)
        objeto.rotacaoZPtoFixo(-10, new Ponto4D(-150, -150));
      else
      if (e.Key == Key.V)
        objeto.trocaExibeVetorNormal();
    }

    private void SRU3D()
    {
      GL.LineWidth(1);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3(Color.Red);
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3(Color.Green);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.Color3(Color.Blue);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 200);
      GL.End();
    }
  }

}