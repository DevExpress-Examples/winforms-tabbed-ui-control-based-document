Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraBars.Docking2010.Views.Tabbed
Imports DevExpress.XtraBars.Docking2010.Views.NativeMdi
Imports DevExpress.XtraBars.Docking2010.Views

Namespace DcoumentManagerContentGenerator
	Partial Public Class Form1
		Inherits Form
		Private index As Integer = 1
		Public Sub New()
			InitializeComponent()
			documentManager2.View.DocumentProperties.UseFormIconAsDocumentImage = False
			documentManager2.View.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.True
			tabbedView1.FloatingDocumentContainer = FloatingDocumentContainer.DocumentsHost
		End Sub
		Private Sub AddNewTextDoc(ByVal s As String, ByVal tabbed As Boolean)
			Dim newTB As New RichEditControl()
			newTB.Size = New Size(400, 170)
			newTB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			newTB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.PrintLayout
			newTB.Views.PrintLayoutView.ZoomFactor = 0.7f
			newTB.Name = s & index.ToString()
			newTB.Text = s & " " & index.ToString()
			documentManager2.View.BeginUpdate()
			If tabbed = True Then
				documentManager2.View.AddDocument(newTB)
			Else
				documentManager2.View.AddFloatDocument(newTB)
			End If
			documentManager2.View.EndUpdate()
			index += 1
		End Sub

		Private Sub addTabbedDoc(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barButtonItem1.ItemClick
			AddNewTextDoc("Document", True)
		End Sub

		Private Sub addFloatDoc(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barButtonItem3.ItemClick
			AddNewTextDoc("Document", False)
		End Sub

		Private Sub closeAllDocs(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barButtonItem2.ItemClick
			documentManager2.View.Controller.CloseAll()
			index = 1
		End Sub
	End Class
End Namespace
