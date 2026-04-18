---
name: create-mr
description: Use when creating a new MR/PR linked to an issue for the HybridArms project
---

# Create MR

## Overview
Walks the user through creating a PR linked to an issue for the HybridArms project.

## Steps

1. **Check for GitHub CLI:**
   - First, run `gh auth status` to check if the user is logged into GitHub CLI
   - If logged in, proceed with automatic creation option
   - If not logged in, fall back to content generation only

2. **Ask for the issue number** this PR closes (e.g., 123)

3. **Ask for the type of change:**
   - Bug fix
   - New feature
   - Breaking change
   - Refactor
   - Documentation
   - CI/CD

4. **Ask what testing was done**

5. **Generate a complete PR description** following the project template, starting with `Closes #<issue-number>`

6. **If GitHub CLI is available:**
   - Offer to push the branch and create the PR directly using `gh pr create`
   - Remind user to push first if not already pushed

7. **Remind the user about the Conventional Commits format** for their commit messages, each linking to the issue
