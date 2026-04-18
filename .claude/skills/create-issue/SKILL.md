---
name: create-issue
description: Use when creating a new issue for the HybridArms project
---

# Create Issue

## Overview
Walks the user through creating a well-structured issue for the HybridArms project with proper labeling.

## Steps

1. **Check for GitHub CLI:**
   - First, run `gh auth status` to check if the user is logged into GitHub CLI
   - If logged in, proceed with automatic creation option
   - If not logged in, fall back to content generation only

2. **Ask for issue type:**
   - type:bug
   - type:feature
   - type:refactor
   - type:docs
   - type:question

3. **Ask for priority:**
   - priority:high
   - priority:medium
   - priority:low

4. **Ask for area:**
   - area:gameplay
   - area:ui
   - area:ci
   - area:assets
   - area:other

5. **Ask for a clear title**

6. **Ask for a detailed description**

7. **If it's a bug, ask additionally for:**
   - Steps to reproduce
   - Expected behavior
   - Environment info

8. **If GitHub CLI is available:**
   - Offer to create the issue directly using `gh issue create`
   - Try to add labels, but if labels don't exist, create without them
   - Show the issue URL after creation

9. **Generate the complete issue content in markdown format**

10. **List the suggested labels**

11. **Remind the user to create a branch** with a name like: `type/123-short-description` (where 123 is the issue number they'll get after creating it on GitHub)
