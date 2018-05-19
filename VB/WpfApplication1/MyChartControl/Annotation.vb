Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Media
Imports System.Collections.Generic

Namespace MyChartControl
	Public Class Annotation
		Inherits DependencyObject
		Public Sub New()
		End Sub

		Private Shared ReadOnly ArgumentProperty As DependencyProperty = DependencyProperty.Register("Argument", GetType(Double), GetType(Annotation))
		Private Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Double), GetType(Annotation))
		Private Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(Annotation))
		Private Shared ReadOnly BackgroundProperty As DependencyProperty = DependencyProperty.Register("Background", GetType(Brush), GetType(Annotation))
		Private Shared ReadOnly BorderColorProperty As DependencyProperty = DependencyProperty.Register("BorderColor", GetType(Brush), GetType(Annotation))
		Private Shared ReadOnly BorderThicknessProperty As DependencyProperty = DependencyProperty.Register("BorderThickness", GetType(Integer), GetType(Annotation))

		Public Property BorderThickness() As Integer
			Get
				Return CInt(Fix(GetValue(BorderThicknessProperty)))
			End Get
			Set(ByVal value As Integer)
				SetValue(BorderThicknessProperty, value)
			End Set
		End Property

		Public Property BorderColor() As Brush
			Get
				Return CType(GetValue(BorderColorProperty), Brush)
			End Get
			Set(ByVal value As Brush)
				SetValue(BorderColorProperty, value)
			End Set
		End Property

		Public Property Background() As Brush
			Get
				Return CType(GetValue(BackgroundProperty), Brush)
			End Get
			Set(ByVal value As Brush)
				SetValue(BackgroundProperty, value)
			End Set
		End Property

		Public Property Text() As String
			Get
				Return CStr(GetValue(TextProperty))
			End Get
			Set(ByVal value As String)
				SetValue(TextProperty, value)
			End Set
		End Property

		Public Property Argument() As Double
			Get
				Return CDbl(GetValue(ArgumentProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(ArgumentProperty, value)
			End Set
		End Property


		Public Property Value() As Double
			Get
				Return CDbl(GetValue(ValueProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(ValueProperty, value)
			End Set
		End Property
	End Class
End Namespace