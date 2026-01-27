# Collabist

Collabist is a **local-first AI knowledge assistant** that builds a persistent understanding of a user’s files and documents to deliver fast, private, and context-aware answers. Instead of repeatedly uploading files or manually selecting knowledge bases, Collabist indexes approved folders once, understands them in the background, and intelligently routes queries to the most relevant information.

The system is designed to scale cleanly from **individual power users** to **startups** and eventually **large enterprises**, without architectural rewrites.

---

## Why Collabist?

Most AI assistants treat every question as stateless. Collabist does the opposite.

* Your data is **indexed once**, not re-uploaded every time
* Knowledge persists across sessions
* Context is selected automatically
* File access is explicit and auditable
* Works offline-first with optional cloud support

Collabist behaves more like an **intelligent operating system layer** than a chat app.

---

## Core Principles

* **Local-first by default** – data stays on the user’s machine
* **One-time permissions** – folders approved once, reused forever
* **Resumable background processing** – safe across shutdowns
* **Automatic internal knowledge bases** – no manual KB selection
* **Model-agnostic** – local models, company cloud, or user-provided APIs

---

## High-Level Architecture

```
React UI (Desktop / Web)
        ↓
ASP.NET Core Backend (Local)
        ↓
Approved File System Access
        ↓
Indexing Layer
        ↓
Semantic Understanding Layer
        ↓
Query Routing
        ↓
Local / Cloud LLM
```

---

## Current Features (Implemented)

### Permissions & Access

* Folder approval with persistent storage
* Internal KnowledgeBase scoping
* `.collabistignore` support for excluded files/folders

### Indexing Engine

* Recursive file discovery
* Allowed file-type filtering
* Ignore-rule enforcement
* SHA256 hashing for change detection
* Restart-safe and resumable indexing

### Semantic Layer (Lightweight, Local)

* File-level semantic summaries
* Keyword extraction
* Document type inference
* Persistent semantic metadata per file

These layers together form a **local knowledge graph** that is always available to the assistant.

---

## What Collabist Does *Not* Do

* It does **not** upload files by default
* It does **not** ask users to reselect files per query
* It does **not** mix knowledge across permission boundaries
* It does **not** depend on a single AI provider

---

## Upcoming Features

### Query-Time Intelligence

* Lightweight query classification
* Semantic routing to relevant documents
* Context-window–aware context assembly

### AI Execution Modes

* Local semantic model (downloaded during onboarding)
* Local LLM execution (e.g., Ollama-compatible)
* Company-managed cloud LLM fallback
* User-provided API keys

### User Experience

* In-app chat interface with history
* Floating quick-chat overlay (desktop)
* Background services and auto-start

### Team & Enterprise Readiness

* Organizations, groups, and subgroups
* Scoped knowledge visibility
* Shared internal knowledge graphs
* Audit and access logs

---

## Target Users

* **Individuals** – personal knowledge assistant
* **Power users & developers** – local-first, offline-capable AI
* **Startups** – shared internal knowledge without SaaS lock-in
* **Enterprises** – secure, permissioned AI over internal data

---

## Development Philosophy

Collabist is built **bottom-up**, prioritizing:

* Correctness over demos
* Persistence over stateless chats
* Architecture over shortcuts
* Scalability over quick hacks

Every layer is designed so that future expansion (teams, enterprise, scale) does **not** require refactoring core systems.

---

## Status

Collabist is currently in **active development**, with the foundational indexing and semantic layers completed and query-time intelligence in progress.

---

## License

License to be defined.

---

Collabist aims to redefine how humans interact with their own knowledge — private, persistent, and intelligent by design.
