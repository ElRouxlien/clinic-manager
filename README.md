# Clinic Manager

Application de bureau **C# / WinForms** pour gérer un centre médical, réalisée comme TP final (HELB).

## Fonctionnalités

- Gestion des **médecins** (numéro INAMI, spécialité, tarif)
- Gestion des **patients** (date de naissance, numéro de dossier, assurance)
- Planification et suivi des **consultations** (type, durée, statut, coût total)
- Validation des données saisies
- Base de données **SQLite** créée automatiquement au premier lancement (`medicalCenter.db`)

## Architecture

- `Models/` : entités (`Person`, `Doctor`, `Patient`, `Consultation`) et énumérations
- `Repositories/` : accès aux données SQLite (patron Repository)
- `Validators/` : règles de validation
- Formulaires WinForms pour l'affichage et la gestion

## Technologies

C# · .NET 8 (Windows) · WinForms · System.Data.SQLite

## Lancer le projet

Ouvrir `TPFinalJulienBaron.sln` dans **Visual Studio 2022**, puis lancer avec F5.

Ou en ligne de commande :

```bash
dotnet run --project BaseTPFinal2526
```
