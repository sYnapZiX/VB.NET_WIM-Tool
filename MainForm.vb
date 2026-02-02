Imports System.IO
Public Class MainForm
    ' VARIABLES ###################################################################################################################################################################################################################################################################################################

    Private AvailableEditions As New List(Of String)
    Private DISMHeader As String = String.Empty

    ' FORM CONTROLS ###############################################################################################################################################################################################################################################################################################
    Private Sub SourceBrowseButton_Click(sender As Object, e As EventArgs) Handles SourceBrowseButton.Click
        Dim OpenWIMResult As DialogResult = OpenWIMDialog.ShowDialog
        If OpenWIMResult = DialogResult.OK Then
            SourceWIMTextBox.Text = OpenWIMDialog.FileName
        End If
    End Sub
    Private Sub SourceWIMTextBox_TextChanged(sender As Object, e As EventArgs) Handles SourceWIMTextBox.TextChanged
        If File.Exists(SourceWIMTextBox.Text) Then
            SourceIndexNumeric.Value = 1
            SourceIndexNumeric.Enabled = True
            GetInfoButton.Enabled = True

            If TargetWIMTextBox.Text <> "" Then
                RepackButton.Enabled = True
            Else
                RepackButton.Enabled = False
            End If

            DISM_GetInfo()
        Else
            SourceIndexNumeric.Enabled = False
            SourceIndexNumeric.Value = 1
            SelectedEditionLabel.Visible = False
            GetInfoButton.Enabled = False

            RepackButton.Enabled = False
        End If
    End Sub
    Private Sub SourceIndexNumeric_ValueChanged(sender As Object, e As EventArgs) Handles SourceIndexNumeric.ValueChanged
        TrySetEditionName()
    End Sub
    Private Sub GetInfoButton_Click(sender As Object, e As EventArgs) Handles GetInfoButton.Click
        DISM_GetInfo()
    End Sub
    Private Sub TargetBrowseButton_Click(sender As Object, e As EventArgs) Handles TargetBrowseButton.Click
        Dim SaveWIMResult As DialogResult = SaveWIMDialog.ShowDialog
        If SaveWIMResult = DialogResult.OK Then
            TargetWIMTextBox.Text = SaveWIMDialog.FileName
        End If
    End Sub
    Private Sub TargetWIMTextBox_TextChanged(sender As Object, e As EventArgs) Handles TargetWIMTextBox.TextChanged
        If File.Exists(SourceWIMTextBox.Text) AndAlso TargetWIMTextBox.Text <> "" Then
            RepackButton.Enabled = True
        Else
            RepackButton.Enabled = False
        End If
    End Sub
    Private Sub RepackButton_Click(sender As Object, e As EventArgs) Handles RepackButton.Click
        DISM_Repack()
    End Sub

    ' UI RELATED ##################################################################################################################################################################################################################################################################################################
    Private Sub DisableControls()
        UseWaitCursor = True

        SourceWIMTextBox.ReadOnly = True
        SourceBrowseButton.Enabled = False
        SourceIndexNumeric.Enabled = False
        GetInfoButton.Enabled = False

        TargetWIMTextBox.ReadOnly = True
        TargetBrowseButton.Enabled = False
        RepackButton.Enabled = False
    End Sub
    Private Sub EnableControls()
        SourceWIMTextBox.ReadOnly = False
        SourceBrowseButton.Enabled = True
        SourceIndexNumeric.Enabled = True
        TrySetEditionName()
        GetInfoButton.Enabled = True

        TargetWIMTextBox.ReadOnly = False
        TargetBrowseButton.Enabled = True
        RepackButton.Enabled = True

        UseWaitCursor = False
    End Sub
    Private Sub TrySetEditionName()
        Try
            SelectedEditionLabel.Text = AvailableEditions.Item(CInt(SourceIndexNumeric.Value) - 1)
            SelectedEditionLabel.Visible = True
        Catch
            SelectedEditionLabel.Text = ""
            SelectedEditionLabel.Visible = False
        End Try
    End Sub
    Private Sub UpdateLogTextBox(Text As String)
        LogTextBox.AppendText(Text & vbNewLine)
        If LogTextBox.Lines.Count = 4 Then
            LogTextBox.AppendText(vbNewLine)
            DISMHeader = DISM_GetHeader()
        End If

        If DISM_IsIndexLine(Text) Then
            SourceIndexNumeric.Maximum = DISM_TryGetMaxIndex(Text)
        End If

        If DISM_IsNameLine(Text) Then
            AvailableEditions.Add(DISM_TryGetEditionName(Text))
        End If

        If DISM_IsProgressLine(Text) Then
            LogTextBox.Clear()
            LogTextBox.AppendText(DISMHeader)
            LogTextBox.AppendText(Text & vbNewLine)
        End If

        If DISM_IsSpecialFormatLine(Text) Then
            LogTextBox.AppendText(vbNewLine)
        End If

        LogTextBox.ScrollToCaret()
    End Sub

    ' DISM COMMANDS AND FUNCTIONS #################################################################################################################################################################################################################################################################################
    Private Function DISM_GetHeader() As String
        Return LogTextBox.Lines(0) & vbNewLine & LogTextBox.Lines(1) & vbNewLine & LogTextBox.Lines(2) & vbNewLine & vbNewLine
    End Function
    Private Sub DISM_GetInfo()
        AvailableEditions.Clear()
        SelectedEditionLabel.Visible = False
        LogTextBox.Clear()
        DisableControls()

        Try
            Dim DISMProcess As New Process()

            With DISMProcess.StartInfo
                .FileName = "DISM.exe"
                .Arguments = "/Get-WimInfo /WimFile:" & SourceWIMTextBox.Text
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .StandardOutputEncoding = System.Text.Encoding.GetEncoding(437)
                .RedirectStandardError = True
                .StandardErrorEncoding = System.Text.Encoding.GetEncoding(437)
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With

            DISMProcess.EnableRaisingEvents = True

            AddHandler DISMProcess.OutputDataReceived, Sub(sender, e)
                                                           If Not String.IsNullOrEmpty(e.Data) Then
                                                               LogTextBox.Invoke(Sub() UpdateLogTextBox(e.Data))
                                                           End If
                                                       End Sub

            AddHandler DISMProcess.ErrorDataReceived, Sub(sender, e)
                                                          If Not String.IsNullOrEmpty(e.Data) Then
                                                              LogTextBox.Invoke(Sub() UpdateLogTextBox("ERROR: " & e.Data))
                                                          End If
                                                      End Sub

            AddHandler DISMProcess.Exited, Sub(sender, e)
                                               Invoke(Sub() EnableControls())
                                               DISMProcess.Dispose()
                                           End Sub

            DISMProcess.Start()
            DISMProcess.BeginOutputReadLine()
            DISMProcess.BeginErrorReadLine()
        Catch
        End Try
    End Sub
    Private Function DISM_IsNameLine(Text As String) As Boolean
        Return Text.StartsWith("Name: ")
    End Function
    Private Function DISM_IsIndexLine(Text As String) As Boolean
        Return Text.StartsWith("Index: ")
    End Function
    Private Function DISM_IsProgressLine(Text As String) As Boolean
        Return Text.StartsWith("[")
    End Function
    Private Function DISM_IsSpecialFormatLine(Text As String) As Boolean
        Return Text.StartsWith("Größe") OrElse Text.StartsWith("Size") OrElse Text.Contains("100.0%")
    End Function
    Private Sub DISM_Repack()
        LogTextBox.Clear()
        DisableControls()

        Try
            Dim DISMProcess As New Process()

            With DISMProcess.StartInfo
                .FileName = "DISM.exe"
                .Arguments = "/Export-image /sourceimagefile:" & SourceWIMTextBox.Text & " /SourceIndex:" & SourceIndexNumeric.Value.ToString & " /DestinationImageFile:" & TargetWIMTextBox.Text & " /Compress:max /CheckIntegrity"
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .StandardOutputEncoding = System.Text.Encoding.GetEncoding(437)
                .RedirectStandardError = True
                .StandardErrorEncoding = System.Text.Encoding.GetEncoding(437)
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With

            DISMProcess.EnableRaisingEvents = True

            AddHandler DISMProcess.OutputDataReceived, Sub(sender, e)
                                                           If Not String.IsNullOrEmpty(e.Data) Then
                                                               LogTextBox.Invoke(Sub() UpdateLogTextBox(e.Data))
                                                           End If
                                                       End Sub

            AddHandler DISMProcess.ErrorDataReceived, Sub(sender, e)
                                                          If Not String.IsNullOrEmpty(e.Data) Then
                                                              LogTextBox.Invoke(Sub() UpdateLogTextBox("ERROR: " & e.Data))
                                                          End If
                                                      End Sub

            AddHandler DISMProcess.Exited, Sub(sender, e)
                                               Invoke(Sub() EnableControls())
                                               DISMProcess.Dispose()
                                           End Sub

            DISMProcess.Start()
            DISMProcess.BeginOutputReadLine()
            DISMProcess.BeginErrorReadLine()
        Catch
        End Try
    End Sub
    Private Function DISM_TryGetEditionName(Text As String) As String
        Try
            Return Text.Split(CChar(":"))(1).Replace("""", "").Remove(0, 1)
        Catch
            Return ""
        End Try
    End Function
    Private Function DISM_TryGetMaxIndex(Text As String) As Decimal
        Try
            Return CDec(Text.Split(CChar(" "))(1).Replace("""", ""))
        Catch
            Return 99
        End Try
    End Function
End Class
