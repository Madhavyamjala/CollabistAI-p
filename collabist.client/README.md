# Collabist.Client

Collabist.Client is the **frontend application** for Collabist. It provides the user interface for onboarding, configuration, and interaction with the local AI assistant while delegating all sensitive operations (file access, indexing, AI execution) to the local backend.

The client is intentionally kept **thin and declarative**, acting as a control surface rather than a processing layer.

---

## Purpose

The client exists to:

* Guide users through onboarding
* Allow one-time approval of folders
* Display application state (indexing, readiness)
* Provide chat and quick-access interfaces

It **never**:

* Reads local files directly
* Indexes documents
* Stores knowledge or embeddings
* Executes AI models

All intelligence lives in the backend.

---

## Architecture Role

```
User
 ?
Collabist.Client (React)
 ? HTTP
Collabist.Server (ASP.NET Core)
```

The client communicates exclusively through well-defined APIs exposed by the backend.

---

## Current Features

### Onboarding

* First-run onboarding flow
* Backend-driven onboarding state
* Automatic transition to main app when ready

### Settings & Configuration

* Folder approval UI (path-based for now)
* Knowledge access visibility
* Persistent backend-backed state

### Application Shell

* In-app view with sidebar + main panel
* View switching driven by application state

---

## Planned Features

### Interaction

* Full chat interface
* Chat history per session
* Context-aware responses

### Quick Access

* Floating quick-chat window
* System tray / menu bar access
* Global shortcut support

### UX Improvements

* Native folder picker integration
* Indexing progress indicators
* Error and permission feedback

---

## Tech Stack

* **Framework**: React
* **Build Tool**: Vite
* **Language**: JavaScript (ES6+)
* **State**: Local component state + backend truth
* **Styling**: Minimal, system-native oriented

---

## Design Principles

* Backend is the source of truth
* UI reflects state, never infers it
* No file system assumptions
* Desktop-first UX, web-compatible

---

## Development Notes

* The client is designed to be packaged later into a desktop shell
* No architectural changes are required when moving to Windows/macOS executables
* All security-sensitive logic must remain server-side

---

## Status

Collabist.Client is under active development and currently focuses on onboarding and configuration flows.

---

Collabist.Client is intentionally simple so that Collabist as a whole remains powerful, safe, and scalable.
