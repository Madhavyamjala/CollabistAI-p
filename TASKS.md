# Collabist – Tasks & Roadmap

This document tracks the **current state, completed work, and upcoming tasks** for the Collabist project. It is intended to be the single source of truth for development progress.

---

## Completed Tasks (Foundation Phase)

### Architecture & Setup

* [x] Project scaffolding (Client + Server separation)
* [x] Local-first architecture decision
* [x] Internal KnowledgeBase abstraction
* [x] Clear responsibility split between client and server

### Permission & Scope Layer

* [x] KnowledgeBase entity (internal, non-user-facing)
* [x] DataSource entity (approved folders/files)
* [x] One-time folder approval flow
* [x] Persistent permission storage
* [x] `.collabistignore` support
* [x] Explicit permission boundaries

### Indexing Engine

* [x] Recursive file discovery
* [x] Allowed file-type filtering
* [x] Ignore-rule enforcement
* [x] SHA256 hashing for file change detection
* [x] IndexedFile persistence
* [x] Restart-safe, resumable indexing
* [x] Manual indexing trigger (API)

### Semantic Layer (Lightweight)

* [x] SemanticDocument entity
* [x] Text extraction service (txt, md)
* [x] Lightweight semantic parsing
* [x] File-level summaries
* [x] Keyword extraction
* [x] Document type inference
* [x] Persistent semantic metadata storage

### Documentation

* [x] Root README.md
* [x] Collabist.Client README
* [x] Collabist.Server README
* [x] Architecture documentation

---

## In Progress Tasks

### Query-Time Intelligence

* [ ] Query classification service
* [ ] Semantic relevance scoring
* [ ] Selection of relevant SemanticDocuments
* [ ] Context assembly logic
* [ ] Token-budget–aware context packing

---

## AI Execution Layer

### Local Models

* [ ] Lightweight semantic model download during onboarding
* [ ] Local semantic model runtime integration
* [ ] Model lifecycle management (load/unload)

### LLM Execution

* [ ] Local LLM integration (Ollama-compatible)
* [ ] Company-managed cloud LLM fallback
* [ ] User-provided API key support
* [ ] Hybrid execution strategies

---

##  Client & UX

### Core UI

* [ ] In-app chat view
* [ ] Chat history persistence
* [ ] Application shell (sidebar + main view)

### Quick Access

* [ ] Floating quick-chat overlay (desktop)
* [ ] Global keyboard shortcut
* [ ] System tray / menu bar integration

### Settings & Feedback

* [ ] Native folder picker
* [ ] Indexing progress indicator
* [ ] Error and permission feedback UI

---

## Desktop Packaging

* [ ] Windows executable packaging
* [ ] Background service auto-start
* [ ] Graceful shutdown handling
* [ ] Native notifications

---

## Startup & Enterprise Features

### Organization & Teams

* [ ] Organization entity expansion
* [ ] Group and subgroup hierarchy
* [ ] Role-based access control

### Knowledge Sharing

* [ ] Shared internal knowledge graphs
* [ ] Team-scoped semantic routing
* [ ] Knowledge isolation guarantees

### Security & Compliance

* [ ] Audit logs
* [ ] Access traceability
* [ ] Enterprise authentication integration

---

## Release Milestones

### v0.1.0 – Foundation Release

* Local-first indexing
* Semantic metadata pipeline
* API stability

### v0.2.0 – Intelligence Release

* Query-time semantic routing
* Context-aware answers

### v0.3.0 – Desktop Release

* Native desktop packaging
* Quick-chat overlay

### v1.0.0 – Team & Enterprise Ready

* Multi-user support
* Organization hierarchy
* Enterprise security features

---

## Notes

* Tasks are intentionally ordered to avoid architectural rework
* Foundation layers must remain stable before higher-level features
* Local-first guarantees are non-negotiable

---

This file should be updated continuously as Collabist evolves.
