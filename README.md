# Éditeur de graphes (C# / Windows Forms)

Application de bureau en C# (.NET 8, Windows Forms) pour dessiner des graphes : créer des nœuds, les relier par des traits, les déplacer, les sélectionner à plusieurs, modifier leurs propriétés, zoomer et annuler ou rétablir ses actions. Projet réalisé dans le cadre du BUT Informatique (IUT de Bordeaux).

## Fonctionnalités

- **Création de nœuds et de traits :** Un clic dans le vide crée un nœud. Un glisser depuis un nœud crée un trait vers le nœud où l'on relâche, ou vers un nouveau nœud si l'on relâche dans le vide.
- **Boîte de propriétés générique (réflexion) :** Un clic droit sur un nœud ouvre une fenêtre générée automatiquement à partir de ses propriétés (texte, couleur, épaisseur, taille et police du texte). Elle s'adapte à toute nouvelle propriété ajoutée à la classe sans modifier la fenêtre.
- **Move Mode :** Déplacement d'un nœud, sélection de plusieurs nœuds par rectangle en pointillés ou par Ctrl+clic, et déplacement groupé de la sélection.
- **Annuler / Rétablir :** Historique des actions dans deux piles (journalisation), avec les raccourcis `Ctrl+Z` et `Ctrl+Y`.
- **Zoom et défilement :** Zoom avec `Ctrl` + molette, barres de défilement horizontale et verticale, conversion entre coordonnées du graphe et de l'écran.
- **Réglages par défaut :** Couleur et épaisseur des nouveaux nœuds modifiables depuis la barre d'outils.
- **Affichage sans scintillement :** Double buffering activé sur la fenêtre.

## Commandes

| Action | Résultat |
|--------|----------|
| Clic gauche dans le vide | Crée un nœud |
| Glisser d'un nœud vers un autre nœud (ou vers le vide) | Crée un trait (et un nœud si besoin) |
| Clic droit sur un nœud | Ouvre ses propriétés |
| **Move Mode** + glisser un nœud | Déplace le nœud (ou toute la sélection) |
| **Move Mode** + glisser dans le vide | Trace un rectangle de sélection |
| **Move Mode** + `Ctrl` + clic sur un nœud | Ajoute ou retire le nœud de la sélection |
| `Ctrl` + molette | Zoom avant ou arrière |
| `Ctrl+Z` / `Ctrl+Y` | Annuler / Rétablir |
| Boutons `+` / `-` | Épaisseur des nouveaux nœuds |
| Bouton `Color` | Couleur des nouveaux nœuds |
| Bouton `Erase all` | Efface tout le dessin |

## Architecture

| Classe | Rôle |
|--------|------|
| `FeuilleDessin` | Fenêtre principale, gestion de la souris, de la sélection et du dessin |
| `Node` / `Line` | Nœuds et traits du graphe, avec leur propre méthode de dessin |
| `GraphAction` / `IDeletable` | Historique Annuler/Rétablir, basé sur une suppression logique (`Deleted`) |
| `GenericSettings` | Boîte de propriétés générée par réflexion |
| `Settings` | Valeurs par défaut partagées (couleur, taille, zoom, origine) |
| `Outils` | Conversions entre coordonnées géométriques et coordonnées écran |

## Compétences mises en œuvre

C# et .NET 8, Windows Forms, programmation événementielle (souris, clavier, menus), dessin avec GDI+, réflexion, gestion d'un historique d'actions avec des piles, transformations de coordonnées (zoom et défilement).

## Prérequis

- **Windows** (le projet cible `net8.0-windows`)
- **.NET 8 SDK**
- **Visual Studio 2022** (facultatif, la ligne de commande suffit)

## Installation et lancement

```bash
git clone https://github.com/Chocopter/IUT-Editeur-Graphe.git
cd IUT-Editeur-Graphe/Drawing
dotnet run --project Drawing/Drawing.csproj
```

Ou ouvrir `Drawing.sln` dans Visual Studio et lancer avec `F5`.

## Limites connues

L'historique Annuler/Rétablir ne gère que la création de nœuds et de traits. Les déplacements, les modifications de propriétés et « Erase all » ne peuvent pas être annulés.
