﻿Public Class frmMenu

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GenerarMenues()
        Me.lblTitulo.Text = Titulo
    End Sub

    Private Sub GenerarMenues()
        Try
            Me.lstMenu.Items.Clear()
            Me.lstMenu.Items.Add("1) Recepcion de bultos")
            Me.lstMenu.Items.Add("2) Hoja de Ruta")
            Me.lstMenu.Items.Add("3) Salir")
            txtOpcion.Text = ""
            txtOpcion.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Titulo)
        End Try
    End Sub

    Private Sub txtOpcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress

    End Sub

    Private Sub lstMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMenu.GotFocus
        Me.txtOpcion.Focus()
    End Sub

    Private Sub txtOpcion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOpcion.KeyUp
        Dim MSGopt As String = "La opcion ingresada no es valida."
        If e.KeyValue = 13 Then
            If Me.txtOpcion.Text.Trim = "" Then
                Me.txtOpcion.Text = ""
                Me.txtOpcion.Focus()
                Exit Sub
            End If
            If Not IsNumeric(Me.txtOpcion.Text) Then
                Me.txtOpcion.Text = ""
                MsgBox(MSGopt, MsgBoxStyle.Information, Titulo)
                Exit Sub
            End If
            If Me.txtOpcion.Text <> "" Then
                Select Case Me.txtOpcion.Text.Trim
                    Case "1"
                        Dim Fa As New frmIngresoBultos
                        Try
                            Fa.ShowDialog()
                        Catch ex As Exception
                        Finally
                            Fa = Nothing
                        End Try
                    Case "2"
                        Dim Fb As New frmHDR
                        Try
                            Fb.ShowDialog()
                        Catch ex As Exception
                        Finally
                            Fb = Nothing
                        End Try
                    Case "3"
                        SalirApp()
                End Select
                Me.txtOpcion.Text = ""
            End If
        End If
    End Sub

    Private Sub SalirApp()
        Dim Msg As String = "¿Desea salir de la aplicacion?"
        If MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, Titulo) = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Me.txtOpcion.Text = ""
            Me.txtOpcion.Focus()
        End If
    End Sub

    Private Sub txtOpcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOpcion.TextChanged

    End Sub

End Class