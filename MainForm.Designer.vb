<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SourceWIMTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SourceWIMLabel = New System.Windows.Forms.Label()
        Me.SourceBrowseButton = New System.Windows.Forms.Button()
        Me.TargetBrowseButton = New System.Windows.Forms.Button()
        Me.TargetWIMLabel = New System.Windows.Forms.Label()
        Me.TargetWIMTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GetInfoButton = New System.Windows.Forms.Button()
        Me.RepackButton = New System.Windows.Forms.Button()
        Me.SourceIndexLabel = New System.Windows.Forms.Label()
        Me.SourceIndexNumeric = New System.Windows.Forms.NumericUpDown()
        Me.OpenWIMDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveWIMDialog = New System.Windows.Forms.SaveFileDialog()
        Me.LogTextBox = New System.Windows.Forms.RichTextBox()
        Me.SelectedEditionLabel = New System.Windows.Forms.Label()
        CType(Me.SourceIndexNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SourceWIMTextBox
        '
        Me.SourceWIMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SourceWIMTextBox.Location = New System.Drawing.Point(85, 13)
        Me.SourceWIMTextBox.Name = "SourceWIMTextBox"
        Me.SourceWIMTextBox.Size = New System.Drawing.Size(228, 20)
        Me.SourceWIMTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(85, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 20)
        Me.Panel1.TabIndex = 1
        '
        'SourceWIMLabel
        '
        Me.SourceWIMLabel.AutoSize = True
        Me.SourceWIMLabel.Location = New System.Drawing.Point(9, 15)
        Me.SourceWIMLabel.Name = "SourceWIMLabel"
        Me.SourceWIMLabel.Size = New System.Drawing.Size(70, 13)
        Me.SourceWIMLabel.TabIndex = 2
        Me.SourceWIMLabel.Text = "Source WIM:"
        '
        'SourceBrowseButton
        '
        Me.SourceBrowseButton.Location = New System.Drawing.Point(319, 11)
        Me.SourceBrowseButton.Name = "SourceBrowseButton"
        Me.SourceBrowseButton.Size = New System.Drawing.Size(75, 24)
        Me.SourceBrowseButton.TabIndex = 1
        Me.SourceBrowseButton.Text = "Browse..."
        Me.SourceBrowseButton.UseVisualStyleBackColor = True
        '
        'TargetBrowseButton
        '
        Me.TargetBrowseButton.Location = New System.Drawing.Point(319, 89)
        Me.TargetBrowseButton.Name = "TargetBrowseButton"
        Me.TargetBrowseButton.Size = New System.Drawing.Size(75, 24)
        Me.TargetBrowseButton.TabIndex = 5
        Me.TargetBrowseButton.Text = "Browse..."
        Me.TargetBrowseButton.UseVisualStyleBackColor = True
        '
        'TargetWIMLabel
        '
        Me.TargetWIMLabel.AutoSize = True
        Me.TargetWIMLabel.Location = New System.Drawing.Point(9, 93)
        Me.TargetWIMLabel.Name = "TargetWIMLabel"
        Me.TargetWIMLabel.Size = New System.Drawing.Size(67, 13)
        Me.TargetWIMLabel.TabIndex = 6
        Me.TargetWIMLabel.Text = "Target WIM:"
        '
        'TargetWIMTextBox
        '
        Me.TargetWIMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TargetWIMTextBox.Location = New System.Drawing.Point(85, 91)
        Me.TargetWIMTextBox.Name = "TargetWIMTextBox"
        Me.TargetWIMTextBox.Size = New System.Drawing.Size(228, 20)
        Me.TargetWIMTextBox.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(85, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(228, 20)
        Me.Panel2.TabIndex = 5
        '
        'GetInfoButton
        '
        Me.GetInfoButton.Enabled = False
        Me.GetInfoButton.Location = New System.Drawing.Point(319, 37)
        Me.GetInfoButton.Name = "GetInfoButton"
        Me.GetInfoButton.Size = New System.Drawing.Size(75, 24)
        Me.GetInfoButton.TabIndex = 3
        Me.GetInfoButton.Text = "Get Info"
        Me.GetInfoButton.UseVisualStyleBackColor = True
        '
        'RepackButton
        '
        Me.RepackButton.Enabled = False
        Me.RepackButton.Location = New System.Drawing.Point(319, 115)
        Me.RepackButton.Name = "RepackButton"
        Me.RepackButton.Size = New System.Drawing.Size(75, 24)
        Me.RepackButton.TabIndex = 6
        Me.RepackButton.Text = "Repack"
        Me.RepackButton.UseVisualStyleBackColor = True
        '
        'SourceIndexLabel
        '
        Me.SourceIndexLabel.AutoSize = True
        Me.SourceIndexLabel.Location = New System.Drawing.Point(9, 43)
        Me.SourceIndexLabel.Name = "SourceIndexLabel"
        Me.SourceIndexLabel.Size = New System.Drawing.Size(73, 13)
        Me.SourceIndexLabel.TabIndex = 10
        Me.SourceIndexLabel.Text = "Source Index:"
        '
        'SourceIndexNumeric
        '
        Me.SourceIndexNumeric.Enabled = False
        Me.SourceIndexNumeric.Location = New System.Drawing.Point(85, 41)
        Me.SourceIndexNumeric.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.SourceIndexNumeric.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SourceIndexNumeric.Name = "SourceIndexNumeric"
        Me.SourceIndexNumeric.Size = New System.Drawing.Size(34, 20)
        Me.SourceIndexNumeric.TabIndex = 2
        Me.SourceIndexNumeric.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'OpenWIMDialog
        '
        Me.OpenWIMDialog.Filter = "Windows Imaging Format Archive|*.wim"
        Me.OpenWIMDialog.Title = "Please select a source WIM file..."
        '
        'SaveWIMDialog
        '
        Me.SaveWIMDialog.DefaultExt = "wim"
        Me.SaveWIMDialog.FileName = "install.wim"
        Me.SaveWIMDialog.Filter = "Windows Imaging Format Archive|*.wim"
        Me.SaveWIMDialog.Title = "Please select the destination for the target WIM file..."
        '
        'LogTextBox
        '
        Me.LogTextBox.BackColor = System.Drawing.Color.Black
        Me.LogTextBox.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogTextBox.ForeColor = System.Drawing.Color.Lime
        Me.LogTextBox.Location = New System.Drawing.Point(12, 167)
        Me.LogTextBox.Name = "LogTextBox"
        Me.LogTextBox.ReadOnly = True
        Me.LogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.LogTextBox.Size = New System.Drawing.Size(382, 271)
        Me.LogTextBox.TabIndex = 7
        Me.LogTextBox.Text = ""
        Me.LogTextBox.WordWrap = False
        '
        'SelectedEditionLabel
        '
        Me.SelectedEditionLabel.AutoSize = True
        Me.SelectedEditionLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.SelectedEditionLabel.Location = New System.Drawing.Point(123, 43)
        Me.SelectedEditionLabel.Name = "SelectedEditionLabel"
        Me.SelectedEditionLabel.Size = New System.Drawing.Size(33, 13)
        Me.SelectedEditionLabel.TabIndex = 11
        Me.SelectedEditionLabel.Text = "None"
        Me.SelectedEditionLabel.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 450)
        Me.Controls.Add(Me.SelectedEditionLabel)
        Me.Controls.Add(Me.LogTextBox)
        Me.Controls.Add(Me.SourceIndexNumeric)
        Me.Controls.Add(Me.SourceIndexLabel)
        Me.Controls.Add(Me.RepackButton)
        Me.Controls.Add(Me.GetInfoButton)
        Me.Controls.Add(Me.TargetBrowseButton)
        Me.Controls.Add(Me.TargetWIMLabel)
        Me.Controls.Add(Me.TargetWIMTextBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.SourceBrowseButton)
        Me.Controls.Add(Me.SourceWIMLabel)
        Me.Controls.Add(Me.SourceWIMTextBox)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WIM-Tool 0.1"
        CType(Me.SourceIndexNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SourceWIMTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SourceWIMLabel As Label
    Friend WithEvents SourceBrowseButton As Button
    Friend WithEvents TargetBrowseButton As Button
    Friend WithEvents TargetWIMLabel As Label
    Friend WithEvents TargetWIMTextBox As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GetInfoButton As Button
    Friend WithEvents RepackButton As Button
    Friend WithEvents SourceIndexLabel As Label
    Friend WithEvents SourceIndexNumeric As NumericUpDown
    Friend WithEvents OpenWIMDialog As OpenFileDialog
    Friend WithEvents SaveWIMDialog As SaveFileDialog
    Friend WithEvents LogTextBox As RichTextBox
    Friend WithEvents SelectedEditionLabel As Label
End Class
