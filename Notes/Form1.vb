Imports System.IO
Imports System.Net.Http

Public Class Form1

    Private newNoteCounter As Integer = 0

    Private Sub NewTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTabToolStripMenuItem.Click
        CreateNewTab()
    End Sub

    Private Sub CreateNewTab()
        newNoteCounter += 1
        Dim newTab As New TabPage($"New Note {newNoteCounter}")
        Dim rtb As New RichTextBox()
        rtb.Dock = DockStyle.Fill
        rtb.BorderStyle = BorderStyle.None
        rtb.ContextMenuStrip = RtbContextMenuStrip
        newTab.Controls.Add(rtb)
        TabControl.TabPages.Add(newTab)
        TabControl.SelectedTab = newTab
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        If TabControl.TabPages.Count > 0 Then
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        End If
    End Sub

    Private Function GetCurrentRichTextBox() As RichTextBox
        If TabControl.TabPages.Count > 0 AndAlso TypeOf TabControl.SelectedTab.Controls(0) Is RichTextBox Then
            Return CType(TabControl.SelectedTab.Controls(0), RichTextBox)
        End If
        Return Nothing
    End Function

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        CreateNewTab()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        CreateNewTab()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        If TabControl.TabPages.Count > 0 Then
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files|*.txt|Rich Text Files|*.rtf"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim newTab As New TabPage(Path.GetFileName(openFileDialog.FileName))
            Dim rtb As New RichTextBox()
            rtb.BorderStyle = BorderStyle.None
            rtb.ContextMenuStrip = RtbContextMenuStrip
            rtb.Dock = DockStyle.Fill
            If Path.GetExtension(openFileDialog.FileName).ToLower() = ".rtf" Then
                rtb.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText)
            Else
                rtb.Text = File.ReadAllText(openFileDialog.FileName)
            End If
            newTab.Controls.Add(rtb)
            TabControl.TabPages.Add(newTab)
            TabControl.SelectedTab = newTab
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFile()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFile(True)
    End Sub

    Private Sub SaveFile(Optional ByVal saveAs As Boolean = False)
        Dim rtb As RichTextBox = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Text Files|*.txt|Rich Text Files|*.rtf"

        If saveAs OrElse String.IsNullOrEmpty(rtb.Tag) Then
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                rtb.Tag = saveFileDialog.FileName
                TabControl.SelectedTab.Text = Path.GetFileName(saveFileDialog.FileName)
            Else
                Return
            End If
        End If

        Dim fileName As String = rtb.Tag.ToString()
        If Path.GetExtension(fileName).ToLower() = ".rtf" Then
            rtb.SaveFile(fileName, RichTextBoxStreamType.RichText)
        Else
            File.WriteAllText(fileName, rtb.Text)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        GetCurrentRichTextBox()?.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        GetCurrentRichTextBox()?.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        GetCurrentRichTextBox()?.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanUndo Then rtb.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanRedo Then rtb.Redo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        GetCurrentRichTextBox()?.SelectAll()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim fontDialog As New FontDialog()
        If fontDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionFont = fontDialog.Font
        End If
    End Sub

    Private Sub TextColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontColorToolStripMenuItem.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionColor = colorDialog.Color
        End If
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionBackColor = colorDialog.Color
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        GetCurrentRichTextBox()?.Cut()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        GetCurrentRichTextBox()?.Copy()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        GetCurrentRichTextBox()?.Paste()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        SaveFile()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SaveFile(True)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim fontDialog As New FontDialog()
        If fontDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionFont = fontDialog.Font
        End If
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionColor = colorDialog.Color
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb Is Nothing Then Return

        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            rtb.SelectionBackColor = colorDialog.Color
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files|*.txt|Rich Text Files|*.rtf"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim newTab As New TabPage(Path.GetFileName(openFileDialog.FileName))
            Dim rtb As New RichTextBox()
            rtb.BorderStyle = BorderStyle.None
            rtb.ContextMenuStrip = RtbContextMenuStrip
            rtb.Dock = DockStyle.Fill
            If Path.GetExtension(openFileDialog.FileName).ToLower() = ".rtf" Then
                rtb.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText)
            Else
                rtb.Text = File.ReadAllText(openFileDialog.FileName)
            End If
            newTab.Controls.Add(rtb)
            TabControl.TabPages.Add(newTab)
            TabControl.SelectedTab = newTab
        End If
    End Sub

    Private Sub CutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        GetCurrentRichTextBox()?.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        GetCurrentRichTextBox()?.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        GetCurrentRichTextBox()?.Paste()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanRedo Then rtb.Redo()
    End Sub

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanUndo Then rtb.Undo()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        GetCurrentRichTextBox()?.SelectAll()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanUndo Then rtb.Undo()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim rtb = GetCurrentRichTextBox()
        If rtb IsNot Nothing AndAlso rtb.CanRedo Then rtb.Redo()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateNewTab()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Made by Aryan Sharma." + vbNewLine + "Copyright 2024 All Rights Reservered", "About", MessageBoxButtons.OK)
    End Sub

    Private Async Sub CheckForUpdates()
        Dim currentVersion As String = "1.0.0.0" ' Current version of your application
        Dim latestVersion As String = Await GetLatestReleaseVersion()

        If Not String.IsNullOrEmpty(latestVersion) AndAlso latestVersion <> currentVersion Then
            Dim result As DialogResult = MessageBox.Show("A new version is available. Do you want to update?", "Update Available", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Await DownloadLatestRelease()
                MessageBox.Show("Update downloaded. Please restart the application to apply the update.", "Update Complete")
            End If
        Else
            MessageBox.Show("Your application is up to date.", "No Updates Available")
        End If
    End Sub

    Private Async Function GetLatestReleaseVersion() As Task(Of String)
        Dim latestVersion As String = String.Empty
        Dim url As String = "https://github.com/TopxT750/Notes/releases/"

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("User-Agent", "Notes")
            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Dim release As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(json)
                latestVersion = release("tag_name").ToString()
            End If
        End Using

        Return latestVersion
    End Function

    Private Async Function DownloadLatestRelease() As Task
        Dim url As String = "https://github.com/TopxT750/Notes/releases/latest/download/Notes.Setup.msi"
        Dim downloadPath As String = Path.Combine(Application.StartupPath, "Notes.Setup.exe")

        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Using fileStream As New FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None)
                    Await response.Content.CopyToAsync(fileStream)
                End Using
            End If
        End Using
    End Function

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        CheckForUpdates()
    End Sub
End Class
