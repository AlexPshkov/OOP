using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Task1._2_Shapes.Canvas;

public class Canvas : GameWindow, ICanvas
{
    private readonly Color4 _backgroundColor;
    
    private int _shaderProgramHandle;
    
    private int _vertexBufferHandle;
    private int _vertexArrayHandle;

    public Canvas( int width, int height, string title ) : base( GameWindowSettings.Default, new NativeWindowSettings
    {
        Size = ( width, height ), 
        Title = title
    } )
    {
        _backgroundColor = Color4.White;
    }
    
    protected override void OnResize( ResizeEventArgs eventArgs )
    {
        GL.Viewport( 0, 0, eventArgs.Width, eventArgs.Height );
        base.OnResize( eventArgs );
    }

    protected override void OnLoad()
    {
        GL.ClearColor( _backgroundColor );

        const string vertexShader = @"#version 330 core
                                    attribute vec2 value;
                                    uniform mat4 viewMatrix;
                                    uniform mat4 projectionMatrix;
                                    varying vec2 val;

                                    void main()
                                    {
                                    }";

        const string pixelShader = @"#version 330 core
                                        out vec4 FragColor;
                                        varying vec2 val;
                                        
                                        void main()
                                        {
                                            float R = 1.0;
            
                                        }";

        int vertexShaderHandle = GL.CreateShader( ShaderType.VertexShader );
        GL.ShaderSource( vertexShaderHandle, vertexShader );
        GL.CompileShader( vertexShaderHandle );

        int pixelShaderHandle = GL.CreateShader( ShaderType.FragmentShader );
        GL.ShaderSource( pixelShaderHandle, pixelShader );
        GL.CompileShader( pixelShaderHandle );

        _shaderProgramHandle = GL.CreateProgram();
        GL.AttachShader( _shaderProgramHandle, vertexShaderHandle );
        GL.AttachShader( _shaderProgramHandle, pixelShaderHandle );

        GL.LinkProgram( _shaderProgramHandle );

        GL.DetachShader( _shaderProgramHandle, vertexShaderHandle );
        GL.DetachShader( _shaderProgramHandle, pixelShaderHandle );

        GL.DeleteShader( vertexShaderHandle );
        GL.DeleteShader( pixelShaderHandle );

        base.OnLoad();
    }

    protected override void OnUnload()
    {
        GL.DeleteVertexArrays( 1, ref _vertexArrayHandle );
        GL.DeleteBuffers( 1, ref _vertexBufferHandle );
        GL.UseProgram( 0 );
        GL.DeleteProgram( _shaderProgramHandle );
        
        base.OnUnload();
    }

    protected override void OnRenderFrame( FrameEventArgs args )
    {
        GL.ClearColor(_backgroundColor );
        GL.Clear( ClearBufferMask.ColorBufferBit );

        GL.UseProgram( _shaderProgramHandle );
        
        // render the triangle
        GL.BindVertexArray( _vertexArrayHandle );
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3 );

        Context.SwapBuffers();

        base.OnRenderFrame( args );
    }

    
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        if (KeyboardState.IsKeyDown( Keys.Space ))
        {
            DrawTriangle();
        }
    }
    

    public void DrawTriangle()
    {
        float[] vertices = {
            0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            0.0f,  0.5f, 0.0f   // top 
        };
        
        GL.GenVertexArrays( 1, out _vertexArrayHandle );
         
        GL.GenBuffers( 1, out _vertexBufferHandle );
        GL.BindVertexArray( _vertexArrayHandle );
         
        GL.BindBuffer( BufferTarget.ArrayBuffer, _vertexBufferHandle );
        GL.BufferData( BufferTarget.ArrayBuffer, vertices.Length * sizeof( float ), vertices, BufferUsageHint.StaticDraw );
         
        GL.VertexAttribPointer( 0, 3, VertexAttribPointerType.Float, false, 3 * sizeof( float ), 0 );
        GL.EnableVertexAttribArray( 0 );
        GL.BindVertexArray( 0 );
    }

    public void DrawLine( Point startPoint, Point endPoint, Color lineColor )
    {
        // sf::Vertex line[] = {
        //     sf::Vertex(sf::Vector2f((float)startPoint.GetPointX(), (float)startPoint.GetPointY())),
        //     sf::Vertex(sf::Vector2f((float)endPoint.GetPointX(), (float)endPoint.GetPointY()))
        // };
        // line[0].color = sf::Color(lineColor);
        // line[1].color = sf::Color(lineColor);

        // m_renderWindow.draw(line, 2, sf::Lines);
    }

    public void FillPolygon( List<Point> points, Color fillColor )
    {
        // sf::ConvexShape convex;
        // convex.setPointCount(points.size());
        //
        // for (size_t i = 0; i < points.size(); ++i)
        // {
        //     convex.setPoint(i, sf::Vector2f((float)points[i].GetPointX(), (float)points[i].GetPointY()));
        // }
        // sf::Color color(fillColor);
        // convex.setFillColor(color);

        // m_renderWindow.draw(convex);
    }

    public void DrawCircle( Point centerPoint, double radius, Color lineColor )
    {
        // sf::CircleShape circle((float)radius);
        // circle.setPosition((float)centerPoint.GetPointX() - (float)radius, (float)centerPoint.GetPointY() - (float)radius);
        //
        // circle.setFillColor(sf::Color::Transparent);
        // circle.setOutlineThickness(2);
        // circle.setOutlineColor(sf::Color(lineColor));

        // m_renderWindow.draw(circle);
    }

    public void FillCircle( Point centerPoint, double radius, Color fillColor )
    {
        // sf::CircleShape circle;
        // circle.setRadius((float)radius);
        // circle.setPosition((float)centerPoint.GetPointX() - (float)radius, (float)centerPoint.GetPointY() - (float)radius);
        //
        // circle.setFillColor(sf::Color(fillColor));

        // m_renderWindow.draw(circle);
    }
}