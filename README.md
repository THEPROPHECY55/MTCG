# Monster Trading Card Game (MTCG)

GIT Repo: https://github.com/THEPROPHECY55/MTCG/tree/networking

Dieses Projekt ist ein Trading Card Game (TCG), das in C# entwickelt wurde und eine Docker-basierte Integration mit einer PostgreSQL-Datenbank verwendet. Es bietet eine funktionsfähige Serververbindung und unterstützt (zukünftig) Gameplay-Mechaniken, Netzwerkanfragen und Benutzerverwaltung. Work in Progress...

## Features
- **Kartenbasierte Kämpfe**: Kämpfe mit Monster- und Zauberkarten.
- **Handelssystem**: Spieler können Karten untereinander tauschen.
- **Benutzerauthentifizierung**: Sichere Benutzerverwaltung mit Tokens.
- **PostgreSQL-Datenbank**: Speicherung von Benutzerdaten und Spielinformationen.
- **Eigenes HTTP-Server-System**: Kontrollierte Handhabung von HTTP-Anfragen und -Antworten.

## Ordnerstruktur und Funktionalität

### 1. Database
Dieser Ordner enthält die Datenbanklogik und stellt die Verbindung zur PostgreSQL-Datenbank her.

- **`DBConnection.cs`**
  - Verwaltet die Verbindung zur Datenbank.
  - Methoden zum Öffnen und Schließen von Verbindungen.
  - Verantwortlich für das Datenhandling zwischen der Datenbank und der Anwendung.

### 2. Gameplay
Der Gameplay-Ordner steuert die Spielmechaniken und definiert die Karten und ihre Effekte.

- **`Battle.cs`**
  - Steuert die Kämpfe zwischen Karten und Spielern.
  
- **`Card.cs`**, **`MonsterCard.cs`**, **`SpellCard.cs`**
  - Definiert die Hauptkarte und ihre Unterarten (Monster- und Zauberkarten).
  
- **`ElementEffectCalc.cs`**, **`ElementType.cs`**
  - Kalkuliert die Effekte von Elementen in Kämpfen.
  
- **`Trade.cs`**
  - Implementiert das Tauschsystem für Karten zwischen Spielern.

### 3. Networking
Dieser Ordner behandelt die Netzwerkschicht und die Kommunikation zwischen Server und Clients.

- **`AuthController.cs`**
  - Verarbeitet die Authentifizierung von Benutzern.
  
- **`HttpRequest.cs`**, **`HttpResponse.cs`**
  - Handhabt die HTTP-Anfragen und -Antworten.

- **`HttpServer.cs`**
  - Definiert den HTTP-Server, der Anfragen von Clients entgegennimmt.

- **`Router.cs`**
  - Verwaltet das Routing von HTTP-Anfragen zu den jeweiligen Endpunkten.

### 4. UserCore
Der UserCore-Ordner enthält alle Komponenten für die Benutzerverwaltung und -authentifizierung.

- **`TokenManager.cs`**
  - Verwalter von Authentifizierungstokens (GUID).
  
- **`User.cs`**
  - Repräsentiert einen Benutzer mit Eigenschaften wie Benutzername und Passwort.

- **`UserDTO.cs`**
  - Data Transfer Object zur Weitergabe relevanter Benutzerdaten zwischen Schichten.

- **`UserProfile.cs`**
  - Repräsentiert das Benutzerprofil.

- **`UserService.cs`**
  - Dient als Service zur Registrierung und Anmeldung von Benutzern.

## Design-Entscheidungen
- **Modulare Struktur**: Klare Trennung der Funktionsbereiche wie Datenbankzugriffe, Gameplay-Mechaniken, Netzwerkanfragen und Benutzerverwaltung.
- **Eigener HTTP-Server**: Ermöglicht eine fein abgestimmte Kontrolle über die Handhabung von Anfragen und Kommunikation.
  
## Voraussetzungen
- .NET SDK
- Docker
- PostgreSQL
