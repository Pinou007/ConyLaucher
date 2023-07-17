Imports Guna.UI2.WinForms.Suite
Imports System.Windows.Forms
Imports System.IO
Imports System
Imports System.Diagnostics
Imports System.Net.NetworkInformation
Imports Guna.UI2.WinForms
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Diagnostics.Metrics
Imports System.Net
Imports System.Security.Policy

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Code exécuté lors du chargement du formulaire

        ' Chargement des images
        PictureBox3.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\dark\joypad.png")


        Dim filePath As String = Application.StartupPath & "\laucher\cony-launcher\setting\theme.cony"

        ' Vérifier si le fichier existe
        If File.Exists(filePath) Then
            ' Lire le contenu du fichier
            Dim content As String = File.ReadAllText(filePath)

            ' Vérifier si le contenu contient le mot "Dark"
            If content.Contains("Dark") Then
                ' Le fichier contient "Dark"
                Guna2ComboBox1.StartIndex = 1

            ElseIf content.Contains("Red") Then
                ' Le fichier contient "Red"
                Panel2.BackColor = Color.FromArgb(88, 8, 8)
                Me.BackColor = Color.FromArgb(71, 6, 6)
                Guna2Button3.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\dark\joypad.png")
                Guna2Button4.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\dark\cog.png")
                Guna2ComboBox1.StartIndex = 2

            Else
                ' Le fichier ne contient pas "Dark"
                Panel2.BackColor = Color.WhiteSmoke
                Me.BackColor = Color.White
                Label1.ForeColor = Color.Black
                Guna2Button3.ForeColor = Color.Black
                Guna2Button4.ForeColor = Color.Black
                Guna2Button3.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\white\joypad.png")
                Guna2Button4.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\white\cog.png")
                Guna2Button1.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\white\end_bar.png")
                Guna2Button2.Image = New Bitmap(Application.StartupPath & "\laucher\cony-launcher\icon\white\min_bar.png")
                Guna2ComboBox1.StartIndex = 0
            End If
        Else
            ' Le fichier n'existe pas
            File.Create(Application.StartupPath & "\laucher\cony-launcher\setting\theme.cony")
        End If



    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Bouton "Fermer"
        Me.Hide() ' Masquer le formulaire actuel
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        ' Bouton "Minimiser"
        Me.WindowState = FormWindowState.Minimized ' Réduire la fenêtre à l'icône de la barre des tâches
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        ' Bouton "Afficher Game"
        Settings.Visible = False ' Masquer le panneau des paramètres
        Game.Visible = True ' Afficher le panneau du jeu




        ' Spécifie l'URL de la page à télécharger
        Dim url As String = "https://raw.githubusercontent.com/Pinou007/Cony-Game-Public/main/app/version/ProjectSpike/version-game"

        ' Spécifie le chemin complet du fichier de destination
        Dim filePath As String = Path.Combine(Application.StartupPath, "laucher\project-spike\info\game_version.cony")

        ' Crée un objet WebClient pour télécharger le contenu de la page
        Dim client As New WebClient()

        ' Télécharge le contenu de la page et le stocke dans une variable
        Dim htmlContent As String = client.DownloadString(url)

        ' Écrit le contenu téléchargé dans le fichier de destination
        File.WriteAllText(filePath, htmlContent)

        ' Affiche un message de confirmation
        Console.WriteLine("Le fichier HTML a été téléchargé avec succès.")
        Console.ReadLine()







        ' Chemin du fichier contenant la version du jeu
        Dim gameVersionFile As String = Path.Combine(Application.StartupPath, "laucher\project-spike\info\game_version_install.cony")

        ' Chemin du fichier contenant la version installée du jeu
        Dim installedVersionFile As String = Path.Combine(Application.StartupPath, "laucher\project-spike\info\game_version.cony")

        ' Vérifier si les fichiers de version existent
        If File.Exists(gameVersionFile) AndAlso File.Exists(installedVersionFile) Then
            ' Lire le contenu du fichier de version du jeu
            Dim gameVersion As String = File.ReadAllText(gameVersionFile)

            ' Lire le contenu du fichier de version installée du jeu
            Dim installedVersion As String = File.ReadAllText(installedVersionFile)

            ' Comparer les numéros de version
            If String.Compare(gameVersion, installedVersion) > 0 Then
                ' Afficher un message si la version du jeu est supérieure à la version installée
                GameInstall.Visible = False
                GamePlay.Visible = True
                MsgBox("Up")
            ElseIf String.Compare(gameVersion, installedVersion) < 0 Then
                ' Afficher un message si la version du jeu est inférieure à la version installée
                Label2.Visible = True
                GameInstall.Visible = True
                GamePlay.Visible = False

            Else
                ' Afficher un message si la version du jeu est égale à la version installée
                GameInstall.Visible = False
                GamePlay.Visible = True

            End If
        Else
            ' Afficher un message si les fichiers de version sont introuvables
            MsgBox("Les fichiers de version sont introuvables.")

        End If





    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        ' Bouton "Afficher Paramètres"
        Settings.Visible = True ' Afficher le panneau des paramètres
        Game.Visible = False ' Masquer le panneau du jeu
    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click

        GamePlay.Visible = False
        ' Obtient le chemin complet du dossier de démarrage de l'application
        Dim startupPath As String = Application.StartupPath

        ' Chemin du dossier à supprimer
        Dim folderPath As String = Path.Combine(startupPath, "game\projects_spike\")

        ' Vérifie si le dossier existe
        If Directory.Exists(folderPath) Then
            ' Supprime tous les sous-dossiers et fichiers récursivement
            Directory.Delete(folderPath, True)
        End If

        Directory.CreateDirectory(Application.StartupPath + "game\projects_spike\")
        File.Delete(Application.StartupPath + "laucher\project-spike\info\game_version_install.cony")
        File.Create(Application.StartupPath + "laucher\project-spike\info\game_version_install.cony")
        GameInstall.Visible = True

    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Panel2.Visible = False
        GamePlay.Visible = False
        GameInstall.Visible = False
        Download.Visible = True










    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged




    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        File.WriteAllText(Application.StartupPath & "\laucher\cony-launcher\setting\theme.cony", Guna2ComboBox1.SelectedItem.ToString())
        Dim gamePath As String = Application.StartupPath & "\LaucherGame.exe"

        Process.Start(Application.StartupPath & "\LaucherGame.exe")
        End
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Visible = True ' Afficher le panneau des paramètres
        Game.Visible = False ' Masquer le panneau du jeu
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class