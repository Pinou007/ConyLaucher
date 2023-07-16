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

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Code exécuté lors du chargement du formulaire
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
        Dim gameVersionFile As String = Path.Combine(Application.StartupPath, "laucher\project-spike\info\game_version.cony")

        ' Chemin du fichier contenant la version installée du jeu
        Dim installedVersionFile As String = Path.Combine(Application.StartupPath, "laucher\project-spike\info\game_version_install.cony")

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


End Class