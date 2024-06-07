Imports System.Deployment.Application
Imports System.IO
Imports System.Net.Http
Imports Guna.UI2.WinForms
Imports Newtonsoft.Json.Linq

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
        AddHandler rtb.TextChanged, AddressOf RichTextBox_TextChanged
        AddHandler rtb.SelectionChanged, AddressOf RichTextBox_SelectionChanged
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
        MessageBox.Show($"Notes Version: {My.Application.Info.Version}" + vbNewLine + "Made by Aryan Sharma." + vbNewLine + "Copyright 2024 All Rights Reserved", "About", MessageBoxButtons.OK)
    End Sub

    Private Async Sub CheckForUpdates()
        Try
            Dim latestVersion As String = Await GetLatestReleaseVersion()

            ' Check if latestVersion is empty or null
            If Not String.IsNullOrEmpty(latestVersion) Then
                Dim currentVersion As Version = Version.Parse(Application.ProductVersion)
                Dim latestVersionParsed As Version

                ' Parse the latest version if it's a valid string
                If Version.TryParse(latestVersion, latestVersionParsed) Then
                    If latestVersionParsed > currentVersion Then
                        If MessageBox.Show("A new version is available. Do you want to download and install it?", "Update Available", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            Await DownloadAndInstallLatestRelease()
                        End If
                    Else
                        MessageBox.Show("You are already using the latest version.")
                    End If
                Else
                    MessageBox.Show("Failed to parse the latest version from the server.")
                End If
            Else
                MessageBox.Show("Failed to retrieve the latest version from the server.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while checking for updates: " & ex.Message)
        End Try
    End Sub


    Private Async Function GetLatestReleaseVersion() As Task(Of String)
        Try
            Using client As New HttpClient()
                Dim url As String = "https://api.github.com/repos/TopxT750/notes/releases/latest"
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request") ' GitHub API requires a user agent

                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()

                Dim responseContent As String = Await response.Content.ReadAsStringAsync()

                ' Check if the response content is JSON
                If response.Content.Headers.ContentType.MediaType = "application/json" Then
                    Dim json As JObject = JObject.Parse(responseContent)
                    Dim tagName As String = json("tag_name").ToString().Trim()

                    ' Check if tagName is in the expected format (e.g., "v1.0.0")
                    If tagName.StartsWith("v") AndAlso Version.TryParse(tagName.Substring(1), New Version()) Then
                        Return tagName.Substring(1) ' Remove the leading "v"
                    Else
                        Throw New Exception("Unexpected version format.")
                    End If
                Else
                    Throw New Exception("Unexpected response format.")
                End If
            End Using
        Catch ex As Exception
            ' Log the error message
            Console.WriteLine("Error in GetLatestReleaseVersion: " & ex.Message)
            ' Return an empty string or handle the error as needed
            Return ""
        End Try
    End Function



    Private Async Function DownloadAndInstallLatestRelease() As Task
        Using client As New HttpClient()
            ' Get the latest release information
            Dim url As String = "https://api.github.com/repos/TopxT750/notes/releases/latest"
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request") ' GitHub API requires a user agent

            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            response.EnsureSuccessStatusCode()

            Dim responseContent As String = Await response.Content.ReadAsStringAsync()
            Dim json As JObject = JObject.Parse(responseContent)

            ' Get the URL of the asset to download
            Dim assetUrl As String = json("assets")(0)("browser_download_url").ToString() ' Adjust index if there are multiple assets

            ' Download the asset
            Dim downloadResponse As HttpResponseMessage = Await client.GetAsync(assetUrl)
            downloadResponse.EnsureSuccessStatusCode()

            ' Save the asset to a temporary file
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "Notes Setup.msi") ' Adjust the file extension if needed
            Using fileStream As New FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Await downloadResponse.Content.CopyToAsync(fileStream)
            End Using

            ' Run the installer
            Dim startInfo As New ProcessStartInfo(tempFilePath) With {
                .UseShellExecute = True
            }
            Process.Start(startInfo)

            ' Close the current application
            Application.Exit()
        End Using
    End Function

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs)
        UpdateStatus()
    End Sub

    Private Sub RichTextBox_SelectionChanged(sender As Object, e As EventArgs)
        UpdateStatus()
    End Sub

    Private Sub UpdateStatus()
        If TabControl.SelectedTab IsNot Nothing AndAlso TabControl.SelectedTab.Controls.Count > 0 Then
            Dim rtb As RichTextBox = CType(TabControl.SelectedTab.Controls(0), RichTextBox)
            Dim words As Integer = rtb.Text.Split(New Char() {" "c, ControlChars.Lf, ControlChars.Tab, ControlChars.Cr}, StringSplitOptions.RemoveEmptyEntries).Length
            ToolStripStatusLabel3.Text = $"Words: {words}"

            Dim lineIndex As Integer = rtb.GetLineFromCharIndex(rtb.SelectionStart)
            Dim columnIndex As Integer = rtb.SelectionStart - rtb.GetFirstCharIndexOfCurrentLine() + 1
            ToolStripStatusLabel1.Text = $"Line: {lineIndex + 1}"
            ToolStripStatusLabel2.Text = $"Column: {columnIndex}"
        End If
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        CheckForUpdates()
    End Sub

    Private Async Sub ShowLatestReleaseInfo()
        Try
            Dim releaseInfo As ReleaseInfo = Await GetLatestReleaseInfo()

            If releaseInfo IsNot Nothing Then
                MessageBox.Show($"Latest Version: {releaseInfo.Version}" & vbCrLf &
                            $"Release Notes: {releaseInfo.Description}",
                            "Latest Release Information", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Failed to retrieve release information from the server.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while fetching release information: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function GetLatestReleaseInfo() As Task(Of ReleaseInfo)
        Try
            Using client As New HttpClient()
                Dim url As String = "https://api.github.com/repos/TopxT750/notes/releases/latest"
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request") ' GitHub API requires a user agent

                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()

                Dim responseContent As String = Await response.Content.ReadAsStringAsync()

                ' Check if the response content is JSON
                If response.Content.Headers.ContentType.MediaType = "application/json" Then
                    Dim json As JObject = JObject.Parse(responseContent)
                    Dim tagName As String = json("tag_name").ToString().Trim()
                    Dim description As String = json("body").ToString().Trim()

                    ' Parse the version and description
                    Dim version As Version = Version.Parse(tagName.Substring(1)) ' Remove the leading "v"
                    Return New ReleaseInfo(version, description)
                Else
                    Throw New Exception("Unexpected response format.")
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetLatestReleaseInfo: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Class ReleaseInfo
        Public Property Version As Version
        Public Property Description As String

        Public Sub New(version As Version, description As String)
            Me.Version = version
            Me.Description = description
        End Sub
    End Class


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ShowLatestReleaseInfo()
    End Sub
End Class
