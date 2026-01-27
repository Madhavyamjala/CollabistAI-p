# Collabist.Server

Collabist.Server is the **local backend engine** that powers all intelligence, permissions, indexing, and AI execution for Collabist. It is designed to run **locally on the user’s machine** and acts as the single source of truth for knowledge, security boundaries, and system state.

The server is intentionally built as a **long-running, resumable system service**, not a stateless API.

---

## Purpose

Collabist.Server exists to:

* Manage file system permissions
* Index approved folders and files
* Build and persist internal knowledge representations
* Perform semantic understanding
* Route queries intelligently
* Execute AI models (local or cloud)

It is responsible for **everything that requires trust**.

---

## What the Server Owns

The server owns and controls:

* File system access (approved paths only)
* Indexing and resumability
* Knowledge persistence
* Semantic metadata
* Query routing logic
* AI execution policies

The frontend **never** accesses files or models directly.

---

## High-Level Architecture

```
Collabist.Client
        ? HTTP
Collabist.Server (ASP.NET Core)
        ?
Permission Layer
        ?
Indexing Engine
        ?
Semantic Understanding
        ?
Query Routing
        ?
AI Execution (Local / Cloud)
```

---

## Core Components

### Permission & Scope Layer

* KnowledgeBase (internal scope boundary)
* DataSource (approved folder or file root)
* `.collabistignore` enforcement
* Persistent permission storage

This layer ensures that **no file is accessed without explicit user approval**.

---

### Indexing Engine

Responsibilities:

* Recursive file discovery
* File-type filtering
* Ignore-rule application
* SHA256 hashing
* Change detection
* Restart-safe progress persistence

Key guarantees:

* Safe across shutdowns
* No duplicate indexing
* Deterministic behavior

---

### Semantic Layer (Lightweight)

Responsibilities:

* Extract readable text from indexed files
* Generate lightweight semantic summaries
* Extract keywords and document metadata
* Persist semantic understanding per file

Notes:

* Uses **local lightweight models** (downloaded during onboarding)
* No cloud calls at this stage
* Optimized for speed and low cost

---

### Query Routing Layer (In Progress)

Responsibilities:

* Classify incoming user queries
* Select relevant semantic documents
* Assemble minimal, high-signal context

This layer ensures:

* Reduced token usage
* Faster responses
* Strong relevance

---

### AI Execution Layer (Planned)

Supported modes:

* Local LLM execution
* Company-managed cloud models
* User-provided API keys
* Hybrid execution strategies

Execution is controlled by **explicit AI policies**, never implicit behavior.

---

## Technology Stack

* **Framework**: ASP.NET Core
* **Language**: C#
* **Database**: SQLite (local-first)
* **ORM**: Entity Framework Core
* **API Style**: REST
* **Hosting**: Local process (desktop-ready)

---

## Development Principles

* Backend is the authority
* All operations are resumable
* All access is auditable
* No hidden file access
* No implicit knowledge mixing

Design decisions favor **long-term scalability** over short-term convenience.

---

## Current Status

Implemented:

* Permission system
* Indexing engine
* Semantic metadata pipeline

In progress:

* Query-time semantic routing

Planned:

* Local LLM integration
* Background workers
* Enterprise features

---

## Running the Server (Development)

1. Restore dependencies
2. Apply EF Core migrations
3. Run the ASP.NET Core project
4. Access APIs via Swagger

The server is designed to run continuously in the background for desktop deployments.

---

## Security Notes

* File access is strictly scoped
* All paths are user-approved
* No file contents are exposed to the client
* No automatic cloud uploads

---

Collabist.Server is the foundation of Collabist. If it is correct, everything built on top of it remains safe, scalable, and trustworthy.
