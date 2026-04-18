# HybridArms Project Instructions

Welcome to the HybridArms project! This document provides guidelines for working with this project.

## Workflow Guidelines

### Issues

- All work should start with an issue. Use the `create-issue` skill to create new issues.

### Pull Requests

- Every PR must be linked to an issue using `Closes #123` or `Fixes #456`
- Use the `create-mr` skill to create new PRs.

### Commits

- Follow Conventional Commits format: `<type>(<scope>): <description> (#<issue-id>)`
- Allowed types: feat, fix, docs, style, refactor, test, chore
- Use the `prepare-commit` skill to help write commit messages.

## Skills

This project has custom skills available:
- `create-issue` - Create a new issue with proper labeling
- `create-mr` - Create a new MR linked to an issue
- `prepare-commit` - Generate a Conventional Commit message
